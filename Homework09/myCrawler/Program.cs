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

namespace myCrawler
{
    class Crawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            new Thread(myCrawler.Crawl).Start();
            
        }
        public void start(string startUrl)
        {
            urls.Add(startUrl, false);
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


                string matchString = @"^https?://[\w]+.cnblogs.com";


                if (Regex.IsMatch(current, matchString))
                {
                    Console.WriteLine($"爬行{current}页面！");
                    html = DownLoad(current);
                    urls[current] = true;
                }

                count++;

                if (Regex.IsMatch(html, @"#<html#>") || Regex.IsMatch(html, @"javascript") || Regex.IsMatch(html, @"aspx"))
                {
                    Parse(html, current);
                }

            }
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
                if (Regex.IsMatch(strRef, @"^[.]{1}/[\w]+[/]?"))
                {
                    strRef = father + strRef.Substring(1);
                }
                if(Regex.IsMatch(strRef, @"^/[\w]+[/]?"))
                {
                    string root  = new Regex(@"^https?://[\w]+.cnblogs.com").Match(father).Value;
                    strRef = root + strRef;

                }
                if(Regex.IsMatch(strRef, @"^[.]{2}/[\w]+[/]?")){
                    var index = father.LastIndexOf('/');
                    var root = father.Substring( 0, index+1);
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

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}
