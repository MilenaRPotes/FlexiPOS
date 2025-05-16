using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace FlexiPos.Views
{
    /// <summary>
    /// Lógica de interacción para Usersxaml.xaml
    /// </summary>
    public partial class Usersxaml : UserControl
    {
        public Usersxaml()
        {
            InitializeComponent();
            LoadData();
        }



        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        //Method load data
        void LoadData() 
        {
            //fill the datagrid with the list of users
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select IdUser, Names, LastNames, Phone, Email, NamePrivilege from Users inner join privileges on Users.Privilege=privileges.IdPrivilege order by IdUser ASC", connection);
            SqlDataAdapter dadapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dadapter.Fill(dt);
            GridData.ItemsSource = dt.DefaultView;
            connection.Close();

        }


        private void AddUser(object sender, RoutedEventArgs e)
        {
            CRUDUsers cRUDUsersWindow = new CRUDUsers();
            UsersFrame.Content = cRUDUsersWindow;
        }
    }
}
