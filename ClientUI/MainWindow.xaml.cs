using ClientUI.View;
using Common.Models;
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

namespace ClientUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Uloga = string.Empty;
        public static string KIme = string.Empty;
        public static long IdVlasnika = 0;
        public MainWindow(string s, string korisnickoIme, long jmbg)
        {
            Uloga = s;
            KIme = korisnickoIme;
            if(Uloga.Equals("Vlasnik_racunara") || Uloga.Equals("Serviser_racunara"))
            IdVlasnika = jmbg;
            InitializeComponent();
            DobrodosliLbl.Content = "Dobrodošli, " + korisnickoIme;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var i =  Task.Run(DatabaseServiceProvider.Instance.GetAllServiss);
        }

        private void OdjavaBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void ProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = DatabaseServiceProvider.Instance.VratiKorisnika(MainWindow.KIme);
            ProfilView profilView = new ProfilView(k);
            profilView.ShowDialog();
        }
    }
}
