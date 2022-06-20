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

namespace XXO
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> Felder = new List<Button>();
        int spieler;
        public MainWindow()
        {
            InitializeComponent();
            NeuesSpiel();
        }

        private void NeuesSpiel()
        {
            Felder.Clear();
            for (int i = 0; i < 9; i++)
            {
                Button feld = new Button();
                feld.Background = Brushes.LightBlue;
                feld.BorderBrush = Brushes.Gray;
                Felder.Add(feld);
                feld.Click += Umschalten;
                feld.Content = "";
                if (i<3) Grid.SetRow(feld,0);
                else if (i < 6) Grid.SetRow(feld, 1);
                else Grid.SetRow(feld, 2);
                Grid.SetColumn(feld,i%3);
                Spielfeld.Children.Add(feld);
            }
            spieler = 1;
            tb1.Background = Brushes.LightGreen;
        }

        private void Umschalten(object sender, RoutedEventArgs e)
        {
            if (spieler == 1)
            {
                spieler = 2;
                tb2.Background = Brushes.LightGreen;
                tb1.Background = Brushes.White;
                ((Button)sender).Content = "X";
            }
            else
            {
                spieler = 1;
                tb2.Background = Brushes.White;
                tb1.Background = Brushes.LightGreen;
                ((Button)sender).Content = "O";
            }
            //Liste Felder benutzen um Siegbedingung zu überprüfen!
        }

        private void btnSielen_Click(object sender, RoutedEventArgs e)
        {
            NeuesSpiel();
        }
    }
}
