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
    public class SastojiSeViewModel : BindableBase
    {
        private ObservableCollection<SastojiSe> sastojiSeSet = new ObservableCollection<SastojiSe>(DatabaseServiceProvider.Instance.GetAllSastojiSe());
        private SastojiSe selectedSastojiSe;
        private static List<string> komponentaKontejner = new List<string>(DatabaseServiceProvider.Instance.GetAllKomponente().Select(x => String.Format(x.Id_komp+"\n"+x.Naz_komp)));
        public static List<string> komponentaSastDio = new List<string>(DatabaseServiceProvider.Instance.GetAllKomponente().Select(x => String.Format(x.Id_komp + "\n" + x.Naz_komp)));

        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));

        private string cmbBoxID_KontKomponente;
        private string cmbBoxID_SastDioKomponenta;


        private string lbl;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public SastojiSeViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<SastojiSe> SastojiSeSet
        {
            get
            {
                return new ObservableCollection<SastojiSe>(DatabaseServiceProvider.Instance.GetAllSastojiSe());
            }
            set
            {
                if (sastojiSeSet != value)
                {
                    sastojiSeSet = value;
                    OnPropertyChanged(nameof(SastojiSeSet));
                }
            }
        }
        public SastojiSe SelectedSastojiSe
        {
            get
            {
                return selectedSastojiSe;
            }
            set
            {
                if (selectedSastojiSe != value)
                {
                    selectedSastojiSe = value;
                    OnPropertyChanged(nameof(SelectedSastojiSe));
                    CmbBoxID_KontKomponente = SelectedSastojiSe == null ? "" : String.Format(SelectedSastojiSe.KomponentaId_komp + "\n" + SelectedSastojiSe.Komponenta.Naz_komp);
                    CmbBoxID_SastDioKomponenta = SelectedSastojiSe == null ? "" : String.Format(SelectedSastojiSe.KomponentaId_komp1 + "\n" + SelectedSastojiSe.Komponenta1.Naz_komp);



                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string CmbBoxID_KontKomponente
        {
            get => cmbBoxID_KontKomponente;
            set
            {
                cmbBoxID_KontKomponente = value;
                OnPropertyChanged("CmbBoxID_KontKomponente");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public List<string> KomponentaKontejner
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllKomponente().Select(x => String.Format(x.Id_komp + "\n" + x.Naz_komp)));
            set
            {
                if (komponentaKontejner != value)
                {
                    komponentaKontejner = value;
                    OnPropertyChanged("KomponentaKontejner");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public List<string> KomponentaSastDio
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllKomponente().Select(x => String.Format(x.Id_komp + "\n" + x.Naz_komp)));
            set
            {
                if (komponentaSastDio != value)
                {
                    komponentaSastDio = value;
                    OnPropertyChanged("KomponentaSastDio");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string CmbBoxID_SastDioKomponenta
        {
            get => cmbBoxID_SastDioKomponenta;
            set
            {
                cmbBoxID_SastDioKomponenta = value;
                OnPropertyChanged("CmbBoxID_SastDioKomponenta");
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
            return SelectedSastojiSe != null;
        }

        private void OnDelete()
        {
            int idKontKomp = SelectedSastojiSe.KomponentaId_komp;
            int idKomponenteDijela = SelectedSastojiSe.KomponentaId_komp1;
            if (DatabaseServiceProvider.Instance.DeleteSastojiSe(idKontKomp, idKomponenteDijela))
            {
                LBL = "Veza 'sastoji se' ( " + idKontKomp + " - " + idKomponenteDijela + " ) obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju asocijacije ( " + idKontKomp + " - " + idKomponenteDijela + " )";
                Foreground = Brushes.Red;
            }
            SastojiSeSet = new ObservableCollection<SastojiSe>(DatabaseServiceProvider.Instance.GetAllSastojiSe());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(CmbBoxID_KontKomponente) &&
                   !String.IsNullOrEmpty(CmbBoxID_SastDioKomponenta) &&
                    SelectedSastojiSe == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(CmbBoxID_SastDioKomponenta) &&
                   !String.IsNullOrEmpty(CmbBoxID_KontKomponente);
        }

        private void OnAdd()
        {
            try
            {
                if (DatabaseServiceProvider.Instance.AddSastojiSe(new SastojiSe()
                {
                    KomponentaId_komp = int.Parse(CmbBoxID_KontKomponente.Split('\n')[0], CultureInfo.InvariantCulture),
                    KomponentaId_komp1 = int.Parse(CmbBoxID_SastDioKomponenta.Split('\n')[0], CultureInfo.InvariantCulture),
                    Komponenta = DatabaseServiceProvider.Instance.GetKomponentu(int.Parse(CmbBoxID_KontKomponente.Split('\n')[0], CultureInfo.InvariantCulture)),
                    Komponenta1 = DatabaseServiceProvider.Instance.GetKomponentu(int.Parse(CmbBoxID_SastDioKomponenta.Split('\n')[0], CultureInfo.InvariantCulture))
                }))
                {
                    LBL = "Komponenta " + CmbBoxID_SastDioKomponenta + " uspjesno ugradjena u komponentu " + CmbBoxID_KontKomponente;
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    SastojiSeSet = new ObservableCollection<SastojiSe>(DatabaseServiceProvider.Instance.GetAllSastojiSe());

                }
                else
                {
                    LBL = "Greska pri nadogradnji komponente " + CmbBoxID_KontKomponente + " komponentom " + CmbBoxID_SastDioKomponenta + "!";
                    Foreground = Brushes.Red;
                }
            }
            catch(Exception e)
            {

            }
        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateSastojiSe(new SastojiSe()
                {
                    KomponentaId_komp = SelectedSastojiSe.KomponentaId_komp,
                    KomponentaId_komp1 = SelectedSastojiSe.KomponentaId_komp1,
                    Komponenta = DatabaseServiceProvider.Instance.GetKomponentu(int.Parse(CmbBoxID_KontKomponente.Split('\n')[0], CultureInfo.InvariantCulture)),
                    Komponenta1 = DatabaseServiceProvider.Instance.GetKomponentu(int.Parse(CmbBoxID_SastDioKomponenta.Split('\n')[0], CultureInfo.InvariantCulture))
                });

                LBL = "Asocijacija sa kljucem " + CmbBoxID_KontKomponente +"-"+CmbBoxID_SastDioKomponenta + " uspjesno azurirana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                SastojiSeSet = new ObservableCollection<SastojiSe>(DatabaseServiceProvider.Instance.GetAllSastojiSe());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju asocijacije 'sastoji se'!";
                Foreground = Brushes.Red;
            }
        }
    }
}
