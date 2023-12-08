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

namespace Client
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
        }

        

        private void button_GetById_Click(object sender, RoutedEventArgs e)
        {
            Views.GetByIdView window = new();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void button_GetAll_Click(object sender, RoutedEventArgs e)
        {
            Views.GetAllView window = new();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void button_AddCar_Click(object sender, RoutedEventArgs e)
        {
            Views.AddCarView window = new();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void button_UpdateCar_Click(object sender, RoutedEventArgs e)
        {
            Views.UpdateCarView window = new();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void button_DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Views.DeleteCarView window = new();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();
        }
    }
}
