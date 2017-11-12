namespace cwfDataHelp
{
    partial class UCSpeVod
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSpeVod));
            this.dgvlist1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtword = new System.Windows.Forms.ToolStripTextBox();
            this.tsbutshow = new System.Windows.Forms.ToolStripButton();
            this.tsbutsave = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tsbutback = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvlist1
            // 
            this.dgvlist1.AllowUserToAddRows = false;
            this.dgvlist1.AllowUserToDeleteRows = false;
            this.dgvlist1.AllowUserToOrderColumns = true;
            this.dgvlist1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlist1.Location = new System.Drawing.Point(0, 25);
            this.dgvlist1.Name = "dgvlist1";
            this.dgvlist1.RowTemplate.Height = 23;
            this.dgvlist1.Size = new System.Drawing.Size(278, 343);
            this.dgvlist1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtword,
            this.tsbutshow,
            this.tsbutsave,
            this.tsbutback});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(278, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "关键字";
            // 
            // txtword
            // 
            this.txtword.Name = "txtword";
            this.txtword.Size = new System.Drawing.Size(80, 25);
            this.txtword.ToolTipText = "关键字";
            this.txtword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtword_KeyPress);
            // 
            // tsbutshow
            // 
            this.tsbutshow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbutshow.Image = ((System.Drawing.Image)(resources.GetObject("tsbutshow.Image")));
            this.tsbutshow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutshow.Name = "tsbutshow";
            this.tsbutshow.Size = new System.Drawing.Size(36, 22);
            this.tsbutshow.Text = "显示";
            this.tsbutshow.Click += new System.EventHandler(this.tsbutshow_Click);
            // 
            // tsbutsave
            // 
            this.tsbutsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbutsave.Image = ((System.Drawing.Image)(resources.GetObject("tsbutsave.Image")));
            this.tsbutsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutsave.Name = "tsbutsave";
            this.tsbutsave.Size = new System.Drawing.Size(36, 22);
            this.tsbutsave.Text = "保存";
            this.tsbutsave.Click += new System.EventHandler(this.tsbutsave_Click);
            // 
            // tsbutback
            // 
            this.tsbutback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbutback.Image = ((System.Drawing.Image)(resources.GetObject("tsbutback.Image")));
            this.tsbutback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbutback.Name = "tsbutback";
            this.tsbutback.Size = new System.Drawing.Size(36, 22);
            this.tsbutback.Text = "返回";
            this.tsbutback.Click += new System.EventHandler(this.tsbutback_Click);
            // 
            // UCSpeVod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvlist1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCSpeVod";
            this.Size = new System.Drawing.Size(278, 368);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvlist1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtword;
        private System.Windows.Forms.ToolStripButton tsbutshow;
        private System.Windows.Forms.ToolStripButton tsbutsave;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton tsbutback;
    }
}
