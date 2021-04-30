
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
            this.tableLayoutPanel_crawler = new System.Windows.Forms.TableLayoutPanel();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.lbx_rightUrl = new System.Windows.Forms.ListBox();
            this.lbx_wrongUrl = new System.Windows.Forms.ListBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblFail = new System.Windows.Forms.Label();
            this.tableLayoutPanel_crawler.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_crawler
            // 
            this.tableLayoutPanel_crawler.ColumnCount = 2;
            this.tableLayoutPanel_crawler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_crawler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_crawler.Controls.Add(this.lbx_rightUrl, 0, 3);
            this.tableLayoutPanel_crawler.Controls.Add(this.lbx_wrongUrl, 1, 3);
            this.tableLayoutPanel_crawler.Controls.Add(this.txt_url, 0, 0);
            this.tableLayoutPanel_crawler.Controls.Add(this.btn_start, 1, 0);
            this.tableLayoutPanel_crawler.Controls.Add(this.lblState, 0, 1);
            this.tableLayoutPanel_crawler.Controls.Add(this.lblRight, 0, 2);
            this.tableLayoutPanel_crawler.Controls.Add(this.lblFail, 1, 2);
            this.tableLayoutPanel_crawler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_crawler.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_crawler.Name = "tableLayoutPanel_crawler";
            this.tableLayoutPanel_crawler.RowCount = 4;
            this.tableLayoutPanel_crawler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.775411F));
            this.tableLayoutPanel_crawler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.680528F));
            this.tableLayoutPanel_crawler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.590327F));
            this.tableLayoutPanel_crawler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.95374F));
            this.tableLayoutPanel_crawler.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel_crawler.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_start.Location = new System.Drawing.Point(403, 8);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_url
            // 
            this.txt_url.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_url.Location = new System.Drawing.Point(26, 9);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(371, 21);
            this.txt_url.TabIndex = 1;
            // 
            // lbx_rightUrl
            // 
            this.lbx_rightUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbx_rightUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_rightUrl.Font = new System.Drawing.Font("Trebuchet MS", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_rightUrl.FormattingEnabled = true;
            this.lbx_rightUrl.HorizontalExtent = 500;
            this.lbx_rightUrl.HorizontalScrollbar = true;
            this.lbx_rightUrl.ItemHeight = 18;
            this.lbx_rightUrl.Location = new System.Drawing.Point(3, 92);
            this.lbx_rightUrl.Name = "lbx_rightUrl";
            this.lbx_rightUrl.Size = new System.Drawing.Size(394, 355);
            this.lbx_rightUrl.TabIndex = 2;
            // 
            // lbx_wrongUrl
            // 
            this.lbx_wrongUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbx_wrongUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_wrongUrl.Font = new System.Drawing.Font("Trebuchet MS", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_wrongUrl.FormattingEnabled = true;
            this.lbx_wrongUrl.HorizontalExtent = 500;
            this.lbx_wrongUrl.HorizontalScrollbar = true;
            this.lbx_wrongUrl.ItemHeight = 18;
            this.lbx_wrongUrl.Location = new System.Drawing.Point(403, 92);
            this.lbx_wrongUrl.Name = "lbx_wrongUrl";
            this.lbx_wrongUrl.Size = new System.Drawing.Size(394, 355);
            this.lbx_wrongUrl.TabIndex = 3;
            // 
            // lblState
            // 
            this.lblState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblState.Location = new System.Drawing.Point(200, 45);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 12);
            this.lblState.TabIndex = 4;
            // 
            // lblRight
            // 
            this.lblRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRight.AutoSize = true;
            this.lblRight.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRight.Location = new System.Drawing.Point(170, 70);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(59, 12);
            this.lblRight.TabIndex = 5;
            this.lblRight.Text = "正确的URL";
            // 
            // lblFail
            // 
            this.lblFail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFail.AutoSize = true;
            this.lblFail.ForeColor = System.Drawing.Color.Red;
            this.lblFail.Location = new System.Drawing.Point(570, 70);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(59, 12);
            this.lblFail.TabIndex = 6;
            this.lblFail.Text = "出错的URL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel_crawler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel_crawler.ResumeLayout(false);
            this.tableLayoutPanel_crawler.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_crawler;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.ListBox lbx_rightUrl;
        private System.Windows.Forms.ListBox lbx_wrongUrl;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblFail;
    }
}

