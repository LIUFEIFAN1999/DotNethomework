using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class Form1 : Form
    {
        Crawlers crawler = new Crawlers();
        public Form1()
        {
            InitializeComponent();
            crawler.pageDownloaded += Crawler_PageDownloaded;
            crawler.pageFailed += Crawler_PageFailed;
            crawler.pageCompleted += Crawler_PageCompleted;
        }

        private async void StartCrawler()
        {
            string startUrl = txt_url.Text;
            //@"^(?<protocal>https?)://(?<domain>www.baidu.com)(:[\d]+)*($|/)[\w\d/]+"
            Match match = new Regex(@"(?<protocal>https?)://[\w]+.(?<domain>[\w\d.]+)(:[\d]+)*($|/)").Match(startUrl);
            crawler.domainDetect = @"^https?://[\w]+." + match.Groups["domain"].Value;
            crawler.protocalDetect = match.Groups["protocal"].Value;
            lblState.Text = "正在爬取网页......";
            Task task = Task.Run(()=>crawler.start(startUrl));
            await task;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartCrawler();
        }

        private void AddUrl(string url)
        {
            lbx_rightUrl.Items.Add(url);
        }

        private void AddFailedUrl(string url)
        {
            lbx_wrongUrl.Items.Add(url);
        }
        private void Crawler_PageDownloaded(string url)
        {
            if (this.lbx_rightUrl.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] {url});
            }
            else
            {
                AddUrl(url);
            }
        }

        private void Crawler_PageFailed(string url)
        {
            if (this.lbx_wrongUrl.InvokeRequired)
            {
                Action<String> action = this.AddFailedUrl;
                this.Invoke(action, new object[] { url });
            }
            else
            {
                AddFailedUrl(url);
            }
        }

        private void Crawler_PageCompleted()
        {
            if (this.lblState.InvokeRequired)
            {
                Action action = () =>  lblState.Text = "爬取结束!";
                this.Invoke(action);
            }
            else
            {
                lblState.Text = "爬取结束!";
            }
        }
    }
}
