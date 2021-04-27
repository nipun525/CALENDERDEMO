using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace CALENDERDEMO
{
    public partial class Form1 : Form
    {
        string G_YEAR;
        string G_MONTH;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthElllipse,
                int nHeightElllipse
            );

        List<Button> DateList = new List<Button>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //DateTime myDate = DateTime.Now;
                //int year = myDate.Year; // 2015  
                //int month = myDate.Month; //12  
                //int day = myDate.Day; // 25  
                //int hour = myDate.Hour; // 10  
                //int minute = myDate.Minute; // 30  
                //int second = myDate.Second; // 45  
                //int weekDay = (int)myDate.DayOfWeek; // 5 due to Friday

                //string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                //foreach (string m in monthNames) // writing out
                //{
                //    MessageBox.Show(m);
                //    //Console.WriteLine(m);
                //}

                List<Label> DateList = new List<Label>();

                //DateList.Add(label7);
                //DateList.Add(label8);
                //DateList.Add(label9);
                //DateList.Add(label10);
                //DateList.Add(label11);
                //DateList.Add(label12);
                //DateList.Add(label13);

                //DateList.Add(label14);
                //DateList.Add(label15);
                //DateList.Add(label16);
                //DateList.Add(label17);
                //DateList.Add(label18);
                //DateList.Add(label19);
                //DateList.Add(label20);

                //DateList.Add(label21);
                //DateList.Add(label22);
                //DateList.Add(label23);
                //DateList.Add(label24);
                //DateList.Add(label25);
                //DateList.Add(label26);
                //DateList.Add(label27);

                //DateList.Add(label28);
                //DateList.Add(label29);
                //DateList.Add(label30);
                //DateList.Add(label31);
                //DateList.Add(label32);
                //DateList.Add(label33);
                //DateList.Add(label34);

                //DateList.Add(label35);
                //DateList.Add(label36);
                //DateList.Add(label37);
                //DateList.Add(label38);
                //DateList.Add(label39);
                //DateList.Add(label40);
                //DateList.Add(label41);

                for (int i = 1; i < 32; i++)
                {
                    string date = i.ToString().PadLeft(2, '0');
                    DateList[i-1].Text = date;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //foreach (var item in DateList)
                //{
                //    item.Text = "";
                //}

                GENERATE_CALENDER(2050,03);

                //DateTime date2 = DateTime.Now.AddDays(2);
                //string _day = date2.ToString("dddd");
                //var firstDayOfMonth = new DateTime(date2.Year, date2.Month, 1);
                //var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GENERATE_CALENDER(int YEAR,int MONTH)
        {

            G_YEAR = YEAR.ToString();
            G_MONTH = MONTH.ToString().PadLeft(2,'0');


            DateList.Add(button7);
            DateList.Add(button8);
            DateList.Add(button9);
            DateList.Add(button10);
            DateList.Add(button11);
            DateList.Add(button12);
            DateList.Add(button13);

            DateList.Add(button14);
            DateList.Add(button15);
            DateList.Add(button16);
            DateList.Add(button17);
            DateList.Add(button18);
            DateList.Add(button19);
            DateList.Add(button20);

            DateList.Add(button21);
            DateList.Add(button22);
            DateList.Add(button23);
            DateList.Add(button24);
            DateList.Add(button25);
            DateList.Add(button26);
            DateList.Add(button27);

            DateList.Add(button28);
            DateList.Add(button29);
            DateList.Add(button30);
            DateList.Add(button31);
            DateList.Add(button32);
            DateList.Add(button33);
            DateList.Add(button34);

            DateList.Add(button35);
            DateList.Add(button36);
            DateList.Add(button37);
            DateList.Add(button38);
            DateList.Add(button39);
            DateList.Add(button40);
            DateList.Add(button41);

            foreach (var item in DateList)
            {
                item.Text = "";
                item.Enabled = true;
                item.ForeColor = Color.Black;
                item.BackColor = Color.FromArgb(255, 192, 128);
            }

            DISABLE_SAT_SUN();

            List<int> holidays = GET_HOLIDAYS_TO_ARRAY(YEAR,MONTH);


            try
            {

                int daysInmonth = DateTime.DaysInMonth(YEAR, MONTH);

                DateTime myDate = new DateTime(YEAR,MONTH,1);

                int weekDay = (int)myDate.DayOfWeek;
                if (weekDay == 0)
                    weekDay = 7;

                for (int i = 1; i <= daysInmonth; i++)
                {
                    string date = i.ToString().PadLeft(2, '0');
                    int _index = i + weekDay - 2;

                    if (_index>34)
                    {
                        _index = _index - 35;
                    }
                    if (holidays.Any(x=>x==i))
                    {                        
                        DateList[_index].BackColor = Color.Red;
                        DateList[_index].ForeColor = Color.White;
                        DateList[_index].Enabled = false;
                    }
                    DateList[_index].Text = date;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 40, 40));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 40, 40));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 40, 40));
            button4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button4.Width, button4.Height, 40, 40));
            button5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button5.Width, button5.Height, 40, 40));
            button6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button6.Width, button6.Height, 40, 40));
            //button6.Enabled = false;

            LOAD_NEXT_MONTHS();
            //DISABLE_SAT_SUN();
            //GENERATE_CALENDER(DateTime.Now.Year, DateTime.Now.Month);
            

            LOAD_CURRENT_MONTH();
        }

        private void LOAD_CURRENT_MONTH()
        {
            int YEAR = DateTime.Now.Year;
            int MONTH = DateTime.Now.Month;

            int _DAY = DateTime.Now.Day;

            G_YEAR = YEAR.ToString();
            G_MONTH = MONTH.ToString().PadLeft(2,'0');

            DateList.Add(button7);
            DateList.Add(button8);
            DateList.Add(button9);
            DateList.Add(button10);
            DateList.Add(button11);
            DateList.Add(button12);
            DateList.Add(button13);

            DateList.Add(button14);
            DateList.Add(button15);
            DateList.Add(button16);
            DateList.Add(button17);
            DateList.Add(button18);
            DateList.Add(button19);
            DateList.Add(button20);

            DateList.Add(button21);
            DateList.Add(button22);
            DateList.Add(button23);
            DateList.Add(button24);
            DateList.Add(button25);
            DateList.Add(button26);
            DateList.Add(button27);

            DateList.Add(button28);
            DateList.Add(button29);
            DateList.Add(button30);
            DateList.Add(button31);
            DateList.Add(button32);
            DateList.Add(button33);
            DateList.Add(button34);

            DateList.Add(button35);
            DateList.Add(button36);
            DateList.Add(button37);
            DateList.Add(button38);
            DateList.Add(button39);
            DateList.Add(button40);
            DateList.Add(button41);

            foreach (var item in DateList)
            {
                item.Text = "";
                item.Enabled = true;
                item.ForeColor = Color.Black;
                item.BackColor = Color.FromArgb(255, 192, 128);
            }

            DISABLE_SAT_SUN();

            List<int> holidays = GET_HOLIDAYS_TO_ARRAY(YEAR, MONTH);
            try
            {

                int daysInmonth = DateTime.DaysInMonth(YEAR, MONTH);

                DateTime myDate = new DateTime(YEAR, MONTH, 1);

                int weekDay = (int)myDate.DayOfWeek;
                if (weekDay == 0)
                    weekDay = 7;

                for (int i = 1; i <= daysInmonth; i++)
                {
                    string date = i.ToString().PadLeft(2, '0');
                    int _index = i + weekDay - 2;

                    if (_index > 34)
                    {
                        _index = _index - 35;
                    }

                    if (i<=_DAY)
                    {
                        DateList[_index].Enabled = false;
                    }

                    if (holidays.Any(x => x == i))
                    {
                        DateList[_index].BackColor = Color.Red;
                        DateList[_index].ForeColor = Color.White;
                        DateList[_index].Enabled = false;
                    }
                    DateList[_index].Text = date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DISABLE_SAT_SUN()
        {
            List<Button> BTNSSS = new List<Button>();
            try
            {
                BTNSSS.Add(button12);
                BTNSSS.Add(button13);
                BTNSSS.Add(button19);
                BTNSSS.Add(button20);
                BTNSSS.Add(button26);
                BTNSSS.Add(button27);
                BTNSSS.Add(button33);
                BTNSSS.Add(button34);
                BTNSSS.Add(button40);
                BTNSSS.Add(button41);

                foreach (var item in BTNSSS)
                {
                    item.Enabled = false;
                    item.BackColor = Color.DarkGray;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LOAD_NEXT_MONTHS()
        {
            List<Button> Btn_List = new List<Button>();
            Btn_List.Add(button1);
            Btn_List.Add(button2);
            Btn_List.Add(button3);
            Btn_List.Add(button4);
            Btn_List.Add(button5);
            Btn_List.Add(button6);

            try
            {
                DateTime date = DateTime.Now;

                for (int i = 0; i <= 5; i++)
                {
                    DateTime date2 = date.AddMonths(i);
                    Btn_List[i].Text = date2.ToString("MMMM");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<int> GET_HOLIDAYS_TO_ARRAY(int YEAR,int MONTH)
        {
            List<int> HOLARR = new List<int>();
            //HOLARR.Clear();
            try
            {
                string query = "SELECT * FROM HOLIDAY WHERE SYSTEM_DATE_NO LIKE '"+YEAR+MONTH.ToString().PadLeft(2,'0')+"%'";
                SqlCommand cmd = new SqlCommand(query, GET_DB_CONN());
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["SYSTEM_DATE_NO"] != null)
                        HOLARR.Add(Convert.ToInt32(dr["SYSTEM_DATE_NO"]?.ToString().Substring(6, 2)));
                }
                cmd.Connection.Close();

                return HOLARR;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public SqlConnection GET_DB_CONN()
        {
            try
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder()
                {
                    DataSource = "DESKTOP-3CR1187",
                    UserID = "sa",
                    Password = "#image123",
                    InitialCatalog = "MCSCDKHB"
                };
                SqlConnection con = new SqlConnection(csb.ConnectionString);
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTimenow = DateTime.Now.AddMonths(1);               
                GENERATE_CALENDER(dateTimenow.Year,dateTimenow.Month);

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTimenow = DateTime.Now.AddMonths(2);
                GENERATE_CALENDER(dateTimenow.Year, dateTimenow.Month);

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTimenow = DateTime.Now.AddMonths(3);
                GENERATE_CALENDER(dateTimenow.Year, dateTimenow.Month);

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTimenow = DateTime.Now.AddMonths(4);
                GENERATE_CALENDER(dateTimenow.Year, dateTimenow.Month);

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTimenow = DateTime.Now.AddMonths(5);
                GENERATE_CALENDER(dateTimenow.Year, dateTimenow.Month);

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GET_DATE(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string date = btn.Text;
            if (!string.IsNullOrEmpty(date))
            {
                MessageBox.Show(G_YEAR + "-" + G_MONTH + "-" + date);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                LOAD_CURRENT_MONTH();

                CHANGE_BTN_COLOR();

                var btn = sender as Button;
                btn.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CHANGE_BTN_COLOR()
        {
            List<Button> Btn_List = new List<Button>();
            Btn_List.Add(button1);
            Btn_List.Add(button2);
            Btn_List.Add(button3);
            Btn_List.Add(button4);
            Btn_List.Add(button5);
            Btn_List.Add(button6);

            try
            {
                foreach (var item in Btn_List)
                {
                    item.BackColor = Color.Coral;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
