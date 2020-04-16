namespace ManageStudent
{
    partial class fTkbExcel
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
            this.btn_FormTKB = new System.Windows.Forms.Button();
            this.btn_ChonTKB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_PathExcel = new System.Windows.Forms.Label();
            this.btn_Get = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_FormTKB
            // 
            this.btn_FormTKB.Location = new System.Drawing.Point(275, 44);
            this.btn_FormTKB.Name = "btn_FormTKB";
            this.btn_FormTKB.Size = new System.Drawing.Size(192, 53);
            this.btn_FormTKB.TabIndex = 0;
            this.btn_FormTKB.Text = "Form TKB mẫu";
            this.btn_FormTKB.UseVisualStyleBackColor = true;
            // 
            // btn_ChonTKB
            // 
            this.btn_ChonTKB.Location = new System.Drawing.Point(275, 124);
            this.btn_ChonTKB.Name = "btn_ChonTKB";
            this.btn_ChonTKB.Size = new System.Drawing.Size(192, 53);
            this.btn_ChonTKB.TabIndex = 0;
            this.btn_ChonTKB.Text = "Chọn đường dẫn đến TKB";
            this.btn_ChonTKB.UseVisualStyleBackColor = true;
            this.btn_ChonTKB.Click += new System.EventHandler(this.Btn_ChonTKB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đường dẫn:";
            // 
            // lbl_PathExcel
            // 
            this.lbl_PathExcel.AutoSize = true;
            this.lbl_PathExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PathExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_PathExcel.Location = new System.Drawing.Point(342, 196);
            this.lbl_PathExcel.Name = "lbl_PathExcel";
            this.lbl_PathExcel.Size = new System.Drawing.Size(0, 13);
            this.lbl_PathExcel.TabIndex = 2;
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(336, 286);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(63, 38);
            this.btn_Get.TabIndex = 3;
            this.btn_Get.Text = "GET";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.Btn_Get_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đang Load:";
            // 
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Loading.Location = new System.Drawing.Point(345, 224);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(0, 13);
            this.lbl_Loading.TabIndex = 4;
            // 
            // fTkbExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 336);
            this.Controls.Add(this.lbl_Loading);
            this.Controls.Add(this.btn_Get);
            this.Controls.Add(this.lbl_PathExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ChonTKB);
            this.Controls.Add(this.btn_FormTKB);
            this.Name = "fTkbExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTkbExcel";
            this.Load += new System.EventHandler(this.FTkbExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_FormTKB;
        private System.Windows.Forms.Button btn_ChonTKB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_PathExcel;
        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Loading;
    }
}