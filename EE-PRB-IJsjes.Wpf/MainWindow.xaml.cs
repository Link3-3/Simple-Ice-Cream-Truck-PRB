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
using IJsjes.Lib.Entities;
using IJsjes.Lib.Services;

namespace EE_PRB_IJsjes.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<Ijs> verkochteIjsjes = new List<Ijs>();
        //Ijs huidigIjsje;
        Verpakkingen huidigeVerpakking;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void cmbVerpakking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            huidigeVerpakking = (Verpakkingen)cmbVerpakking.SelectedItem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Opstarten();
        }

        private void btnVerrassingsIjsje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoegSmaakToe_Click(object sender, RoutedEventArgs e)
        {
            // opvangen dat er niets werd geselecteerd..
            int index = lstSmaken.SelectedIndex;
            if (index != -1)
            {
                string smaak = lstSmaken.SelectedItem.ToString();
                lstGekozenSmaken.Items.Add(smaak);
                lstSmaken.SelectedIndex = -1;
                tbkFeedBack.Visibility = Visibility.Hidden;

            }
            else
            {
                ToonMelding("Selecteer een smaak uit de lijst 'Smaken'.", false);
                tbkFeedBack.Visibility = Visibility.Visible;
            }
        }

        private void btnSchepIjsje_Click(object sender, RoutedEventArgs e)
        {
            if (!cmbVerpakking.IsEnabled)
            {
                grdSmaken.Visibility = Visibility.Hidden;
                cmbVerpakking.IsEnabled = true;
            }
            else
            {
                grdSmaken.Visibility = Visibility.Visible;
                cmbVerpakking.IsEnabled = false;

            }

        }

        private void btnLeverIjsje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lstSmaken_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // hier moet er niets op gevevangen worden van selectie. 
            // Er wordt sowieso iets geselecteerd..
            int index = lstSmaken.SelectedIndex;
                string smaak = lstSmaken.SelectedItem.ToString();
                lstGekozenSmaken.Items.Add(smaak);
                lstSmaken.SelectedIndex = -1;
                tbkFeedBack.Visibility = Visibility.Hidden;

        }

        private void lstGekozenSmaken_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // hier moet er niets op gevevangen worden van selectie. 
            // Er wordt sowieso iets geselecteerd..

            int index = lstGekozenSmaken.SelectedIndex;
                lstGekozenSmaken.Items.RemoveAt(index);
                lstGekozenSmaken.SelectedIndex = -1;
                tbkFeedBack.Visibility = Visibility.Hidden;
        }

        void Opstarten()
        {
            cmbVerpakking.Items.Add(Verpakkingen.Hoorntje);
            cmbVerpakking.Items.Add(Verpakkingen.Potje);
            cmbVerpakking.Items.Add(Verpakkingen.Wafel);

            //lstSmaken.Items.Add(Smaken.Chocolade);
            //lstSmaken.Items.Add(Smaken.Mokka);
            //lstSmaken.Items.Add(Smaken.Vanille);

            lstSmaken.ItemsSource = SmaakService.IjsSmaken;

            grdSmaken.Visibility = Visibility.Hidden;
            cmbVerpakking.SelectedIndex = 0;

            //MaakVerrassingsijsje.. 
            tbkFeedBack.Visibility = Visibility.Hidden;
        }
    }
}
