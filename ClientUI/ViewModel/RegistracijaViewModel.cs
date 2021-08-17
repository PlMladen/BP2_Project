using ClientUI.View;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientUI.ViewModel
{
    public class RegistracijaViewModel : BindableBase
    {
        private string ime = string.Empty;
        private string prezime = string.Empty;
        private string jmbg = string.Empty;
        private string kime = string.Empty;
        private DateTime datumRodjenja = DateTime.Now.Date;
        private string uloga = string.Empty;
        private string adresaUlica = string.Empty;
        private string adresaBroj = string.Empty;
        private string adresaGrad = string.Empty;
        private string adresaPBroj = string.Empty;
        private string imeGreska = string.Empty;
        private string prezimeGreska = string.Empty;
        private string kimeGreska = string.Empty;
        private string lozinkaGreska = string.Empty;
        private string datumRodjenjaGreska = string.Empty;
        private string jmbgGreska = string.Empty;
        private string ulogaGreska = string.Empty;
        private string adresaGreska = string.Empty;
        private string adresaVidljiva = "Hidden";

        public MyICommand<object> RegistracijaCommand { get; set; }
        public MyICommand OdustaniCommand { get; set; }

        public RegistracijaViewModel()
        {
            RegistracijaCommand = new MyICommand<object>(obj => OnRegistracija(obj));
            OdustaniCommand = new MyICommand(OnOdustani);
        }

        public string Ime
        {
            get => ime;
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string ImeGreska
        {
            get => imeGreska;
            set
            {
                imeGreska = value;
                OnPropertyChanged("ImeGreska");
            }
        }
        public string Prezime
        {
            get => prezime;
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string PrezimeGreska
        {
            get => prezimeGreska;
            set
            {
                prezimeGreska = value;
                OnPropertyChanged("PrezimeGreska");
            }
        }
        public string JMBG
        {
            get => jmbg;
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string JMBGGreska
        {
            get => jmbgGreska;
            set
            {
                jmbgGreska = value;
                OnPropertyChanged("JmbgGreska");
            }
        }
        public string KIme
        {
            get => kime;
            set
            {
                kime = value;
                OnPropertyChanged("KIme");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string KImeGreska
        {
            get => kimeGreska;
            set
            {
                kimeGreska = value;
                OnPropertyChanged("KImeGreska");
            }
        }
        public string LozinkaGreska
        {
            get => lozinkaGreska;
            set
            {
                lozinkaGreska = value;
                OnPropertyChanged("LozinkaGreska");
            }
        }
        public DateTime DatumRodjenja
        {
            get => datumRodjenja;
            set
            {
                datumRodjenja = value;
                OnPropertyChanged("DatumRodjenja");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string DatumRodjenjaGreska
        {
            get => datumRodjenjaGreska;
            set
            {
                datumRodjenjaGreska = value;
                OnPropertyChanged("DatumRodjenjaGreska");
            }
        }

        public string Uloga
        {
            get => uloga;
            set
            {
                uloga = value;
                adresaVidljiva = uloga.Equals("Vlasnik_racunara") ? "Visible" : "Hidden";
                OnPropertyChanged("Uloga");
                OnPropertyChanged("AdresaVidljiva");
                RegistracijaCommand.RaiseCanExecuteChanged();
            }
        }
        public string AdresaUlica
        {
            get => adresaUlica;
            set
            {
                adresaUlica = value;
                OnPropertyChanged("AdresaUlica");
            }
        }
        public string AdresaBroj
        {
            get => adresaBroj;
            set
            {
                adresaBroj = value;
                OnPropertyChanged("AdresaBroj");
            }
        }
        public string AdresaGrad
        {
            get => adresaGrad;
            set
            {
                adresaGrad = value;
                OnPropertyChanged("AdresaGrad");
            }
        }
        public string AdresaPBroj
        {
            get => adresaPBroj;
            set
            {
                adresaPBroj = value;
                OnPropertyChanged("AdresaPBroj");
            }
        }
        public string AdresaVidljiva
        {
            get => adresaVidljiva;
            set
            {
                adresaVidljiva = value;
                OnPropertyChanged("AdresaVidljiva");
            }
        }
        public string AdresaGreska
        {
            get => adresaGreska;
            set
            {
                adresaGreska = value;
                OnPropertyChanged("AdresaGreska");
            }
        }
        public string UlogaGreska
        {
            get => ulogaGreska;
            set
            {
                ulogaGreska = value;
                OnPropertyChanged("UlogaGreska");
            }
        }
        /*
        private bool CanRegistracija()
        {
            return !String.IsNullOrWhiteSpace(KIme) &&
                   !String.IsNullOrWhiteSpace(Ime) &&
                   !String.IsNullOrWhiteSpace(Prezime) &&
                   !String.IsNullOrWhiteSpace(Uloga) &&
                   !String.IsNullOrWhiteSpace(DatumRodjenja.ToString()) &&
                   !String.IsNullOrWhiteSpace(Lozinka);
        }*/
        private void OnRegistracija(object obj)
        {
            ImeGreska = string.Empty;
            PrezimeGreska = string.Empty;
            KImeGreska = string.Empty;
            LozinkaGreska = string.Empty;
            DatumRodjenjaGreska = string.Empty;
            UlogaGreska = string.Empty;
            AdresaGreska = string.Empty;
            JMBGGreska = string.Empty;
            var lozinka = obj as PasswordBox;


            if (ValidateForm(lozinka.Password))
            {
                Korisnik temp = new Korisnik()
                {
                    Uloga = Uloga,
                    DatumRodjenja = Convert.ToDateTime(DatumRodjenja),
                    Ime = Ime,
                    Prezime = Prezime,
                    Lozinka = lozinka.Password,
                    JMBG = Convert.ToInt64(JMBG),
                    KorisnickoIme = KIme
                };
                if (Uloga.Equals("Vlasnik_racunara"))
                {
                    temp.Adresa = new Adresa()
                    {
                        Ulica = AdresaUlica,
                        Grad = AdresaGrad,
                        Broj = Convert.ToInt32(AdresaBroj),
                        PostanskiBroj = Convert.ToInt32(AdresaPBroj)
                    };
                }
                if (DatabaseServiceProvider.Instance.RegistrujKorisnika(temp))
                {
                    MessageBox.Show("Registracija uspješna! Za korišćenje sistema je potrebno da se prijavite!");
                    WelcomeWindow welcomeWindow = new WelcomeWindow();

                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item is RegistracijaView)
                        {
                            item.Close();
                            break;
                        }
                    }
                    welcomeWindow.Show();
                }
            }
        }
        private bool ValidateForm(string lozinka)
        {
            bool retVal = true;
            if (String.IsNullOrEmpty(Ime))
            {
                ImeGreska = "Polje 'Ime' ne smije biti prazno!";
                retVal = false;
            }
            else
            {
                if (!Ime.All(Char.IsLetter))
                {
                    ImeGreska = "Polje 'Ime' mora sadržati samo slova!";
                    retVal = false;
                }
            }
            
            if (String.IsNullOrEmpty(Prezime))
            {
                PrezimeGreska = "Polje 'Prezime' ne smije biti prazno!";
                retVal = false;
            }
            else
            {
                if (!Prezime.All(Char.IsLetter))
                {
                    PrezimeGreska = "Polje 'Prezime' mora sadržati samo slova!";
                    retVal = false;
                }
            }
            if (String.IsNullOrEmpty(KIme))
            {
                KImeGreska = "Polje 'Korisničko ime' ne smije biti prazno!";
                retVal = false;
            }
            if (String.IsNullOrEmpty(JMBG))
            {
                JMBGGreska = "Polje 'JMBG' ne smije biti prazno!";
                retVal = false;
            }
            else
            {
                if (!JMBG.All(Char.IsDigit))
                {
                    JMBGGreska = "JMBG treba da sadrži samo cifre!";
                    retVal = false;
                }
                else if (JMBG.Length != 13)
                {
                    JMBGGreska = "JMBG treba da sadrži tačno 13 brojeva!";
                    retVal = false;
                }
            }
            if (String.IsNullOrEmpty(lozinka.ToString()))
            {
                LozinkaGreska = "Polje 'Lozinka' ne smije biti prazno!";
                retVal = false;
            }
            if (String.IsNullOrEmpty(Uloga))
            {
                UlogaGreska = "Polje 'Uloga' ne smije biti prazno!";
                retVal = false;
            }
            if (String.IsNullOrEmpty(DatumRodjenja.ToString()))
            {
                DatumRodjenjaGreska = "Polje 'Datum rođenja' ne smije biti prazno!";
                retVal = false;
            }
            else
            {
                if (Convert.ToDateTime(DatumRodjenja) < DateTime.Today.AddYears(-18))
                {
                    DatumRodjenjaGreska = "Korisnik mora biti punoljetan da bi se registrovao!";
                    retVal = false;
                }
            }
            if (Uloga.Equals("Vlasnik_racunara") && (String.IsNullOrEmpty(AdresaUlica) ||
                                                          String.IsNullOrEmpty(AdresaBroj) ||
                                                          String.IsNullOrEmpty(AdresaGrad) ||
                                                          String.IsNullOrEmpty(AdresaPBroj)))
            {
                AdresaGreska = "Polje 'Adresa' ne smije biti prazno!";
                retVal = false;
            }
            else
            {
                if (!AdresaUlica.Replace(" ", "").All(Char.IsLetter))
                {
                    AdresaGreska = "Naziv ulice treba da sadrži samo slova!";
                    retVal = false;
                }
                else if (!AdresaBroj.All(Char.IsLetterOrDigit))
                {
                    AdresaGreska = "Broj u adresi treba da sadrži samo slova i cifre!";
                    retVal = false;
                }
                else if (!AdresaGrad.Replace(" ", "").All(Char.IsLetter))
                {
                    AdresaGreska = "Naziv grada treba da sadrži samo slova!";
                    retVal = false;
                }
                else if (!AdresaPBroj.All(Char.IsDigit))
                {
                    AdresaGreska = "Poštanski broj treba da sadrži samo cifre!";
                    retVal = false;
                }
            }
            
            return retVal;
        }
        private void OnOdustani()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item is RegistracijaView)
                {
                    item.Close();
                    break;
                }
            }
        }
    }
}
