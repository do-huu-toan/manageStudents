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
    public partial class ThoiGian : Form
    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "1ntE2kAqSA5OuMEomXoaaCNLZcrPypz8qJbtOp4L",
            BasePath = "https://quanlygioday-ab237.firebaseio.com/",
        };
        public static IFirebaseClient client;
        public ThoiGian()
        {
            InitializeComponent();
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            SetResponse response = await client.SetAsync(@"quanlygioday-ab237/Time/1/Start/Hours", Convert.ToInt32(numericUpDown1.Value)); ;
            int result = response.ResultAs<int>();
            SetResponse response1 = await client.SetAsync(@"quanlygioday-ab237/Time/1/Start/Minutes", Convert.ToInt32(numericUpDown2.Value)); ;
            int result1 = response.ResultAs<int>();
            SetResponse response2 = await client.SetAsync(@"quanlygioday-ab237/Time/1/End/Hours", Convert.ToInt32(numericUpDown3.Value)); ;
            int result2 = response.ResultAs<int>();
            SetResponse response3 = await client.SetAsync(@"quanlygioday-ab237/Time/1/End/Minutes", Convert.ToInt32(numericUpDown4.Value)); ;
            int result3 = response.ResultAs<int>();

            SetResponse response4 = await client.SetAsync(@"quanlygioday-ab237/Time/2/Start/Hours", Convert.ToInt32(numericUpDown8.Value)); ;
            int result4 = response.ResultAs<int>();
            SetResponse response5 = await client.SetAsync(@"quanlygioday-ab237/Time/2/Start/Minutes", Convert.ToInt32(numericUpDown7.Value)); ;
            int result5= response.ResultAs<int>();
            SetResponse response6 = await client.SetAsync(@"quanlygioday-ab237/Time/2/End/Hours", Convert.ToInt32(numericUpDown5.Value)); ;
            int result6 = response.ResultAs<int>();
            SetResponse response7 = await client.SetAsync(@"quanlygioday-ab237/Time/2/End/Minutes", Convert.ToInt32(numericUpDown6.Value)); ;
            int result7 = response.ResultAs<int>();

            SetResponse response8 = await client.SetAsync(@"quanlygioday-ab237/Time/3/Start/Hours", Convert.ToInt32(numericUpDown12.Value)); ;
            int result8 = response.ResultAs<int>();
            SetResponse response9 = await client.SetAsync(@"quanlygioday-ab237/Time/3/Start/Minutes", Convert.ToInt32(numericUpDown11.Value)); ;
            int result9 = response.ResultAs<int>();
            SetResponse response10 = await client.SetAsync(@"quanlygioday-ab237/Time/3/End/Hours", Convert.ToInt32(numericUpDown9.Value)); ;
            int result10 = response.ResultAs<int>();
            SetResponse response11 = await client.SetAsync(@"quanlygioday-ab237/Time/3/End/Minutes", Convert.ToInt32(numericUpDown10.Value)); ;
            int result11 = response.ResultAs<int>();

            SetResponse response12 = await client.SetAsync(@"quanlygioday-ab237/Time/4/Start/Hours", Convert.ToInt32(numericUpDown20.Value)); ;
            int result12 = response.ResultAs<int>();
            SetResponse response13 = await client.SetAsync(@"quanlygioday-ab237/Time/4/Start/Minutes", Convert.ToInt32(numericUpDown19.Value)); ;
            int result13 = response.ResultAs<int>();
            SetResponse response14 = await client.SetAsync(@"quanlygioday-ab237/Time/4/End/Hours", Convert.ToInt32(numericUpDown17.Value)); ;
            int result14 = response.ResultAs<int>();
            SetResponse response15 = await client.SetAsync(@"quanlygioday-ab237/Time/4/End/Minutes", Convert.ToInt32(numericUpDown18.Value)); ;
            int result15 = response.ResultAs<int>();

            SetResponse response16 = await client.SetAsync(@"quanlygioday-ab237/Time/5/Start/Hours", Convert.ToInt32(numericUpDown16.Value)); ;
            int result16 = response.ResultAs<int>();
            SetResponse response17 = await client.SetAsync(@"quanlygioday-ab237/Time/5/Start/Minutes", Convert.ToInt32(numericUpDown15.Value)); ;
            int result17 = response.ResultAs<int>();
            SetResponse response18 = await client.SetAsync(@"quanlygioday-ab237/Time/5/End/Hours", Convert.ToInt32(numericUpDown13.Value)); ;
            int result18 = response.ResultAs<int>();
            SetResponse response19 = await client.SetAsync(@"quanlygioday-ab237/Time/5/End/Minutes", Convert.ToInt32(numericUpDown14.Value)); ;
            int result19 = response.ResultAs<int>();
            MessageBox.Show("Đã Lưu");
        }

        private async void ThoiGian_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Đã kết nối tới cơ sở dữ liệu, đợi Loading");
            }
            FirebaseResponse get1 = await client.GetAsync(@"quanlygioday-ab237/Time/1/Start/Hours");
            numericUpDown1.Value = get1.ResultAs<int>();
            FirebaseResponse get2 = await client.GetAsync(@"quanlygioday-ab237/Time/1/Start/Minutes");
            numericUpDown2.Value = get2.ResultAs<int>();
            FirebaseResponse get3 = await client.GetAsync(@"quanlygioday-ab237/Time/1/End/Hours");
            numericUpDown3.Value = get3.ResultAs<int>();
            FirebaseResponse get4 = await client.GetAsync(@"quanlygioday-ab237/Time/1/End/Minutes");
            numericUpDown4.Value = get4.ResultAs<int>();
            FirebaseResponse get5 = await client.GetAsync(@"quanlygioday-ab237/Time/2/Start/Hours");
            numericUpDown8.Value = get5.ResultAs<int>();
            FirebaseResponse get6 = await client.GetAsync(@"quanlygioday-ab237/Time/2/Start/Minutes");
            numericUpDown7.Value = get6.ResultAs<int>();
            FirebaseResponse get7 = await client.GetAsync(@"quanlygioday-ab237/Time/2/End/Hours");
            numericUpDown5.Value = get7.ResultAs<int>();
            FirebaseResponse get8 = await client.GetAsync(@"quanlygioday-ab237/Time/2/End/Minutes");
            numericUpDown6.Value = get8.ResultAs<int>();
            FirebaseResponse get9 = await client.GetAsync(@"quanlygioday-ab237/Time/3/Start/Hours");
            numericUpDown12.Value = get9.ResultAs<int>();
            FirebaseResponse get10 = await client.GetAsync(@"quanlygioday-ab237/Time/3/Start/Minutes");
            numericUpDown11.Value = get10.ResultAs<int>();
            FirebaseResponse get11 = await client.GetAsync(@"quanlygioday-ab237/Time/3/End/Hours");
            numericUpDown9.Value = get11.ResultAs<int>();
            FirebaseResponse get12 = await client.GetAsync(@"quanlygioday-ab237/Time/3/End/Minutes");
            numericUpDown10.Value = get12.ResultAs<int>();
            FirebaseResponse get13 = await client.GetAsync(@"quanlygioday-ab237/Time/4/Start/Hours");
            numericUpDown20.Value = get13.ResultAs<int>();
            FirebaseResponse get14 = await client.GetAsync(@"quanlygioday-ab237/Time/4/Start/Minutes");
            numericUpDown19.Value = get14.ResultAs<int>();
            FirebaseResponse get15 = await client.GetAsync(@"quanlygioday-ab237/Time/4/End/Hours");
            numericUpDown17.Value = get15.ResultAs<int>();
            FirebaseResponse get16 = await client.GetAsync(@"quanlygioday-ab237/Time/4/End/Minutes");
            numericUpDown18.Value = get16.ResultAs<int>();
            FirebaseResponse get17 = await client.GetAsync(@"quanlygioday-ab237/Time/5/Start/Hours");
            numericUpDown16.Value = get17.ResultAs<int>();
            FirebaseResponse get18 = await client.GetAsync(@"quanlygioday-ab237/Time/5/Start/Minutes");
            numericUpDown15.Value = get18.ResultAs<int>();
            FirebaseResponse get19 = await client.GetAsync(@"quanlygioday-ab237/Time/5/End/Hours");
            numericUpDown13.Value = get19.ResultAs<int>();
            FirebaseResponse get20 = await client.GetAsync(@"quanlygioday-ab237/Time/5/End/Minutes");
            numericUpDown14.Value = get20.ResultAs<int>();
            MessageBox.Show("Đã load xong");
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
