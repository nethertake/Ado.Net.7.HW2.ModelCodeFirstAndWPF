using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using Ado.Net._7.HW2.ModelCodeFirstAndWPF.Model;

namespace Ado.Net._7.HW2.ModelCodeFirstAndWPF
{

    public partial class MainWindow : Window
    {
        List<TablesManufacturer> tablesManufacturers = new List<TablesManufacturer>();
        private MCSModel db = new MCSModel();
        private static string _connectionString = @"Data Source=DESKTOP-PG10UGI\SQLEXPRESS; Initial Catalog = MCS; User Id =sa; Password =Mc123456";
        public MainWindow()
        {
            InitializeComponent();


            var query = db.TablesManufacturers
                .Select(s => new {s.intManufacturerID, s.strManufacturerChecklistId, s.strName}).ToList();
    
            foreach (var item in query.ToList())
            {
                TablesManufacturer tb = new TablesManufacturer();
                tb.intManufacturerID = item.intManufacturerID;
                tb.strManufacturerChecklistId = item.strManufacturerChecklistId;
                tb.strName = item.strName;

               tablesManufacturers.Add(tb);

            }

            ListViewData.ItemsSource = tablesManufacturers;
            ListViewData2.ItemsSource = tablesManufacturers;


        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            int x = ListViewData.SelectedIndex;
            int id = tablesManufacturers[x].intManufacturerID;
           SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("delete from TablesManufacturer where intManufacturerID=" + id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            var query = db.TablesManufacturers
                .Select(s => new { s.intManufacturerID, s.strManufacturerChecklistId, s.strName }).ToList();

            foreach (var item in query.ToList())
            {
                TablesManufacturer tb = new TablesManufacturer();
                tb.intManufacturerID = item.intManufacturerID;
                tb.strManufacturerChecklistId = item.strManufacturerChecklistId;
                tb.strName = item.strName;

                tablesManufacturers.Add(tb);

            }

            ListViewData.ItemsSource = tablesManufacturers;
            ListViewData.ItemsSource = tablesManufacturers;

        }

        private void TextBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int id = int.Parse(TextBoxId.Text);
                var model = db.TablesManufacturers.SingleOrDefault(s => s.intManufacturerID == id);

                TextBoxManufId.Text = model.intManufacturerID.ToString();
                TextBoxChecklistId.Text = model.strManufacturerChecklistId;
                TextBoxName.Text = model.strName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strManufacturerChecklistId = TextBoxChecklistId.Text;
            string strName = TextBoxName.Text;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("insert into TablesManufacturer (strManufacturerChecklistId,strName) values ('"+strManufacturerChecklistId +"','"+ strName + " ')  ", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
