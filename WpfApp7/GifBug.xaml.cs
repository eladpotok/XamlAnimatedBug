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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for GifBug.xaml
    /// </summary>
    public partial class GifBug : Window
    {
        public GifBug()
        {
            InitializeComponent();
            c.Text = "https://media1.tenor.com/images/45e529c116a1758fd09bdb27e2172eca/tenor.gif";
        }
    }
}
