namespace cwfDataHelp
{
    partial class UCNewsAddUrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNewsAddUrl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbutanalyse = new System.Windows.Forms.ToolStripButton();
            this.tsbutsave = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tsbutclose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbutanalyse,
            this.tsbutsave,
            this.tsbutclose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(253, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbutanalyse
            // 
            this.tsbutanalyse.Image = ((System.Drawing.Image)(resources.GetObject("tsbutanalyse.Image")));
            this.tsbutanalyse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutanalyse.Name = "tsbutanalyse";
            this.tsbutanalyse.Size = new System.Drawing.Size(52, 22);
            this.tsbutanalyse.Text = "分析";
            this.tsbutanalyse.Click += new System.EventHandler(this.tsbutanalyse_Click);
            // 
            // tsbutsave
            // 
            this.tsbutsave.Image = ((System.Drawing.Image)(resources.GetObject("tsbutsave.Image")));
            this.tsbutsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutsave.Name = "tsbutsave";
            this.tsbutsave.Size = new System.Drawing.Size(52, 22);
            this.tsbutsave.Text = "保存";
            this.tsbutsave.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Size = new System.Drawing.Size(253, 351);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 150);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 197);
            this.textBox2.TabIndex = 3;
            // 
            // tsbutclose
            // 
            this.tsbutclose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbutclose.Image = ((System.Drawing.Image)(resources.GetObject("tsbutclose.Image")));
            this.tsbutclose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutclose.Name = "tsbutclose";
            this.tsbutclose.Size = new System.Drawing.Size(52, 22);
            this.tsbutclose.Text = "关闭";
            this.tsbutclose.Click += new System.EventHandler(this.tsbutclose_Click);
            // 
            // UCNewsAddUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCNewsAddUrl";
            this.Size = new System.Drawing.Size(253, 376);
            this.Load += new System.EventHandler(this.UCNewsAddUrl_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbutsave;
        private System.Windows.Forms.ToolStripButton tsbutanalyse;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripButton tsbutclose;
    }
}
