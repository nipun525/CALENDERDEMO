using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALENDERDEMO
{
    public partial class Form1 : Form
    {
        List<Label> DateList = new List<Label>();
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
            //List<Label> DateList = new List<Label>();



            DateList.Add(label1);
            DateList.Add(label2);
            DateList.Add(label3);
            DateList.Add(label4);
            DateList.Add(label5);
            DateList.Add(label6);
            DateList.Add(label7);

            DateList.Add(label8);
            DateList.Add(label9);
            DateList.Add(label10);
            DateList.Add(label11);
            DateList.Add(label12);
            DateList.Add(label13);
            DateList.Add(label14);

            DateList.Add(label15);
            DateList.Add(label16);
            DateList.Add(label17);
            DateList.Add(label18);
            DateList.Add(label19);
            DateList.Add(label20);
            DateList.Add(label21);

            DateList.Add(label22);
            DateList.Add(label23);
            DateList.Add(label24);
            DateList.Add(label25);
            DateList.Add(label26);
            DateList.Add(label27);
            DateList.Add(label28);

            DateList.Add(label29);
            DateList.Add(label30);
            DateList.Add(label31);
            DateList.Add(label32);
            DateList.Add(label33);
            DateList.Add(label34);
            DateList.Add(label35);

            foreach (var item in DateList)
            {
                item.Text = "";
            }

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
            GENERATE_CALENDER(2021, 04);
        }
    }
}
