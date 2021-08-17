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
    public class ServisiraViewModel : BindableBase 
    {
        private ObservableCollection<Servisira> servisiraSet;
        private Servisira selectedServisira;
        private static List<string> donosiSet = MainWindow.Uloga.Equals("Serviser_racunara") ? 
            new List<string>(DatabaseServiceProvider.Instance.GetAllDonosi().Where(_ => _.Racunarski_servisID_servisa == DatabaseServiceProvider.Instance.VratiIDServisa(MainWindow.IdVlasnika
                )).Select(x => String.Format("Servis:"+x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara))) :
            new List<string>(DatabaseServiceProvider.Instance.GetAllDonosi().Select(x => String.Format("Servis:"+x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara)));
        private static List<string> radiSet = MainWindow.Uloga.Equals("Serviser_racunara") ?
            new List<string>(DatabaseServiceProvider.Instance.GetAllRadi().Where(_ => _.Serviser_racunaraJMBG_s == MainWindow.IdVlasnika).Select(x => String.Format("Servis:"+x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s))) :
            new List<string>(DatabaseServiceProvider.Instance.GetAllRadi().Select(x => String.Format("Servis:"+x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s)));
        private static List<string> garantniListovi = new List<string>(DatabaseServiceProvider.Instance.GetAllGarantni_listove().Select(x => String.Format("ID:"+x.Id_gar_list)));

        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));

        private string cmbBoxDonosi;
        private string cmbBoxRadi;
        private string cmbBoxGar_listovi;
        private string autorizacija;
        private string ulogaKorisnika;
        private DateTime dpDat_s = DateTime.Now;


        private string lbl = string.Empty;
        private string txtBoxCijena = string.Empty;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public ServisiraViewModel(string uloga)
        {
            if(uloga.Equals("Vlasnik_racunara"))
                ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira().
                               Where(_ => _.DonosiPosjedujeVlasnik_racunaraJMBG_vl == MainWindow.IdVlasnika));
            else if(uloga.Equals("Serviser_racunara"))
                ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira().
                               Where(_ => _.RadiServiser_racunaraJMBG_s == MainWindow.IdVlasnika));
            else
                ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira());

            UlogaKorisnika = uloga;
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
            
        }

        public ObservableCollection<Servisira> ServisiraSet
        {
            get
            {
                if (MainWindow.Uloga.Equals("Vlasnik_racunara"))
                    return new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira().
                                   Where(_ => _.DonosiPosjedujeVlasnik_racunaraJMBG_vl == MainWindow.IdVlasnika));
                else if (MainWindow.Uloga.Equals("Serviser_racunara"))
                    return new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira().
                                   Where(_ => _.RadiServiser_racunaraJMBG_s == MainWindow.IdVlasnika));
                else
                    return  new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira());
            }
            set
            {
                if (servisiraSet != value)
                {
                    servisiraSet = value;
                    OnPropertyChanged(nameof(ServisiraSet));
                }
            }
        }
        public Servisira SelectedServisira
        {
            get
            {
                return selectedServisira;
            }
            set
            {
                if (selectedServisira != value)
                {
                    selectedServisira = value;
                    OnPropertyChanged(nameof(SelectedServisira));
                    CmbBoxRadi = SelectedServisira == null ? "" : String.Format("Servis:" + SelectedServisira.DonosiRacunarski_servisID_servisa + " Serviser:" + SelectedServisira.RadiServiser_racunaraJMBG_s);
                    CmbBoxDonosi = SelectedServisira == null ? "" : String.Format("Servis:" + SelectedServisira.RadiRacunarski_servisID_servisa + " Vlasnik:" + SelectedServisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + SelectedServisira.DonosiPosjedujeRacunarID_racunara);
                    CmbBoxGar_listovi = SelectedServisira == null ? "" : String.Format("ID:" + SelectedServisira.Garantni_listId_gar_list);
                    DpDat_s = SelectedServisira == null ? DateTime.MinValue.Date : SelectedServisira.Dat_potp.Date;
                    TxTBoxCijena = SelectedServisira == null ? "" : SelectedServisira.Cijena_serv.ToString();

                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string CmbBoxDonosi
        {
            get => cmbBoxDonosi;
            set
            {
                cmbBoxDonosi = value;
                OnPropertyChanged("CmbBoxDonosi");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public List<string> DonosiSet
        {
            get => MainWindow.Uloga.Equals("Serviser_racunara") ?
            new List<string>(DatabaseServiceProvider.Instance.GetAllDonosi().Where(_ => _.Racunarski_servisID_servisa == DatabaseServiceProvider.Instance.VratiIDServisa(MainWindow.IdVlasnika
                )).Select(x => String.Format("Servis:" + x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara))) :
            new List<string>(DatabaseServiceProvider.Instance.GetAllDonosi().Select(x => String.Format("Servis:" + x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara)));
            set
            {
                if (donosiSet != value)
                {
                    donosiSet = value;
                    OnPropertyChanged("DonosiSet");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string UlogaKorisnika
        {
            get => ulogaKorisnika;
            set
            {
                ulogaKorisnika = value;
                Autorizacija = !ulogaKorisnika.Equals("Vlasnik_racunara") ? "Visible" : "Hidden";
                OnPropertyChanged("UlogaKorisnika");
                OnPropertyChanged("Autorizacija");
            }
        }
        public string Autorizacija
        {
            get => autorizacija;
            set
            {
                autorizacija = value;
                OnPropertyChanged("Autorizacija");
            }
        }
        public DateTime DpDat_s
        {
            get => dpDat_s;
            set
            {
                if (dpDat_s != value)
                {
                    dpDat_s = value;
                    OnPropertyChanged("DpDat_s");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public List<string> GarantniListovi
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllGarantni_listove().Select(x => String.Format("ID:" + x.Id_gar_list)));
            set
            {
                if (garantniListovi != value)
                {
                    garantniListovi = value;
                    OnPropertyChanged("GarantniListovi");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public List<string> RadiSet
        {
            get => MainWindow.Uloga.Equals("Serviser_racunara") ?
            new List<string>(DatabaseServiceProvider.Instance.GetAllRadi().Where(_ => _.Serviser_racunaraJMBG_s == MainWindow.IdVlasnika).Select(x => String.Format("Servis:" + x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s))) :
            new List<string>(DatabaseServiceProvider.Instance.GetAllRadi().Select(x => String.Format("Servis:" + x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s)));
            set
            {
                if (radiSet != value)
                {
                    radiSet = value;
                    OnPropertyChanged("RadiSet");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string CmbBoxRadi
        {
            get => cmbBoxRadi;
            set
            {
                cmbBoxRadi = value;
                OnPropertyChanged("CmbBoxRadi");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string CmbBoxGar_listovi
        {
            get => cmbBoxGar_listovi;
            set
            {
                cmbBoxGar_listovi = value;
                OnPropertyChanged("CmbBoxGar_listovi");
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

        public string TxTBoxCijena
        {
            get => txtBoxCijena;
            set
            {
                if (txtBoxCijena != value)
                {
                    txtBoxCijena = value;
                    OnPropertyChanged("TxTBoxCijena");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool CanDelete()
        {
            return SelectedServisira != null;
        }

        private void OnDelete()
        {
            int idServisa = SelectedServisira.DonosiRacunarski_servisID_servisa;
            int idRacunara = SelectedServisira.DonosiPosjedujeRacunarID_racunara;
            long idVlasnika = SelectedServisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl;
            long idServisera = SelectedServisira.RadiServiser_racunaraJMBG_s;
            if (DatabaseServiceProvider.Instance.DeleteServisira(idVlasnika, idRacunara, idServisa, idServisera))
            {
                LBL = "Veza 'servisira' ( " + idVlasnika + " - " + idRacunara + " + " + idServisa+ " + " + idServisera + " ) obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju asocijacije ( " + idVlasnika + " - " + idRacunara + " + " + idServisa + " + "+ idServisera+ " )";
                Foreground = Brushes.Red;
            }
            ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira());
            
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(CmbBoxRadi) &&
                   !String.IsNullOrEmpty(CmbBoxDonosi) &&
                   !String.IsNullOrEmpty(TxTBoxCijena) &&
                   !String.IsNullOrEmpty(DpDat_s.ToString()) &&
                    SelectedServisira == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(CmbBoxDonosi) &&
                   !String.IsNullOrEmpty(TxTBoxCijena) &&
                   !String.IsNullOrEmpty(DpDat_s.ToString()) &&
                   !String.IsNullOrEmpty(CmbBoxRadi);
        }

        private void OnAdd()
        {
            try
            {
                var cijena = double.Parse(TxTBoxCijena.Replace(',', '.'), CultureInfo.InvariantCulture);

            
            if (DpDat_s.Date > DateTime.Now.Date)
            {
                    LBL = "Greska pri servisiranju racunara!\nDatum servisiranja ne smije biti\nu buducnosti!";
                    Foreground = Brushes.Red;
                    return;
            }
            else {
                //"Servis:"+x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara
                string[] keyPartsDonosi = CmbBoxDonosi.Split(' ');
                //"Servis:"+x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s
                string[] keyPartsRadi = CmbBoxRadi.Split(' ');
                if(keyPartsDonosi[0] != keyPartsRadi[0])
                {
                        LBL = "Greska pri servisiranju racunara " + keyPartsDonosi[2].Split(':')[1] + " u servisu " + keyPartsDonosi[0].Split(':')[1] + "!\nID servisa se moraju poklapati!";
                        Foreground = Brushes.Red;
                        return;
                }

                if (DatabaseServiceProvider.Instance.AddServisira(new Servisira()
                {
                    DonosiPosjedujeVlasnik_racunaraJMBG_vl = long.Parse(keyPartsDonosi[1].Split(':')[1], CultureInfo.InvariantCulture),
                    DonosiPosjedujeRacunarID_racunara = int.Parse(keyPartsDonosi[2].Split(':')[1], CultureInfo.InvariantCulture),
                    DonosiRacunarski_servisID_servisa = int.Parse(keyPartsDonosi[0].Split(':')[1], CultureInfo.InvariantCulture),
                    RadiServiser_racunaraJMBG_s = long.Parse(keyPartsRadi[1].Split(':')[1], CultureInfo.InvariantCulture),
                    RadiRacunarski_servisID_servisa = int.Parse(keyPartsRadi[0].Split(':')[1], CultureInfo.InvariantCulture),
                    Donosi = DatabaseServiceProvider.Instance.GetDonosi(long.Parse(keyPartsDonosi[1].Split(':')[1], CultureInfo.InvariantCulture),
                                                                        int.Parse(keyPartsDonosi[2].Split(':')[1], CultureInfo.InvariantCulture),
                                                                        int.Parse(keyPartsDonosi[0].Split(':')[1], CultureInfo.InvariantCulture)),
                    Cijena_serv = double.Parse(TxTBoxCijena.ToString(), CultureInfo.InvariantCulture),
                    Dat_potp = DpDat_s,
                    Garantni_listId_gar_list = int.Parse(CmbBoxGar_listovi.Split(':')[1], CultureInfo.InvariantCulture),
                    Garantni_list = DatabaseServiceProvider.Instance.GetGarantni_list(int.Parse(CmbBoxGar_listovi.Split(':')[1], CultureInfo.InvariantCulture)),
                    Radi = DatabaseServiceProvider.Instance.GetRadi(long.Parse(keyPartsRadi[1].Split(':')[1], CultureInfo.InvariantCulture), int.Parse(keyPartsDonosi[0].Split(':')[1], CultureInfo.InvariantCulture))


                }))
                {
                    LBL = "Servis racunara " + keyPartsDonosi[2].Split(':')[1] + " uspjesno obavljen u servisu " + keyPartsRadi[0].Split(':')[1] + "\n - Obavio serviser " + keyPartsRadi[1].Split(':')[1];
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira());

                }
                else
                {
                    LBL = "Greska pri servisiranju racunara " + keyPartsDonosi[2].Split(':')[1] + " u servisu " + keyPartsDonosi[0].Split(':')[1] + "!";
                    Foreground = Brushes.Red;
                }
            }
            }
            catch (Exception e)
            {
                LBL = "Greska pri servisiranju racunara!\nCijena mora biti pozitivan broj \n(cio ili u formatu '0.0')!";
                Foreground = Brushes.Red;

            }
        }
        private void OnUpdate()
        {
            double cijena = 0;
            try
            {
                try
                {
                     cijena = double.Parse(TxTBoxCijena.Replace(',', '.'), CultureInfo.InvariantCulture);
                }catch(Exception e)
                {
                    LBL = "Greska pri servisiranju racunara!\nCijena mora biti pozitivan broj \n(cio ili u formatu '0.0')!";
                    Foreground = Brushes.Red;
                    return;
                }

                if (DpDat_s.Date > DateTime.Now.Date)
                {
                    LBL = "Greska pri servisiranju racunara!\nDatum servisiranja ne smije biti\nu buducnosti!";
                    Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    //"Servis:"+x.Racunarski_servisID_servisa + " Vlasnik:" + x.PosjedujeVlasnik_racunaraJMBG_vl + " Racunar:" + x.PosjedujeRacunarID_racunara
                    string[] keyPartsDonosi = CmbBoxDonosi.Split(' ');
                    //"Servis:"+x.Racunarski_servisID_servisa1 + " Serviser:" + x.Serviser_racunaraJMBG_s
                    string[] keyPartsRadi = CmbBoxRadi.Split(' ');

                    try
                    {
                        if (keyPartsDonosi[0] != keyPartsRadi[0])
                        {
                            LBL = "Greska pri servisiranju racunara " + keyPartsDonosi[2].Split(':')[1] + " u servisu " + keyPartsDonosi[0].Split(':')[1] + "!\nID servisa se moraju poklapati!";
                            Foreground = Brushes.Red;
                            return;
                        }
                        DatabaseServiceProvider.Instance.UpdateServisira(new Servisira()
                        {
                            DonosiPosjedujeVlasnik_racunaraJMBG_vl = SelectedServisira.DonosiPosjedujeVlasnik_racunaraJMBG_vl,
                            DonosiPosjedujeRacunarID_racunara = SelectedServisira.DonosiPosjedujeRacunarID_racunara,
                            DonosiRacunarski_servisID_servisa = SelectedServisira.DonosiRacunarski_servisID_servisa,
                            RadiServiser_racunaraJMBG_s = SelectedServisira.RadiServiser_racunaraJMBG_s,
                            RadiRacunarski_servisID_servisa = SelectedServisira.RadiRacunarski_servisID_servisa,
                            Donosi = DatabaseServiceProvider.Instance.GetDonosi(long.Parse(keyPartsDonosi[1].Split(':')[1], CultureInfo.InvariantCulture),
                                                                            int.Parse(keyPartsDonosi[2].Split(':')[1], CultureInfo.InvariantCulture),
                                                                            int.Parse(keyPartsDonosi[0].Split(':')[1], CultureInfo.InvariantCulture)),
                            Radi = DatabaseServiceProvider.Instance.GetRadi(long.Parse(keyPartsRadi[1].Split(':')[1], CultureInfo.InvariantCulture), int.Parse(keyPartsDonosi[0].Split(':')[1], CultureInfo.InvariantCulture)),
                            Cijena_serv = cijena,
                            Dat_potp = DpDat_s,
                            Garantni_listId_gar_list = int.Parse(CmbBoxGar_listovi.Split(':')[1], CultureInfo.InvariantCulture),
                            Garantni_list = DatabaseServiceProvider.Instance.GetGarantni_list(int.Parse(CmbBoxGar_listovi.Split(':')[1], CultureInfo.InvariantCulture)),
                        });

                        LBL = "Asocijacija sa kljucem " + keyPartsDonosi[0].Split(':')[1] + "+" + keyPartsDonosi[1].Split(':')[1]
                                                        + "-" + keyPartsDonosi[2].Split(':')[1] + "-" + keyPartsRadi[0].Split(':')[1]
                                                        + "-" + keyPartsRadi[1].Split(':')[1] + " uspjesno azurirana";
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                        ServisiraSet = new ObservableCollection<Servisira>(DatabaseServiceProvider.Instance.GetAllServisira());

                    }
                    catch (Exception e)
                    {
                        LBL = "Greska pri azuriranju asocijacije 'servisira'!";
                        Foreground = Brushes.Red;
                    }
                }
            }catch(Exception e)
            {

            }
        }
    }
}
