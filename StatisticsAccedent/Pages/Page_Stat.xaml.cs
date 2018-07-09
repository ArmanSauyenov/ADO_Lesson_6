using StatisticsAccedent.Module;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StatisticsAccedent.Pages
{
    /// <summary>
    /// Interaction logic for Page_Stat.xaml
    /// </summary>
    public partial class Page_Stat : Page
    {
        public Page_Stat()
        {
       


            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = con;
            sc.CommandText = "select top 3 County, count(*) as Cnt from Accidents group by County order by Cnt DESC;" +
                             "select top 3 Age, count(*) as Cnt from Accidents group by Age order by Cnt DESC;" +
                             "select top 3 Gender, count(*) as Cnt from Accidents group by Gender order by Cnt DESC;" +
                              "select top 3 DayOfWeek, count(*) as Cnt from Accidents group by DayOfWeek order by Cnt DESC;"; 

                SqlDataReader sdr = sc.ExecuteReader();
            Stat_Accedent stat_accedent = new Stat_Accedent();
            int s = 0;
            while (sdr.HasRows) {
                while (sdr.Read())
                {
                    switch (s)
                    {
                        case 0:
                            stat_accedent.topCountry.Add(sdr[0].ToString());
                            break;
                        case 1:
                            stat_accedent.topAge.Add(sdr[0].ToString());
                            break;
                        case 2:
                            stat_accedent.topGender.Add(sdr[0].ToString());
                            break;
                        case 3:
                            stat_accedent.topDaysOfWeek.Add(sdr[0].ToString());
                           break;
                    }
               } s++;
                sdr.NextResult();

            }
        }


    }
}
