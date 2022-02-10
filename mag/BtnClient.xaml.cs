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
    /// Логика взаимодействия для BtnClient.xaml
    /// </summary>
    public partial class BtnClient : Window
    {
        magazinEntities context;
        string currentLetter = "";
        public BtnClient()
        {
            InitializeComponent();
            context=new magazinEntities();
            ShowTable();
            ShowLetters();
        }

        private void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 1, 5, 1)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
        }

        private void ShowTable()
        {
            if (TxtEmail.Text == null && TxtPhone.Text == null)
                return;
            List<Клиенты> listClient = context.Клиенты.ToList();
            listClient = listClient.Where(x => x.email.ToLower().Contains(TxtEmail.Text.ToLower())).ToList();
            listClient = listClient.Where(x => x.Телефон.ToLower().Contains(TxtPhone.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                listClient = listClient.Where(x => x.Фамилия.Contains(currentLetter)).ToList();
            }
            DataGridКлиенты.ItemsSource = listClient.OrderBy(x => x.Фамилия).ToList();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.White;
            }
            label.Foreground = Brushes.Gold;
            ShowTable();
        }

        private void BtnAd_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new Клиенты();
            context.Клиенты.Add(NewClient);
            var addRNewClient = new BtnEditClient(context, NewClient);
            addRNewClient.ShowDialog();
        }

        private void BtnD_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridКлиенты.SelectedItem as Клиенты;
            if (currentClientService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Клиенты.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void DataGridКлиенты_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClient = BtnEdit.DataContext as Клиенты;
            var editClient = new BtnEditClient(context, currentClient);
            editClient.ShowDialog();
        }
    }
}
