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

namespace ManageStudent
{

    public partial class fTKB : Form
    {
        DataTable dt = new DataTable();
        #region Khởi tạo Firebase
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "1ntE2kAqSA5OuMEomXoaaCNLZcrPypz8qJbtOp4L",
            BasePath = "https://quanlygioday-ab237.firebaseio.com/",
        };
        public static IFirebaseClient client;
        #endregion
        public fTKB()
        {
            InitializeComponent();
            string[] lop = { "10A", "10B", "10C", "10D", "10E", "10G" };
            cb_ViewClass.DataSource = lop;
            cb_EditClass.DataSource = lop;
            string[] Date = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
            cb_Thu.DataSource = Date;
            string[] Tiet = { "Tiết 1", "Tiết 2", "Tiết 3", "Tiết 4", "Tiết 5" };
            cb_Tiet.DataSource = Tiet;
            
        }

        private async void FTKB_Load(object sender, EventArgs e)
        {
           
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Đã kết nối tới cơ sở dữ liệu");
            }
           else
            {
                return;
            }
            FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
            Counter countTeacher = res.ResultAs<Counter>();
            int cnt = countTeacher.count;

            string[] Name_Teachers = new string[cnt];
            for(int i = 0;i<cnt;i++)
            {
                try
                {
                    FirebaseResponse resp = await client.GetAsync(@"quanlygioday-ab237/listTeacher/" + (i+1));
                    giaoVien obj = resp.ResultAs<giaoVien>();
                    Name_Teachers[i] = obj.Name;
                }
                catch
                {


                }
            }
            cb_Teachers.DataSource = Name_Teachers;

            dt.Columns.Add("Thứ");
            dt.Columns.Add("Tiết");
            dt.Columns.Add("Thày/cô");
            dt.Columns.Add("Môn học");
            //dt.Columns.Add("Tổng số học sinh");
            dtgrv_TKB.DataSource = dt;
            dtgrv_TKB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MessageBox.Show("Đã load xong");
        }
        
        private async void Btn_Update_Click(object sender, EventArgs e)
        {
            string boMon = "";
            FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
            Counter countTeacher = res.ResultAs<Counter>();
            int cnt = countTeacher.count;
            for (int i = 0; i < cnt; i++)
            {
                try
                {
                    FirebaseResponse resp = await client.GetAsync(@"quanlygioday-ab237/listTeacher/" + (i + 1));
                    giaoVien obj = resp.ResultAs<giaoVien>();
                    if (obj.Name == cb_Teachers.Text)
                    {
                        boMon = obj.Mon;
                        break;
                    }
                }
                catch
                {

                }
            }
            var tkb = new TKB
            {
                Mon = boMon,
                Thu = cb_Thu.Text,
                Tiet = cb_Tiet.Text,
                Teacher = cb_Teachers.Text,
            };
            SetResponse set = await client.SetAsync(@"quanlygioday-ab237/TKB/" + cb_EditClass.Text +"/"+ tkb.Thu + "/" + tkb.Tiet, tkb);
            TKB result = set.ResultAs<TKB>();

            MessageBox.Show("Done", "Trạng thái");
        }

        private async void Btn_numberStudents_Click(object sender, EventArgs e)
        {
            int numberStudents;
            bool result = int.TryParse(txt_numberStudents.Text, out numberStudents);
            if (result != true || cb_EditClass.Text == "")
            {
                MessageBox.Show("Sĩ số lớp phải nhập số nguyên và Phải chọn lớp", "Lỗi");
            }
            else
            {
                SetResponse set = await client.SetAsync(@"quanlygioday-ab237/TKB/" + cb_EditClass.Text + "/numberStudents", numberStudents);
            }
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {
            if (cb_ViewClass.Text == "")
            {
                MessageBox.Show("Hãy chọn lớp", "Thông báo");
            }
            else
            {
                LoadDataGridView();
            }
        }
        private async void LoadDataGridView()
        {

            dt.Clear();

            for (int i = 2; i <= 7; i++)
            {
                for(int j = 1;j<=5;j++)
                {
                    try
                    {
                        FirebaseResponse resp = await client.GetAsync(@"quanlygioday-ab237/TKB/" + cb_ViewClass.Text + "/Thứ " + i + "/Tiết " + j);
                        TKB obj = resp.ResultAs<TKB>();
                        DataRow row = dt.NewRow();
                        row["Thứ"] = obj.Thu;
                        row["Tiết"] = obj.Tiet;
                        row["Thày/cô"] = obj.Teacher;
                        row["Môn học"] = obj.Mon;
                        dt.Rows.Add(row);
                    }
                    catch { }
                }
                DataRow rowSpace = dt.NewRow();
                dt.Rows.Add(rowSpace);

            }



        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
