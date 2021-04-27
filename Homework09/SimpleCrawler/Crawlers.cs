using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    class Crawlers
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public List<string> urlList { get; set; } = new List<string>();
        public List<string> errorList { get; set; } = new List<string>();

        public void start(string startUrl)
        {
            urls.Clear();
            count = 0;
            urls.Add(startUrl, false);
            urlList.RemoveAll(url => url!=null);
            errorList.RemoveAll(url => url != null);
            new Thread(Crawl).Start();
        }

        public void Crawl()
        {
            string html = "";

            Console.WriteLine("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                    break;
                }

                if (current == null || count > 20) break;

                string matchString = @"^http(s)?://[\w]*[.]*cnblogs.com";

                if (Regex.IsMatch(current, matchString))
                {
                    Console.WriteLine($"爬行{current}页面！");
                    html = DownLoad(current);
                    urlList.Add(current);
                    urls[current] = true;
                }
                count++;
                if (Regex.IsMatch(html, @"#<html#>") || Regex.IsMatch(html, @"javascript") || Regex.IsMatch(html, @"aspx"))
                {
                    Parse(html, current);
                }
            }
            urlList.Add("爬行结束");
            Console.WriteLine("爬行结束");
        }

        public void Parse(string html, string father)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (Regex.IsMatch(strRef, @"^[.]{1}/[\w]+[/]?"))
                {
                    strRef = father + strRef.Substring(1);
                }
                if (Regex.IsMatch(strRef, @"^/[\w]+[/]?"))
                {
                    string root = new Regex(@"^https?://[\w]+.cnblogs.com").Match(father).Value;
                    strRef = root + strRef;

                }
                if (Regex.IsMatch(strRef, @"^[.]{2}/[\w]+[/]?"))
                {
                    var index = father.LastIndexOf('/');
                    var root = father.Substring(0, index + 1);
                    strRef = strRef.Substring(3);
                    strRef = strRef + root;
                }
                if (strRef.Length == 0) continue;
                string matchString = @"^https?://[\w]+.cnblogs.com";
                if (urls[strRef] == null && Regex.IsMatch(strRef, matchString)) urls[strRef] = false;
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorList.Add(url);
                return "";
            }
        }
    }
}
