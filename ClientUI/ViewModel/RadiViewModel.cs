using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientUI.ViewModel
{
    public class RadiViewModel : BindableBase
    {
        private ObservableCollection<Radi> radiSet = new ObservableCollection<Radi>(DatabaseServiceProvider.Instance.GetAllRadi());
        private Radi selectedRadi;
        private static List<string> servisi = new List<string>(DatabaseServiceProvider.Instance.GetAllServiss().Where(x => x.Tip_serv == Tip_servisa.Servis_racunara).Select(x => String.Format(x.ID_servisa+"\n"+x.Naziv_serv)));
        public static List<string> serviseri = new List<string>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara().Select(x => String.Format(x.JMBG_s+"\n"+x.Ime_s+" "+x.Prezime_s)));

        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));

        private string cmbBoxID_Servisa;
        private string cmbBoxID_Servisera;


        private string lbl;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public RadiViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Radi> RadiSet
        {
            get
            {
                return new ObservableCollection<Radi>(DatabaseServiceProvider.Instance.GetAllRadi());
            }
            set
            {
                if (radiSet != value)
                {
                    radiSet = value;
                    OnPropertyChanged(nameof(RadiSet));
                }
            }
        }
        public Radi SelectedRadi
        {
            get
            {
                return selectedRadi;
            }
            set
            {
                if (selectedRadi != value)
                {
                    selectedRadi = value;
                    OnPropertyChanged(nameof(SelectedRadi));
                    CmbBoxID_Servisa = SelectedRadi == null ? "" : String.Format(SelectedRadi.Racunarski_servisID_servisa1+"\n"+SelectedRadi.Racunarski_servis.Naziv_serv);
                    CmbBoxID_Servisera = SelectedRadi == null ? "" : String.Format(SelectedRadi.Serviser_racunaraJMBG_s +"\n"+SelectedRadi.Serviser_racunara.Ime_s+" "+SelectedRadi.Serviser_racunara.Prezime_s);



                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string CmbBoxID_Servisa
        {
            get => cmbBoxID_Servisa;
            set
            {
                cmbBoxID_Servisa = value;
                OnPropertyChanged("CmbBoxID_Servisa");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public List<string> Servisi
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllServiss().Where(x => x.Tip_serv == Tip_servisa.Servis_racunara).Select(x => String.Format(x.ID_servisa + "\n" + x.Naziv_serv)));
            set
            {
                if (servisi != value)
                {
                    servisi = value;
                    OnPropertyChanged("Servisi");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public List<string> Serviseri
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara().Select(x => String.Format(x.JMBG_s + "\n" + x.Ime_s + " " + x.Prezime_s)));
            set
            {
                if (serviseri != value)
                {
                    serviseri = value;
                    OnPropertyChanged("Serviseri");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string CmbBoxID_Servisera
        {
            get => cmbBoxID_Servisera;
            set
            {
                cmbBoxID_Servisera = value;
                OnPropertyChanged("CmbBoxID_Servisera");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public Brush Foreground
        {
            get => foreground;
            set
            {
                if (foreground != value)
                {
                    foreground = value;
                    OnPropertyChanged("Foreground");
                }
            }
        }

        public string LBL
        {
            get => lbl;
            set
            {
                lbl = value;
                OnPropertyChanged("LBL");
            }
        }
        private bool CanDelete()
        {
            return SelectedRadi != null;
        }

        private void OnDelete()
        {
            int idServisa = SelectedRadi.Racunarski_servisID_servisa1;
            long idServisera = SelectedRadi.Serviser_racunaraJMBG_s;
            if (DatabaseServiceProvider.Instance.DeleteRadi(idServisera, idServisa))
            {
                LBL = "Veza 'radi' ( " + idServisera + " - " + idServisa + " ) obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju asocijacije ( " + idServisera + " - " + idServisa + " )";
                Foreground = Brushes.Red;
            }
            RadiSet = new ObservableCollection<Radi>(DatabaseServiceProvider.Instance.GetAllRadi());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(CmbBoxID_Servisera) &&
                   !String.IsNullOrEmpty(CmbBoxID_Servisa) &&
                    SelectedRadi == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(CmbBoxID_Servisa) &&
                   !String.IsNullOrEmpty(CmbBoxID_Servisera);
        }

        private void OnAdd()
        {
            try
            {
                if (DatabaseServiceProvider.Instance.AddRadi(new Radi()
                {
                    Serviser_racunaraJMBG_s = long.Parse(CmbBoxID_Servisera.Split('\n')[0], CultureInfo.InvariantCulture),
                    Racunarski_servisID_servisa1 = int.Parse(CmbBoxID_Servisa.Split('\n')[0], CultureInfo.InvariantCulture),

                    Racunarski_servis = DatabaseServiceProvider.Instance.GetServis(int.Parse(CmbBoxID_Servisa.Split('\n')[0])) as Racunarski_servis,
                    Serviser_racunara = DatabaseServiceProvider.Instance.GetServiserRacunara(long.Parse(CmbBoxID_Servisera.Split('\n')[0], CultureInfo.InvariantCulture))
                }))
                {
                    LBL = "Serviser " + CmbBoxID_Servisera + " uspjesno zaposlen u servis " + CmbBoxID_Servisa;
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    RadiSet = new ObservableCollection<Radi>(DatabaseServiceProvider.Instance.GetAllRadi());

                }
                else
                {
                    LBL = "Greska pri dodavanju servisera " + CmbBoxID_Servisera + " servisu " + CmbBoxID_Servisa + "!";
                    Foreground = Brushes.Red;
                }
            }catch(Exception e)
            {

            }
        }
        private void OnUpdate()
        {
            try
            {
                Servis s = DatabaseServiceProvider.Instance.GetServis(int.Parse(CmbBoxID_Servisa.Split('\n')[0], CultureInfo.InvariantCulture));

                DatabaseServiceProvider.Instance.UpdateRadi(new Radi()
                {
                    Racunarski_servisID_servisa1 = SelectedRadi.Racunarski_servisID_servisa1,
                    Serviser_racunaraJMBG_s = SelectedRadi.Serviser_racunaraJMBG_s,
                    Racunarski_servis = new Racunarski_servis()
                {
                    ID_servisa = s.ID_servisa,
                    Naziv_serv = s.Naziv_serv,
                    Tip_serv = (Tip_servisa)s.Tip_serv,
                    Adresa_serv = new Adresa()
                    {
                        Broj = s.Adresa_serv.Broj,
                        Grad = s.Adresa_serv.Grad,
                        PostanskiBroj = s.Adresa_serv.PostanskiBroj,
                        Ulica = s.Adresa_serv.Ulica
                    },
                    Br_tel_serv = new Broj_telefona()
                    {
                        Broj = s.Br_tel_serv.Broj,
                        Okrug = s.Br_tel_serv.Okrug,
                        Pozivni_broj = s.Br_tel_serv.Pozivni_broj
                    }
                },Serviser_racunara = DatabaseServiceProvider.Instance.GetServiserRacunara(long.Parse(CmbBoxID_Servisera.Split('\n')[0], CultureInfo.InvariantCulture))
                });

                LBL = "Asocijacija sa kljucem " + CmbBoxID_Servisera + "-" + CmbBoxID_Servisa + " uspjesno azurirana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                RadiSet = new ObservableCollection<Radi>(DatabaseServiceProvider.Instance.GetAllRadi());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju asocijacije 'radi'!";
                Foreground = Brushes.Red;
            }
        }
    }
}
