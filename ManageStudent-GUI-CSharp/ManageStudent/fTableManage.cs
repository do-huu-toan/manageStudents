using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading;

//Thư viện gửi Mail
using System.Net;
using System.Net.Mail;

namespace ManageStudent
{
    public partial class fTableManage : Form
    {

        public fTableManage()
        {
            InitializeComponent();
            string[] Date = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
            cb_Date.DataSource = Date;


        }

        public static IFirebaseClient client;

        private void ChỉnhSửaThờiKhóaBiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAddTeacher Add = new fAddTeacher();
            this.Hide();
            Add.ShowDialog();
            this.Show();
        }

        private void ChỉnhSửaThờiKhóaBiểuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fTKB tkb = new fTKB();
            this.Hide();
            tkb.ShowDialog();
            this.Show();
        }

        private void FTableManage_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(fTKB.config);
            
        }

        private async void Btn_Class10A_Click(object sender, EventArgs e)
        {
            timer_Refrest.Enabled = false;
            btn_Class10A.BackColor = Color.AliceBlue;
            btn_Class10B.BackColor = Color.Transparent;
            lsv_LoadClass.Items.Clear();
            DateTime now = DateTime.Now;
            int isTime = now.TimeOfDay.Hours;
            //MessageBox.Show(isTime.ToString());
            int Thu = (int)now.DayOfWeek + 1;
            cb_Date.Text = "Thứ " + Thu;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/TKB/10A/Thứ " + Thu + "/Tiết " + i);
                    TKB Tiet = res.ResultAs<TKB>();
                    ListViewItem item;
                    string[] array = new string[3];
                    array[0] = Tiet.Tiet;
                    array[1] = Tiet.Mon;
                    array[2] = Tiet.Teacher;
                    item = new ListViewItem(array);
                    lsv_LoadClass.Items.Add(item);
                    Thread.Sleep(200);

                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra kết nối mạng", "Thông báo");

            }
            timer_Refrest.Enabled = true;
        }

        private async void Btn_Load_Click(object sender, EventArgs e)
        {
            timer_Refrest.Enabled = false;
            String lop = "";
            if (btn_Class10A.BackColor == Color.AliceBlue)
            {
                lop = "10A";
            }
            else if (btn_Class10B.BackColor == Color.AliceBlue)
            {
                lop = "10B";
            }
            else
            {
                MessageBox.Show("Hãy chọn lớp", "Thông báo", MessageBoxButtons.OK);
            }
            lsv_LoadClass.Items.Clear();
            DateTime now = DateTime.Now;
            String Thu = cb_Date.Text;
            if (lop != "")
            {
                try
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        try
                        {
                            FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/TKB/" + lop + "/" + Thu + "/Tiết " + i);
                            TKB Tiet = res.ResultAs<TKB>();
                            ListViewItem item;
                            string[] array = new string[3];
                            array[0] = Tiet.Tiet;
                            array[1] = Tiet.Mon;
                            array[2] = Tiet.Teacher;
                            item = new ListViewItem(array);
                            lsv_LoadClass.Items.Add(item);
                            Thread.Sleep(200);
                        }
                        catch
                        {
                            MessageBox.Show("Show hết rồi", "Thông báo", MessageBoxButtons.OK);
                            break;
                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Chưa có dữ liệu", "Thông báo");
                }
            }
            timer_Refrest.Enabled = true; ;

        }

        private async void Btn_Class10B_Click(object sender, EventArgs e)
        { 
            timer_Refrest.Enabled = false;
            btn_Class10B.BackColor = Color.AliceBlue;
            btn_Class10A.BackColor = Color.Transparent;
            lsv_LoadClass.Items.Clear();
            DateTime now = DateTime.Now;
            int isTime = now.TimeOfDay.Hours;
            //MessageBox.Show(isTime.ToString());
            int Thu = (int)now.DayOfWeek + 1;
            cb_Date.Text = "Thứ " + Thu;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/TKB/10B/Thứ " + Thu + "/Tiết " + i);
                    TKB Tiet = res.ResultAs<TKB>();
                    ListViewItem item;
                    string[] array = new string[3];
                    array[0] = Tiet.Tiet;
                    array[1] = Tiet.Mon;
                    array[2] = Tiet.Teacher;
                    item = new ListViewItem(array);
                    lsv_LoadClass.Items.Add(item);
                    Thread.Sleep(200);

                }
            }
            catch
            {
                MessageBox.Show("Chưa có dữ liệu", "Thông báo");

            }
            timer_Refrest.Enabled = true;
        }

        private void Btn_Class10C_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có dữ liệu", "Thông báo");
        }

        private void Btn_Class10D_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có dữ liệu", "Thông báo");
        }

        private void Btn_Class10E_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có dữ liệu", "Thông báo");
        }

        private void Btn_Class10G_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có dữ liệu", "Thông báo");
        }

        private async void Timer_Refrest_Tick(object sender, EventArgs e)
        {
            String lop = "";
            if (btn_Class10A.BackColor == Color.AliceBlue)
            {
                lop = "10A";
            }
            if (btn_Class10B.BackColor == Color.AliceBlue)
            {
                lop = "10B";
            }
            if (lop != "")
            {
                try
                {
                    FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/TKB/" + lop + "/numberStudents");
                    int numberOfStudents = res.ResultAs<int>();
                    FirebaseResponse res1 = await client.GetAsync(@"quanlygioday-ab237/TKB/" + lop + "/present");
                    int present = res1.ResultAs<int>();
                    lbl_numberOfMember.Text = present.ToString() + "/" + numberOfStudents.ToString();
                    FirebaseResponse res3 = await client.GetAsync(@"quanlygioday-ab237/TKB/" + lop + "/teacherOnClass");
                    String teacherInClass = res3.ResultAs<String>();
                    if (teacherInClass == "")
                    {
                        lbl_teacherInClass.Text = "Chưa có giáo viên";
                    }
                    else
                    {
                        lbl_teacherInClass.Text = teacherInClass;

                    }

                }
                catch
                {

                }
            }
            
        }
        
        
            

        private void ThờiGianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThoiGian t = new ThoiGian();
            this.Hide();
            t.ShowDialog();
            this.Show();
        }

        private void UpdateTKBExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTkbExcel fTKB = new fTkbExcel();
            this.Hide();
            fTKB.ShowDialog();
            this.Show();
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await client.GetAsync("/quanlygioday-ab237/TKB/10A/numberStudents");
            int count = res.ResultAs<int>();
            for(int i = 1;i<=count;i++)
            {
                res = await client.GetAsync("/quanlygioday-ab237/TKB/10A/Students/" + i.ToString() + "/Co_mat");
                bool coMat = res.ResultAs<bool>();
                if(coMat == false)
                {
                    res = await client.GetAsync("/quanlygioday-ab237/TKB/10A/Students/" + i.ToString() + "/Email");
                    String Email = res.ResultAs<String>();
                    GuiMail(admin, Email, "Thông báo", "Hôm nay cháu nghỉ học nha");
                }
            }
            MessageBox.Show("Gửi xong rồi");
        }

        string admin = "dohuutoannb@gmail.com";
        string password = "toantrang";

        void GuiMail(string from, string to, string subject, string message)
        {
            MailMessage mess = new MailMessage(from, to, subject, message);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(admin, password);
            client.Send(mess);
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
            FirebaseResponse resNew = await client.GetAsync(@"quanlygioday-ab237/TKB/10A/present");
            int hientai1 = resNew.ResultAs<int>();
            resNew = await client.GetAsync(@"quanlygioday-ab237/TKB/10A/numberStudents");
            int tongsiso1 = resNew.ResultAs<int>();
            if (hientai1 != tongsiso1 && btn_Class10A.BackColor != Color.AliceBlue)
            {
                btn_Class10A.BackColor = Color.Red;
            }
            if (hientai1 == tongsiso1 && btn_Class10A.BackColor != Color.AliceBlue)
            {
                btn_Class10A.BackColor = Color.Green;
            }
          
            resNew = await client.GetAsync(@"quanlygioday-ab237/TKB/10B/present");
            int hientai2 = resNew.ResultAs<int>();
            resNew = await client.GetAsync(@"quanlygioday-ab237/TKB/10B/numberStudents");
            int tongsiso2 = resNew.ResultAs<int>();
            if (hientai2 != tongsiso2 && btn_Class10B.BackColor != Color.AliceBlue)
            {
                btn_Class10B.BackColor = Color.Red;
            }
            if (hientai2 == tongsiso2 && btn_Class10B.BackColor != Color.AliceBlue)
            {
                btn_Class10B.BackColor = Color.Green;
            }
        }
    }
}
