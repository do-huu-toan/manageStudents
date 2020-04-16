using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace ManageStudent
{
    public partial class fTkbExcel : Form
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public fTkbExcel()
        {
            InitializeComponent();
        }
        public static IFirebaseClient client;
        private void Btn_ChonTKB_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel File (*.xls)|*.xls|Excel File (*xlsx)|*.xlsx|All files (*.*)|*.*";
            if(openFile.ShowDialog() ==  DialogResult.OK)
            {
                path = openFile.FileName;
            }
            lbl_PathExcel.Text = path;

        }

        private async void Btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                wb = excel.Workbooks.Open(lbl_PathExcel.Text);
                ws = excel.Worksheets[1];
                //string data = ws.Cells[2][4].Value2;


                for (int i = 1; i <= 30; i++)
                {
                    string _Mon10A = ""; string _Mon10B = "";
                    string GV10A = ""; string GV10B = "";
                    string data10A = ws.Cells[2][i].Value2.ToString();
                    string data10B = ws.Cells[3][i].Value2.ToString();
                    //10A
                    if (data10A.IndexOf("-") == -1) _Mon10A = data10A;
                    else bocTachData(ws.Cells[2][i].Value2.ToString(), ref _Mon10A, ref GV10A);
                    //10B
                    if (data10B.IndexOf("-") == -1) _Mon10B = data10B;
                    else bocTachData(ws.Cells[3][i].Value2.ToString(), ref _Mon10B, ref GV10B);

                    string path10A = @"/quanlygioday-ab237/TKB/10A/";
                    string path10B = @"/quanlygioday-ab237/TKB/10B/";

                    int Day = Convert.ToInt32((i - 1) / 5 + 2);
                    string _Thu = ("Thứ ").ToString() + Day.ToString();
                    int t = Convert.ToInt32((i - 1) % 5 + 1);
                    string _Tiet = ("Tiết ").ToString() + t.ToString();
                    var tkb10A = new TKB
                    {
                        Mon = _Mon10A,
                        Thu = _Thu,
                        Tiet = _Tiet,
                        Teacher = GV10A,
                    };
                    var tkb10B = new TKB
                    {
                        Mon = _Mon10B,
                        Thu = _Thu,
                        Tiet = _Tiet,
                        Teacher = GV10B,
                    };
                    path10A = path10A + _Thu + "/" + _Tiet;
                    lbl_Loading.Text = path10A;
                    SetResponse set10A = await client.SetAsync(path10A, tkb10A);
                    path10B = path10B + _Thu + "/" + _Tiet;
                    lbl_Loading.Text = path10B;
                    SetResponse set10B = await client.SetAsync(path10B, tkb10B);
                }
                lbl_Loading.Text = "Done";
                MessageBox.Show("Done");
                excel.Quit();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý");
            }
            
        }
        void bocTachData(string cell,ref string Mon, ref string GV)
        {
            int viTriGachNgang = cell.IndexOf("-");
            for(int i = 0;i< viTriGachNgang - 1;i++)
            {
                Mon += cell[i];
            }
            for(int i = viTriGachNgang + 2;i<cell.Length;i++)
            {
                GV += cell[i];
            }
        }

        private void FTkbExcel_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(fTKB.config);
            if (client != null)
            {
                MessageBox.Show("Đã kết nối tới cơ sở dữ liệu");
            }
        }

       
    }
}
