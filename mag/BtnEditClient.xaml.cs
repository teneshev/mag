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
using System.Windows.Shapes;

namespace mag
{
    /// <summary>
    /// Логика взаимодействия для BtnEditClient.xaml
    /// </summary>
    public partial class BtnEditClient : Window
    {
        magazinEntities context;
        public BtnEditClient(magazinEntities context, Клиенты клиенты)
        {
            InitializeComponent();

            this.context = context;
            this.DataContext = клиенты;
        }

        private void DataGridКлиенты_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void BtnSAve_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
           
        }

        private void ShowTable()
        {
            
        }
    }
}
