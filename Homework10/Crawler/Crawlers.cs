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

namespace Crawler
{
    class Crawlers
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public Action<string> pageDownloaded;
        public Action<string> pageFailed;
        public Action pageCompleted;

        public string webRegexString = @"(?<site>(?<protocal>https?)://(?<domain>[\w\d.]+)(?<port>:[\d]+)*)($|/)(<?file>[\w\d/]+)";
        public string herfRegexString = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
        public string domainDetect { get; set; }
        public string protocalDetect { get; set; }


        public void start(string startUrl)
        {
            urls.Clear();
            count = 0;
            urls.Add(startUrl, false);
            Crawl();
        }

        public void Crawl()
        {
            string html = "";

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


                if (Regex.IsMatch(current, domainDetect))
                {
                    html = DownLoad(current);
                    urls[current] = true;
                    pageDownloaded(current);
                }
                count++;
                if (Regex.IsMatch(html, @"#<html#>") || Regex.IsMatch(html, @"javascript") || Regex.IsMatch(html, @"aspx"))
                {
                    Parse(html, current);
                }
            }
            pageCompleted();
        }

        public void Parse(string html, string father)
        {
            MatchCollection matches = new Regex(herfRegexString).Matches(html);
            foreach (Match match in matches)
            {
                string strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                strRef = Transform(father, strRef);
                if (urls[strRef] == null && Regex.IsMatch(strRef, domainDetect)) urls[strRef] = false;
            }
        }

        private string Transform(string preUrl, string url)
        {
            if (url.StartsWith("./"))
            {
                url = preUrl + url.Substring(1);
            }
            if (url.StartsWith("../"))
            {
                var index = preUrl.LastIndexOf('/');
                var root = preUrl.Substring(0, index + 1);
                url = url.Substring(3);
                url = url + root;
            }
            
            if (url.StartsWith("//"))
            {
                url = protocalDetect + ":" + url;
            }
            if (url.StartsWith("/"))
            {
                Match match = new Regex(webRegexString).Match(preUrl);
                string root = match.Groups["site"].Value;
                url = root + url;
            }
            return url;
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
                pageFailed(url);
                return "";
            }
        }
    }
}
