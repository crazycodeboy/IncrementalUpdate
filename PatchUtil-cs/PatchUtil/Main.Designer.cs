namespace WindowsFormsApplication2
{
    partial class Main
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbSaveFileName1 = new System.Windows.Forms.TextBox();
            this.btnSelectSaveFile_1 = new System.Windows.Forms.Button();
            this.tbNewFileName_1 = new System.Windows.Forms.TextBox();
            this.tbOldFileName_1 = new System.Windows.Forms.TextBox();
            this.btnSelectNewFile_1 = new System.Windows.Forms.Button();
            this.btnSelectOldFile_1 = new System.Windows.Forms.Button();
            this.btnGenPatch = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSaveFileName2 = new System.Windows.Forms.TextBox();
            this.btnSelectSaveFile_2 = new System.Windows.Forms.Button();
            this.tbNewFileName_2 = new System.Windows.Forms.TextBox();
            this.tbOldFileName_2 = new System.Windows.Forms.TextBox();
            this.btnSelectFile_2 = new System.Windows.Forms.Button();
            this.btnSelectOldFile_2 = new System.Windows.Forms.Button();
            this.btnApplyPatch = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(483, 342);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbSaveFileName1);
            this.tabPage1.Controls.Add(this.btnSelectSaveFile_1);
            this.tabPage1.Controls.Add(this.tbNewFileName_1);
            this.tabPage1.Controls.Add(this.tbOldFileName_1);
            this.tabPage1.Controls.Add(this.btnSelectNewFile_1);
            this.tabPage1.Controls.Add(this.btnSelectOldFile_1);
            this.tabPage1.Controls.Add(this.btnGenPatch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(475, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "创建增量文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbSaveFileName1
            // 
            this.tbSaveFileName1.Location = new System.Drawing.Point(5, 164);
            this.tbSaveFileName1.Name = "tbSaveFileName1";
            this.tbSaveFileName1.Size = new System.Drawing.Size(365, 21);
            this.tbSaveFileName1.TabIndex = 13;
            // 
            // btnSelectSaveFile_1
            // 
            this.btnSelectSaveFile_1.Location = new System.Drawing.Point(379, 158);
            this.btnSelectSaveFile_1.Name = "btnSelectSaveFile_1";
            this.btnSelectSaveFile_1.Size = new System.Drawing.Size(88, 31);
            this.btnSelectSaveFile_1.TabIndex = 12;
            this.btnSelectSaveFile_1.Text = "输出路径";
            this.btnSelectSaveFile_1.UseVisualStyleBackColor = true;
            this.btnSelectSaveFile_1.Click += new System.EventHandler(this.btnSelectSaveFile_Click);
            // 
            // tbNewFileName_1
            // 
            this.tbNewFileName_1.Location = new System.Drawing.Point(6, 117);
            this.tbNewFileName_1.Name = "tbNewFileName_1";
            this.tbNewFileName_1.Size = new System.Drawing.Size(365, 21);
            this.tbNewFileName_1.TabIndex = 11;
            // 
            // tbOldFileName_1
            // 
            this.tbOldFileName_1.Location = new System.Drawing.Point(6, 68);
            this.tbOldFileName_1.Name = "tbOldFileName_1";
            this.tbOldFileName_1.Size = new System.Drawing.Size(368, 21);
            this.tbOldFileName_1.TabIndex = 10;
            // 
            // btnSelectNewFile_1
            // 
            this.btnSelectNewFile_1.Location = new System.Drawing.Point(380, 111);
            this.btnSelectNewFile_1.Name = "btnSelectNewFile_1";
            this.btnSelectNewFile_1.Size = new System.Drawing.Size(88, 31);
            this.btnSelectNewFile_1.TabIndex = 9;
            this.btnSelectNewFile_1.Text = "选择新文件";
            this.btnSelectNewFile_1.UseVisualStyleBackColor = true;
            this.btnSelectNewFile_1.Click += new System.EventHandler(this.btnSelectNewFile_Click);
            // 
            // btnSelectOldFile_1
            // 
            this.btnSelectOldFile_1.Location = new System.Drawing.Point(380, 61);
            this.btnSelectOldFile_1.Name = "btnSelectOldFile_1";
            this.btnSelectOldFile_1.Size = new System.Drawing.Size(88, 33);
            this.btnSelectOldFile_1.TabIndex = 8;
            this.btnSelectOldFile_1.Text = "选择目标文件";
            this.btnSelectOldFile_1.UseVisualStyleBackColor = true;
            this.btnSelectOldFile_1.Click += new System.EventHandler(this.btnSelectOldFile_Click);
            // 
            // btnGenPatch
            // 
            this.btnGenPatch.Location = new System.Drawing.Point(156, 217);
            this.btnGenPatch.Name = "btnGenPatch";
            this.btnGenPatch.Size = new System.Drawing.Size(121, 32);
            this.btnGenPatch.TabIndex = 7;
            this.btnGenPatch.Text = "生成增量包";
            this.btnGenPatch.UseVisualStyleBackColor = true;
            this.btnGenPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbSaveFileName2);
            this.tabPage2.Controls.Add(this.btnSelectSaveFile_2);
            this.tabPage2.Controls.Add(this.tbNewFileName_2);
            this.tabPage2.Controls.Add(this.tbOldFileName_2);
            this.tabPage2.Controls.Add(this.btnSelectFile_2);
            this.tabPage2.Controls.Add(this.btnSelectOldFile_2);
            this.tabPage2.Controls.Add(this.btnApplyPatch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(475, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "应用增量文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSaveFileName2
            // 
            this.tbSaveFileName2.Location = new System.Drawing.Point(6, 164);
            this.tbSaveFileName2.Name = "tbSaveFileName2";
            this.tbSaveFileName2.Size = new System.Drawing.Size(365, 21);
            this.tbSaveFileName2.TabIndex = 18;
            // 
            // btnSelectSaveFile_2
            // 
            this.btnSelectSaveFile_2.Location = new System.Drawing.Point(380, 158);
            this.btnSelectSaveFile_2.Name = "btnSelectSaveFile_2";
            this.btnSelectSaveFile_2.Size = new System.Drawing.Size(88, 31);
            this.btnSelectSaveFile_2.TabIndex = 17;
            this.btnSelectSaveFile_2.Text = "输出路径";
            this.btnSelectSaveFile_2.UseVisualStyleBackColor = true;
            this.btnSelectSaveFile_2.Click += new System.EventHandler(this.btnSelectSaveFile_Click);
            // 
            // tbNewFileName_2
            // 
            this.tbNewFileName_2.Location = new System.Drawing.Point(6, 116);
            this.tbNewFileName_2.Name = "tbNewFileName_2";
            this.tbNewFileName_2.Size = new System.Drawing.Size(365, 21);
            this.tbNewFileName_2.TabIndex = 16;
            // 
            // tbOldFileName_2
            // 
            this.tbOldFileName_2.Location = new System.Drawing.Point(6, 67);
            this.tbOldFileName_2.Name = "tbOldFileName_2";
            this.tbOldFileName_2.Size = new System.Drawing.Size(368, 21);
            this.tbOldFileName_2.TabIndex = 15;
            // 
            // btnSelectFile_2
            // 
            this.btnSelectFile_2.Location = new System.Drawing.Point(380, 110);
            this.btnSelectFile_2.Name = "btnSelectFile_2";
            this.btnSelectFile_2.Size = new System.Drawing.Size(88, 31);
            this.btnSelectFile_2.TabIndex = 14;
            this.btnSelectFile_2.Text = "选择增量包";
            this.btnSelectFile_2.UseVisualStyleBackColor = true;
            this.btnSelectFile_2.Click += new System.EventHandler(this.btnSelectNewFile_Click);
            // 
            // btnSelectOldFile_2
            // 
            this.btnSelectOldFile_2.Location = new System.Drawing.Point(380, 60);
            this.btnSelectOldFile_2.Name = "btnSelectOldFile_2";
            this.btnSelectOldFile_2.Size = new System.Drawing.Size(88, 33);
            this.btnSelectOldFile_2.TabIndex = 13;
            this.btnSelectOldFile_2.Text = "选择目标文件";
            this.btnSelectOldFile_2.UseVisualStyleBackColor = true;
            this.btnSelectOldFile_2.Click += new System.EventHandler(this.btnSelectOldFile_Click);
            // 
            // btnApplyPatch
            // 
            this.btnApplyPatch.Location = new System.Drawing.Point(156, 214);
            this.btnApplyPatch.Name = "btnApplyPatch";
            this.btnApplyPatch.Size = new System.Drawing.Size(121, 32);
            this.btnApplyPatch.TabIndex = 12;
            this.btnApplyPatch.Text = "应用增量包";
            this.btnApplyPatch.UseVisualStyleBackColor = true;
            this.btnApplyPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.linkLabel2);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(475, 316);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(384, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "版本：1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(98, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "一款基于bsdiff4的增量文件生成及合成软件";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(219, 266);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(224, 14);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/crazycodeboy";
            this.linkLabel2.Click += new System.EventHandler(this.openWebSite);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(165, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "GitHub：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(218, 289);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(259, 14);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://blog.csdn.net/fengyuzhengfan/";
            this.linkLabel1.Click += new System.EventHandler(this.openWebSite);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(165, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Blog：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Author：CrazyCodeBoy";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 366);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "增量工具";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbNewFileName_1;
        private System.Windows.Forms.TextBox tbOldFileName_1;
        private System.Windows.Forms.Button btnSelectNewFile_1;
        private System.Windows.Forms.Button btnSelectOldFile_1;
        private System.Windows.Forms.Button btnGenPatch;
        private System.Windows.Forms.TextBox tbNewFileName_2;
        private System.Windows.Forms.TextBox tbOldFileName_2;
        private System.Windows.Forms.Button btnSelectFile_2;
        private System.Windows.Forms.Button btnSelectOldFile_2;
        private System.Windows.Forms.Button btnApplyPatch;
        private System.Windows.Forms.TextBox tbSaveFileName1;
        private System.Windows.Forms.Button btnSelectSaveFile_1;
        private System.Windows.Forms.TextBox tbSaveFileName2;
        private System.Windows.Forms.Button btnSelectSaveFile_2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

