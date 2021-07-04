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
        List<Ijs> verkochteIjsjes = new List<Ijs>();
        Ijs huidigIjsje;
        Verpakkingen huidigeVerpakking;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllControls();
        }
        private void cmbVerpakking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbVerpakking.SelectedIndex != -1)
            {
                huidigeVerpakking = (Verpakkingen)cmbVerpakking.SelectedItem;
                btnSchepIjsje.IsEnabled = true;
            }
        }
        private void btnSchepIjsje_Click(object sender, RoutedEventArgs e)
        {
            if (grdSmaken.Visibility == Visibility.Visible)
            {
                grdSmaken.Visibility = Visibility.Hidden;
                LoadAllControls();
            }
            else
                grdSmaken.Visibility = Visibility.Visible;
        }
        private void btnVerrassingsIjsje_Click(object sender, RoutedEventArgs e)
        {
            lstGekozenSmaken.Items.Clear();
            huidigIjsje = SmaakService.MaakVerrassingsIjsje(huidigeVerpakking);
            foreach (Smaak item in huidigIjsje.Bollen)
                lstGekozenSmaken.Items.Add(item);
        }
        private void btnLeverIjsje_Click(object sender, RoutedEventArgs e)
        {
            if (huidigIjsje == null)
            {
                List<Smaak> huidigeSmaken = new List<Smaak>();
                foreach (Smaak item in lstGekozenSmaken.Items)
                    huidigeSmaken.Add(item);
                huidigIjsje = SmaakService.MaakIjsje(huidigeSmaken, huidigeVerpakking);
            }
            UpdateVerkochteIjsjes();
            LoadAllControls();
        }
        private void lstSmaken_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lstSmaken.SelectedIndex != -1)
            {
                Smaak smaak = (Smaak)lstSmaken.SelectedItem;
                lstGekozenSmaken.Items.Add(smaak);
                if (huidigIjsje != null)
                    huidigIjsje.Bollen.Add(smaak);
            }
        }
        private void lstGekozenSmaken_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lstGekozenSmaken.SelectedIndex != -1)
            {
                int smaak = lstGekozenSmaken.SelectedIndex;
                lstGekozenSmaken.Items.RemoveAt(smaak);
                if (huidigIjsje != null)
                    huidigIjsje.Bollen.RemoveAt(smaak);
            }
        }
        private void btnVoegSmaakToe_Click(object sender, RoutedEventArgs e)
        {
            if (lstSmaken.SelectedIndex != -1)
            {
                Smaak smaak = (Smaak)lstSmaken.SelectedItem;
                lstGekozenSmaken.Items.Add(smaak);
                if (huidigIjsje != null)
                    huidigIjsje.Bollen.Add(smaak);
            }
        }
        private void UpdateVerkochteIjsjes()
        {
            verkochteIjsjes.Add(huidigIjsje);
            lstIjsjes.Items.Clear();
            foreach (var item in verkochteIjsjes)
                lstIjsjes.Items.Add(item);
            lblOmzet.Content = $"{verkochteIjsjes.Sum(smaak => smaak.TotaalBedrag).ToString("C2")}";
        }
        private void LoadAllControls()
        {
            cmbVerpakking.ItemsSource = Enum.GetValues(typeof(Verpakkingen));
            cmbVerpakking.SelectedIndex = -1;
            btnSchepIjsje.IsEnabled = false;
            lstSmaken.ItemsSource = SmaakService.IjsSmaken;
            lstSmaken.SelectedIndex = -1;
            lstGekozenSmaken.Items.Clear();
            grdSmaken.Visibility = Visibility.Hidden;
            huidigIjsje = null;
        }
    }
}