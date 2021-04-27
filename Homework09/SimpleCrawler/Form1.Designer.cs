
namespace Crawler
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_startUrl = new System.Windows.Forms.TextBox();
            this.button_crawler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_rightUrl = new System.Windows.Forms.ListBox();
            this.bindingSource_rightUrl = new System.Windows.Forms.BindingSource(this.components);
            this.listBox_errorUrl = new System.Windows.Forms.ListBox();
            this.bindingSource_errorUrl = new System.Windows.Forms.BindingSource(this.components);
            this.timer_showUrl = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_rightUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_errorUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_startUrl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_crawler, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox_rightUrl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBox_errorUrl, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_startUrl
            // 
            this.textBox_startUrl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox_startUrl.Location = new System.Drawing.Point(73, 9);
            this.textBox_startUrl.Name = "textBox_startUrl";
            this.textBox_startUrl.Size = new System.Drawing.Size(324, 21);
            this.textBox_startUrl.TabIndex = 0;
            // 
            // button_crawler
            // 
            this.button_crawler.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_crawler.Location = new System.Drawing.Point(403, 8);
            this.button_crawler.Name = "button_crawler";
            this.button_crawler.Size = new System.Drawing.Size(75, 23);
            this.button_crawler.TabIndex = 1;
            this.button_crawler.Text = "爬取";
            this.button_crawler.UseVisualStyleBackColor = true;
            this.button_crawler.Click += new System.EventHandler(this.button_crawler_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(166, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "爬取的URL";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(566, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "错误的URL";
            // 
            // listBox_rightUrl
            // 
            this.listBox_rightUrl.AllowDrop = true;
            this.listBox_rightUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_rightUrl.DataSource = this.bindingSource_rightUrl;
            this.listBox_rightUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_rightUrl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_rightUrl.FormattingEnabled = true;
            this.listBox_rightUrl.HorizontalExtent = 500;
            this.listBox_rightUrl.HorizontalScrollbar = true;
            this.listBox_rightUrl.ItemHeight = 22;
            this.listBox_rightUrl.Location = new System.Drawing.Point(5, 85);
            this.listBox_rightUrl.Margin = new System.Windows.Forms.Padding(5);
            this.listBox_rightUrl.Name = "listBox_rightUrl";
            this.listBox_rightUrl.Size = new System.Drawing.Size(390, 360);
            this.listBox_rightUrl.TabIndex = 6;
            // 
            // bindingSource_rightUrl
            // 
            this.bindingSource_rightUrl.DataSource = typeof(SimpleCrawler.Crawlers);
            // 
            // listBox_errorUrl
            // 
            this.listBox_errorUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_errorUrl.DataSource = this.bindingSource_errorUrl;
            this.listBox_errorUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_errorUrl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_errorUrl.FormattingEnabled = true;
            this.listBox_errorUrl.HorizontalExtent = 500;
            this.listBox_errorUrl.HorizontalScrollbar = true;
            this.listBox_errorUrl.ItemHeight = 22;
            this.listBox_errorUrl.Location = new System.Drawing.Point(405, 85);
            this.listBox_errorUrl.Margin = new System.Windows.Forms.Padding(5);
            this.listBox_errorUrl.Name = "listBox_errorUrl";
            this.listBox_errorUrl.Size = new System.Drawing.Size(390, 360);
            this.listBox_errorUrl.TabIndex = 7;
            // 
            // bindingSource_errorUrl
            // 
            this.bindingSource_errorUrl.DataSource = typeof(SimpleCrawler.Crawlers);
            // 
            // timer_showUrl
            // 
            this.timer_showUrl.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_rightUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_errorUrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_startUrl;
        private System.Windows.Forms.Button button_crawler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_rightUrl;
        private System.Windows.Forms.Timer timer_showUrl;
        private System.Windows.Forms.BindingSource bindingSource_errorUrl;
        private System.Windows.Forms.ListBox listBox_errorUrl;
        private System.Windows.Forms.BindingSource bindingSource_rightUrl;
    }
}

