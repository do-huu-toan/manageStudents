namespace ManageStudent
{
    partial class fTKB
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ViewClass = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_numberStudents = new System.Windows.Forms.Button();
            this.txt_numberStudents = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.cb_Thu = new System.Windows.Forms.ComboBox();
            this.cb_Teachers = new System.Windows.Forms.ComboBox();
            this.cb_Tiet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_EditClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Load = new System.Windows.Forms.Button();
            this.dtgrv_TKB = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrv_TKB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời Khóa Biểu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn lớp:";
            // 
            // cb_ViewClass
            // 
            this.cb_ViewClass.FormattingEnabled = true;
            this.cb_ViewClass.Location = new System.Drawing.Point(122, 58);
            this.cb_ViewClass.Name = "cb_ViewClass";
            this.cb_ViewClass.Size = new System.Drawing.Size(121, 21);
            this.cb_ViewClass.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 207);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_numberStudents);
            this.groupBox2.Controls.Add(this.txt_numberStudents);
            this.groupBox2.Controls.Add(this.btn_Update);
            this.groupBox2.Controls.Add(this.cb_Thu);
            this.groupBox2.Controls.Add(this.cb_Teachers);
            this.groupBox2.Controls.Add(this.cb_Tiet);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_EditClass);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(369, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 201);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chỉnh sửa";
            // 
            // btn_numberStudents
            // 
            this.btn_numberStudents.Location = new System.Drawing.Point(214, 153);
            this.btn_numberStudents.Name = "btn_numberStudents";
            this.btn_numberStudents.Size = new System.Drawing.Size(75, 23);
            this.btn_numberStudents.TabIndex = 5;
            this.btn_numberStudents.Text = "Update";
            this.btn_numberStudents.UseVisualStyleBackColor = true;
            this.btn_numberStudents.Click += new System.EventHandler(this.Btn_numberStudents_Click);
            // 
            // txt_numberStudents
            // 
            this.txt_numberStudents.Location = new System.Drawing.Point(158, 155);
            this.txt_numberStudents.Name = "txt_numberStudents";
            this.txt_numberStudents.Size = new System.Drawing.Size(48, 20);
            this.txt_numberStudents.TabIndex = 4;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(151, 105);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 3;
            this.btn_Update.Text = "Cập nhật";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // cb_Thu
            // 
            this.cb_Thu.FormattingEnabled = true;
            this.cb_Thu.Location = new System.Drawing.Point(70, 66);
            this.cb_Thu.Name = "cb_Thu";
            this.cb_Thu.Size = new System.Drawing.Size(91, 21);
            this.cb_Thu.TabIndex = 2;
            // 
            // cb_Teachers
            // 
            this.cb_Teachers.FormattingEnabled = true;
            this.cb_Teachers.Location = new System.Drawing.Point(247, 63);
            this.cb_Teachers.Name = "cb_Teachers";
            this.cb_Teachers.Size = new System.Drawing.Size(92, 21);
            this.cb_Teachers.TabIndex = 2;
            // 
            // cb_Tiet
            // 
            this.cb_Tiet.FormattingEnabled = true;
            this.cb_Tiet.Location = new System.Drawing.Point(247, 36);
            this.cb_Tiet.Name = "cb_Tiet";
            this.cb_Tiet.Size = new System.Drawing.Size(92, 21);
            this.cb_Tiet.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 66);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Thày cô:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tổng số học sinh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Thứ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tiết:";
            // 
            // cb_EditClass
            // 
            this.cb_EditClass.FormattingEnabled = true;
            this.cb_EditClass.Location = new System.Drawing.Point(70, 36);
            this.cb_EditClass.Name = "cb_EditClass";
            this.cb_EditClass.Size = new System.Drawing.Size(91, 21);
            this.cb_EditClass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lớp:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Load);
            this.groupBox1.Controls.Add(this.cb_ViewClass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 201);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem";
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(142, 91);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 3;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // dtgrv_TKB
            // 
            this.dtgrv_TKB.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgrv_TKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrv_TKB.Location = new System.Drawing.Point(15, 284);
            this.dtgrv_TKB.Name = "dtgrv_TKB";
            this.dtgrv_TKB.Size = new System.Drawing.Size(731, 345);
            this.dtgrv_TKB.TabIndex = 4;
            // 
            // fTKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 641);
            this.Controls.Add(this.dtgrv_TKB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "fTKB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FTKB_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrv_TKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ViewClass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_EditClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.ComboBox cb_Thu;
        private System.Windows.Forms.ComboBox cb_Tiet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.DataGridView dtgrv_TKB;
        private System.Windows.Forms.ComboBox cb_Teachers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_numberStudents;
        private System.Windows.Forms.TextBox txt_numberStudents;
        private System.Windows.Forms.Label label7;
    }
}