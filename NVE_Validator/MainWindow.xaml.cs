using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NVE_Validator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_validate_Click(object sender, RoutedEventArgs e)
        {

            if (Regex.IsMatch(tbx_nve.Text, @"[0-9]+"))
            {
                if (tbx_nve.Text.Length < 1)
                {
                    MessageBox.Show("Leere Eingabe");
                }
                else if (tbx_nve.Text.Length < 20)
                {
                    MessageBox.Show("Eingabe ('" + tbx_nve.Text + "') ist kürzer als 20 Stellen.\nHaben Sie die führenden Nullen vergessen?");
                }
                else if (tbx_nve.Text.Length > 20)
                {
                    MessageBox.Show("Eingabe ('" + tbx_nve.Text + "') ist länger als 20 Stellen");
                }
                else
                {
                    char[] char_nve = new Char[20];
                    char_nve = tbx_nve.Text.ToCharArray();
                    int sum = 0;
                    for (int i = 0; i < 19; i++)
                    {
                        if ((i + 1) % 2 == 1)
                            sum += (int)Char.GetNumericValue(char_nve[i]) * 3;
                        else
                            sum += (int)Char.GetNumericValue(char_nve[i]);
                    }
                    if ((sum + (int)Char.GetNumericValue(char_nve[19])) % 10 == 0)
                    {
                        listBox.Items.Add(tbx_nve.Text);
                        tbx_nve.Text = "";
                    }
                    else
                        MessageBox.Show("NVE/SSCC ist nicht korrekt: Prüfziffer falsch");
                }
            }
            else
                MessageBox.Show("Geben Sie eine gültige NVE/SSCC mit führenden Nullen ein");
        }
    }
}
