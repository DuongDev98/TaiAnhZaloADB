namespace TaiAnhZaloADB
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.btnDung = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblThongBao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Location = new System.Drawing.Point(12, 12);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(90, 48);
            this.btnTaiAnh.TabIndex = 0;
            this.btnTaiAnh.Text = "Tải ảnh";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            // 
            // btnDung
            // 
            this.btnDung.Location = new System.Drawing.Point(107, 12);
            this.btnDung.Name = "btnDung";
            this.btnDung.Size = new System.Drawing.Size(90, 48);
            this.btnDung.TabIndex = 1;
            this.btnDung.Text = "Dừng";
            this.btnDung.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 67);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(547, 23);
            this.progressBar.TabIndex = 2;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(203, 30);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(74, 13);
            this.lblThongBao.TabIndex = 3;
            this.lblThongBao.Text = "THÔNG BÁO:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 125);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnDung);
            this.Controls.Add(this.btnTaiAnh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tải ảnh zalo";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.Button btnDung;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Label lblThongBao;
    }
}