namespace Hex2Bin
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHexFile = new System.Windows.Forms.TextBox();
            this.lblTips01 = new System.Windows.Forms.Label();
            this.txtBinFile = new System.Windows.Forms.TextBox();
            this.lblTips02 = new System.Windows.Forms.Label();
            this.fileDataShow = new System.Windows.Forms.ListBox();
            this.lblTips03 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHexFile
            // 
            this.txtHexFile.Location = new System.Drawing.Point(12, 82);
            this.txtHexFile.Name = "txtHexFile";
            this.txtHexFile.Size = new System.Drawing.Size(533, 21);
            this.txtHexFile.TabIndex = 0;
            this.txtHexFile.DoubleClick += new System.EventHandler(this.txtHexFile_DoubleClick);
            // 
            // lblTips01
            // 
            this.lblTips01.AutoSize = true;
            this.lblTips01.Location = new System.Drawing.Point(12, 67);
            this.lblTips01.Name = "lblTips01";
            this.lblTips01.Size = new System.Drawing.Size(125, 12);
            this.lblTips01.TabIndex = 1;
            this.lblTips01.Text = "选择一个Hex源文件...";
            // 
            // txtBinFile
            // 
            this.txtBinFile.Location = new System.Drawing.Point(14, 134);
            this.txtBinFile.Name = "txtBinFile";
            this.txtBinFile.Size = new System.Drawing.Size(533, 21);
            this.txtBinFile.TabIndex = 2;
            // 
            // lblTips02
            // 
            this.lblTips02.AutoSize = true;
            this.lblTips02.Location = new System.Drawing.Point(14, 119);
            this.lblTips02.Name = "lblTips02";
            this.lblTips02.Size = new System.Drawing.Size(83, 12);
            this.lblTips02.TabIndex = 3;
            this.lblTips02.Text = "输出的Bin文件";
            // 
            // fileDataShow
            // 
            this.fileDataShow.FormattingEnabled = true;
            this.fileDataShow.ItemHeight = 12;
            this.fileDataShow.Location = new System.Drawing.Point(18, 201);
            this.fileDataShow.Name = "fileDataShow";
            this.fileDataShow.Size = new System.Drawing.Size(528, 508);
            this.fileDataShow.TabIndex = 4;
            // 
            // lblTips03
            // 
            this.lblTips03.AutoSize = true;
            this.lblTips03.Location = new System.Drawing.Point(16, 186);
            this.lblTips03.Name = "lblTips03";
            this.lblTips03.Size = new System.Drawing.Size(95, 12);
            this.lblTips03.TabIndex = 5;
            this.lblTips03.Text = "Bin文件内容预览";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(7, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 28);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Hex2Bin Helper";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 712);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTips03);
            this.Controls.Add(this.fileDataShow);
            this.Controls.Add(this.lblTips02);
            this.Controls.Add(this.txtBinFile);
            this.Controls.Add(this.lblTips01);
            this.Controls.Add(this.txtHexFile);
            this.Name = "MainForm";
            this.Text = "Hex2Bin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHexFile;
        private System.Windows.Forms.Label lblTips01;
        private System.Windows.Forms.TextBox txtBinFile;
        private System.Windows.Forms.Label lblTips02;
        private System.Windows.Forms.ListBox fileDataShow;
        private System.Windows.Forms.Label lblTips03;
        private System.Windows.Forms.Label lblTitle;
    }
}

