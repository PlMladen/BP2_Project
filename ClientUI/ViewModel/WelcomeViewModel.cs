using ClientUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientUI.ViewModel
{
    public class WelcomeViewModel : BindableBase
    {
        private string email = string.Empty;
        private string lozinka = string.Empty;
        private string imeErrorLabel = string.Empty;
        private string loznikaErrorLabel = string.Empty;
        public MyICommand<object> LoginCommand { get; set; }
        public MyICommand OdustaniCommand { get; set; }
        public MyICommand RegistracijaCommand { get; set; }
        

        public WelcomeViewModel()
        {
            LoginCommand = new MyICommand<object>(obj => OnLogin((object)obj));
            OdustaniCommand = new MyICommand(OnOdustani);
            RegistracijaCommand = new MyICommand(OnRegistracija);
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        public string Lozinka
        {
            get => lozinka;
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        public string ImeErrorLabel
        {
            get => imeErrorLabel;
            set
            {
                imeErrorLabel = value;
                OnPropertyChanged("ImeErrorLabel");
            }
        }
        public string LozinkaErrorLabel
        {
            get => loznikaErrorLabel;
            set
            {
                loznikaErrorLabel = value;
                OnPropertyChanged("LozinkaErrorLabel");
            }
        }
        private bool CanLogin()
        {
            return !String.IsNullOrWhiteSpace(Email) 
                   ;
        }

        private void OnLogin(object parameter)
        {
            ImeErrorLabel = string.Empty;
            LozinkaErrorLabel = string.Empty;
            var password = parameter as PasswordBox;

            if (string.IsNullOrEmpty(Email))
            {
                ImeErrorLabel = "Korisničko ime mora biti uneseno!";
             
            }
            else if (string.IsNullOrEmpty(password.Password.ToString()))
            {
                LozinkaErrorLabel = "Lozinka mora biti unesena!";
                
            }
            else
            {
                if (DatabaseServiceProvider.Instance.PrijaviKorisnika(Email, password.Password)){
                    string s = DatabaseServiceProvider.Instance.VratiUloguKorisnika(Email);
                    long jmbg = s.Equals("Vlasnik_racunara") || s.Equals("Serviser_racunara") ? DatabaseServiceProvider.Instance.VratiJMBGVlasnika(Email) : -1;
                    MainWindow mainWindow = new MainWindow(s, Email, jmbg);
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item is WelcomeWindow)
                        {
                            item.Close();
                            break;
                        }
                    }
                    mainWindow.Show();
                }
                else
                {
                    LozinkaErrorLabel = "Neispravno korisničko ime ili lozinka!";
                }
            }
        }


        private void OnOdustani()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if(item is WelcomeWindow)
                {
                    item.Close();
                    break;
                }
            }
        }
        private void OnRegistracija()
        {
            RegistracijaView registracijaView = new RegistracijaView();

            foreach (Window item in Application.Current.Windows)
            {
                if (item is WelcomeWindow)
                {
                    item.Close();
                    break;
                }
            }
            registracijaView.Show();
        }
    }
}
