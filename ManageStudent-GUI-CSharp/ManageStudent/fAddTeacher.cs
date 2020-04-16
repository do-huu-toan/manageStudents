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


namespace ManageStudent
{
    
    public partial class fAddTeacher : Form
    {
        #region Khởi tạo
        DataTable dt = new DataTable();
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "1ntE2kAqSA5OuMEomXoaaCNLZcrPypz8qJbtOp4L",
            BasePath = "https://quanlygioday-ab237.firebaseio.com/",
        };
        public static IFirebaseClient client;
        public fAddTeacher()
        {
            InitializeComponent();
            string[] boMon = { "Toán", "Lý", "Hóa", "Văn", "Sinh", "Sử", "Địa", "Giáo dục Công Dân", "Tin" };
            cb_boMon.DataSource = boMon; 
        }
        #endregion
        #region Form Load
        private void FAddTeacher_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if(client != null)
            {
                MessageBox.Show("Đã kết nối tới cơ sở dữ liệu");
            }
            dt.Columns.Add("ID");
            dt.Columns.Add("Họ và tên");
            dt.Columns.Add("Bộ môn");
            dt.Columns.Add("Số giờ dậy");
            dt.Columns.Add("Tên trong TKB");
            dtgrv_ShowTeacher.DataSource = dt;
            dtgrv_ShowTeacher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //LoadDataGridView();
        }
        #endregion
       
        #region Gửi Dữ Liệu
        //private async void Add()
        //{
        //    FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
        //    Counter countTeacher = res.ResultAs<Counter>();
        //    int cnt = countTeacher.count;
        //    cnt++;

        //    var giaovien = new giaoVien
        //    {
        //        ID = cnt,
        //        Name = txt_Name.Text,
        //        Mon = cb_boMon.Text,
        //    };

        //    SetResponse response = await client.SetAsync(@"quanlygioday-ab237/listTeacher/" + cnt, giaovien);
        //    giaoVien result = response.ResultAs<giaoVien>();
        //    MessageBox.Show("Đã thêm " + giaovien.Name);
        //    var counter = new Counter()
        //    {
        //        count = giaovien.ID
        //    };
        //    SetResponse reponse1 = await client.SetAsync(@"quanlygioday-ab237/listTeacher/Counter", counter);
        //}
        #endregion
        private void Btn_Del_Click(object sender, EventArgs e)
        {           
        }
        #region Xóa dữ liệu
        //private async void Del()
        //{
        //    FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
        //    Counter countTeacher = res.ResultAs<Counter>();
        //    int cnt = countTeacher.count;
        //    for (int i = 1; i <= cnt; i++)
        //    {
        //        FirebaseResponse res1 = await client.GetAsync(@"quanlygioday-ab237/listTeacher/" + i);
        //        giaoVien get = res1.ResultAs<giaoVien>();
        //        if (get.Name == txt_Name.Text)
        //        {
        //            FirebaseResponse del = await client.DeleteAsync(@"quanlygioday-ab237/listTeacher/" + get.ID);
        //            MessageBox.Show("Đã Xóa " + get.Name);
        //            var counter = new Counter()
        //            {
        //                count = (cnt - 1)
        //            };
        //            SetResponse reponse1 = await client.SetAsync(@"quanlygioday-ab237/listTeacher/Counter", counter);
        //        }
        //    }
        //}
        #endregion

        #region Đổ dữ liệu lên DataGridView
        private void Btn_Load_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private async void LoadDataGridView()
        {

            dt.Clear();
            FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
            Counter countTeacher = res.ResultAs<Counter>();
            int cnt = countTeacher.count;
            int i = 0;

            while (true)
            {
                if (i == cnt) break;
                i++;
                try
                {
                    FirebaseResponse resp = await client.GetAsync(@"quanlygioday-ab237/listTeacher/" + i);
                    giaoVien obj = resp.ResultAs<giaoVien>();

                    DataRow row = dt.NewRow();
                    row["ID"] = obj.ID;
                    row["Họ và tên"] = obj.Name;
                    row["Bộ môn"] = obj.Mon;
                    row["Số giờ dậy"] = obj.demGioDay;
                    row["Tên trong TKB"] = obj.NameInTKB;
                    dt.Rows.Add(row);
                }
                catch
                {


                }
            }
        }
        #endregion

        private async void Btn_Update_Click(object sender, EventArgs e)
        {

                //Lấy giá trị count từ Firebase lúc chưa Update
                FirebaseResponse res = await client.GetAsync(@"quanlygioday-ab237/listTeacher/Counter");
                Counter countTeacher = res.ResultAs<Counter>();
                int cnt = countTeacher.count;
                //String a = dtgrv_ShowTeacher.Rows[3].Cells[1].Value.ToString();
                int countRows = dt.Rows.Count;
            if (countRows ==0)
            {
                MessageBox.Show("Chưa Load dữ liệu Database ");
            }
            else
            {
                //giaoVien[] gv = new giaoVien[countRows];
                //txt_Name.Text = countRows.ToString() + " " + dtgrv_ShowTeacher.Rows[1].Cells[0].Value.ToString();

                for (int i = 0; i < countRows; i++)
                {

                    var giaovien = new giaoVien
                    {
                        ID = dtgrv_ShowTeacher.Rows[i].Cells[0].Value.ToString(),
                        Name = dtgrv_ShowTeacher.Rows[i].Cells[1].Value.ToString(),
                        Mon = dtgrv_ShowTeacher.Rows[i].Cells[2].Value.ToString(),
                        demGioDay = Convert.ToInt32(dtgrv_ShowTeacher.Rows[i].Cells[3].Value),
                        NameInTKB = dtgrv_ShowTeacher.Rows[i].Cells[4].Value.ToString(),
                    };
                    SetResponse response = await client.SetAsync(@"quanlygioday-ab237/listTeacher/" + giaovien.ID, giaovien);
                    giaoVien result = response.ResultAs<giaoVien>();
                }
                var counter = new Counter
                {
                    count = countRows
                };
                SetResponse reponse1 = await client.SetAsync(@"quanlygioday-ab237/listTeacher/Counter", counter);

                MessageBox.Show("counter = " + countRows.ToString() + " cnt = " + cnt.ToString());
                //Xóa những ID thừa sau khi cập nhật Database
                if(countRows < cnt)
                {
                    for (int i = countRows + 1; i <= cnt; i++)
                    {
                        FirebaseResponse del = await client.DeleteAsync(@"quanlygioday-ab237/listTeacher/" + i);
                    }
                }
                

                MessageBox.Show("Done", "Trạng thái");
                //LoadDataGridView();
                
            }

        }

      
        private void Dtgrv_ShowTeacher_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int countRows = dt.Rows.Count;
            for(int i = 0;i<countRows;i++)
            {
                dtgrv_ShowTeacher.Rows[i].Cells[0].Value = i+1;
            }
        }
    }
}
