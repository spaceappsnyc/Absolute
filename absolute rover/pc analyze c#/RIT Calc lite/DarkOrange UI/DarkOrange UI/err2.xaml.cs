using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DarkOrange_UI
{
    /// <summary>
    /// Логика взаимодействия для err2.xaml
    /// </summary>
    public partial class err2 : Window
    {
        public err2()
        {
            InitializeComponent();
        }
        private void copy_Copy1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {

            }
        }
    }
}
