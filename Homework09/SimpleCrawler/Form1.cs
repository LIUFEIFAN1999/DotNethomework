using SimpleCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Crawler
{
    public partial class Form1 : Form
    {
        Crawlers crawler = new Crawlers();
        public Form1()
        {
            InitializeComponent();
            listBox_rightUrl.SelectedIndex = -1;
            bindingSource_rightUrl.DataSource = crawler;
            bindingSource_rightUrl.DataMember = "urlList";
            bindingSource_errorUrl.DataSource = crawler;
            bindingSource_errorUrl.DataMember = "errorList";
        }

        private void button_crawler_Click(object sender, EventArgs e)
        {
            timer_showUrl.Stop();
            crawler.start(textBox_startUrl.Text);
            timer_showUrl.Interval = 500;
            timer_showUrl.Enabled = true;
            timer_showUrl.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bindingSource_rightUrl.ResetBindings(false);
            bindingSource_errorUrl.ResetBindings(false);
        }
    }
}
