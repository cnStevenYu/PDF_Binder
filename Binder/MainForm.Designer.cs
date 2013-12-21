namespace Binder
{
    partial class BinderForm
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
            this.lbl_exe = new System.Windows.Forms.Label();
            this.txtBx_exe = new System.Windows.Forms.TextBox();
            this.txtBx_pdf = new System.Windows.Forms.TextBox();
            this.btn_exe = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.lbl_pdf = new System.Windows.Forms.Label();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_exe
            // 
            this.lbl_exe.AutoSize = true;
            this.lbl_exe.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_exe.Location = new System.Drawing.Point(67, 32);
            this.lbl_exe.Name = "lbl_exe";
            this.lbl_exe.Size = new System.Drawing.Size(173, 19);
            this.lbl_exe.TabIndex = 0;
            this.lbl_exe.Text = "选择要捆绑的EXE文件：";
            // 
            // txtBx_exe
            // 
            this.txtBx_exe.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBx_exe.Location = new System.Drawing.Point(43, 68);
            this.txtBx_exe.Name = "txtBx_exe";
            this.txtBx_exe.Size = new System.Drawing.Size(449, 26);
            this.txtBx_exe.TabIndex = 2;
            // 
            // txtBx_pdf
            // 
            this.txtBx_pdf.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBx_pdf.Location = new System.Drawing.Point(43, 153);
            this.txtBx_pdf.Name = "txtBx_pdf";
            this.txtBx_pdf.Size = new System.Drawing.Size(449, 26);
            this.txtBx_pdf.TabIndex = 3;
            // 
            // btn_exe
            // 
            this.btn_exe.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exe.Location = new System.Drawing.Point(322, 22);
            this.btn_exe.Name = "btn_exe";
            this.btn_exe.Size = new System.Drawing.Size(116, 29);
            this.btn_exe.TabIndex = 4;
            this.btn_exe.Text = "选择EXE文件";
            this.btn_exe.UseVisualStyleBackColor = true;
            this.btn_exe.Click += new System.EventHandler(this.btn_EXE_Click);
            // 
            // btn_create
            // 
            this.btn_create.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_create.Location = new System.Drawing.Point(71, 207);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 42);
            this.btn_create.TabIndex = 6;
            this.btn_create.Text = "生成";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // lbl_pdf
            // 
            this.lbl_pdf.AutoSize = true;
            this.lbl_pdf.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_pdf.Location = new System.Drawing.Point(67, 117);
            this.lbl_pdf.Name = "lbl_pdf";
            this.lbl_pdf.Size = new System.Drawing.Size(174, 19);
            this.lbl_pdf.TabIndex = 7;
            this.lbl_pdf.Text = "选择要捆绑的PDF文件：";
            // 
            // btn_pdf
            // 
            this.btn_pdf.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pdf.Location = new System.Drawing.Point(322, 107);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(116, 29);
            this.btn_pdf.TabIndex = 8;
            this.btn_pdf.Text = "选择PDF文件";
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // BinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 278);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.lbl_pdf);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btn_exe);
            this.Controls.Add(this.txtBx_pdf);
            this.Controls.Add(this.txtBx_exe);
            this.Controls.Add(this.lbl_exe);
            this.Name = "BinderForm";
            this.Text = "捆绑器";
            this.Load += new System.EventHandler(this.BinderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_exe;
        private System.Windows.Forms.TextBox txtBx_exe;
        private System.Windows.Forms.TextBox txtBx_pdf;
        private System.Windows.Forms.Button btn_exe;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label lbl_pdf;
        private System.Windows.Forms.Button btn_pdf;
    }
}

