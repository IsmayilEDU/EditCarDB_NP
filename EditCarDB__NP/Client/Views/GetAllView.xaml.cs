using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for GetAllView.xaml
    /// </summary>
    public partial class GetAllView : Window
    {
        public List<Car> Cars { get; set; }

        public GetAllView()
        {
            InitializeComponent();
        }
    }
}
