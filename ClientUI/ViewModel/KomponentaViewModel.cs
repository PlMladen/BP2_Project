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
    public class KomponentaViewModel : BindableBase
    {
        private ObservableCollection<Komponenta> komponente = new ObservableCollection<Komponenta>(DatabaseServiceProvider.Instance.GetAllKomponente());
        public static List<string> racunarIDs = new List<string>(DatabaseServiceProvider.Instance.GetAllRacunari().Select(x => String.Format(x.ID_racunara + " " + x.Proizvodjac))) { ""};
        private Komponenta selectedKomponenta;
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        //private string txTBoxID_Komponente;
        private string txTBoxNazKomp;
        private string txtCijenaKomp;
        
        private string cmbBoxID_racunara;
        private string lbl = string.Empty;

        private bool canEdit;

        public bool CanEdit 
        {
            get
            {
                return canEdit;
            }
            set {
                if (canEdit != value) {
                    canEdit = value;
                    OnPropertyChanged("CanEdit");
                }
            } 
        }

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public KomponentaViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Komponenta> Komponente
        {
            get
            {
                return komponente;
            }
            set
            {
                if (komponente != value)
                {
                    komponente = value;
                    OnPropertyChanged(nameof(Komponente));
                }
            }
        }
        public Komponenta SelectedKomponenta
        {
            get
            {
                return selectedKomponenta;
            }
            set
            {
                if (selectedKomponenta != value)
                {
                    selectedKomponenta = value;
                    OnPropertyChanged(nameof(SelectedKomponenta));
                    //TxTBoxID_Racunara = SelectedRacunar == null ? "1234567891234" : SelectedRacunar.ID_racunara.ToString();
                    //TxTBoxID_Komponente = SelectedKomponenta == null ? "123" : SelectedKomponenta.Id_komp.ToString();
                    TxTBoxNazKomp = SelectedKomponenta == null ? "Naziv..." : SelectedKomponenta.Naz_komp.ToString();
                    TxtCijenaKomp = SelectedKomponenta == null ? "100.50" : SelectedKomponenta.Cijena_komp.ToString();
                    if (SelectedKomponenta != null)
                    {
                        if (SelectedKomponenta.Racunar != null)
                            CmbBoxID_racunara = SelectedKomponenta == null ? "" : String.Format(SelectedKomponenta.RacunarID_racunara + " " + SelectedKomponenta.Racunar.Proizvodjac);
                        else
                            CmbBoxID_racunara = SelectedKomponenta == null ? "" : String.Format(SelectedKomponenta.RacunarID_racunara + " ");
                    }
                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
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
        /*public string TxTBoxID_Komponente
        {
            get => txTBoxID_Komponente;
            set
            {
                if (txTBoxID_Komponente != value)
                {
                    txTBoxID_Komponente = value;
                    OnPropertyChanged("TxTBoxID_Komponente");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }*/
        public string TxTBoxNazKomp
        {
            get => txTBoxNazKomp;
            set
            {
                if (txTBoxNazKomp != value)
                {
                    txTBoxNazKomp = value;
                    OnPropertyChanged("TxTBoxNazKomp");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxtCijenaKomp
        {
            get => txtCijenaKomp;
            set
            {
                if (txtCijenaKomp != value)
                {
                    txtCijenaKomp = value;
                    
                    OnPropertyChanged("TxtCijenaKomp");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public List<string> RacunarIDs
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllRacunari().Select(x => String.Format(x.ID_racunara + " " + x.Proizvodjac))) { 
            ""
            
            };
            set
            {
                if (racunarIDs != value)
                {
                    racunarIDs = value;
                    
                    OnPropertyChanged("RacunarIDs");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
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
        
        public string CmbBoxID_racunara
        {
            get => cmbBoxID_racunara;
            set
            {
                cmbBoxID_racunara = value;
                OnPropertyChanged("CmbBoxID_racunara");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanDelete()
        {
            CanEdit = SelectedKomponenta != null;
            return SelectedKomponenta != null;
        }

        private void OnDelete()
        {
            int idKomponente = SelectedKomponenta.Id_komp;
            if (DatabaseServiceProvider.Instance.DeleteKomponentu(idKomponente))
            {
                LBL = "Komponenta (ID: " + idKomponente + ") obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju komponente - ID: " + idKomponente;
                Foreground = Brushes.Red;
            }
            Komponente = new ObservableCollection<Komponenta>(DatabaseServiceProvider.Instance.GetAllKomponente());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxtCijenaKomp) &&
                   !String.IsNullOrEmpty(TxTBoxNazKomp) &&
                   //!String.IsNullOrEmpty(TxTBoxID_Komponente) &&   
                    SelectedKomponenta == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxtCijenaKomp) &&
                   !String.IsNullOrEmpty(TxTBoxNazKomp);
                   //!String.IsNullOrEmpty(TxTBoxID_Komponente);
        }

        private void OnAdd()
        {
            try {
                
               var cijena =  double.Parse(TxtCijenaKomp.Replace(',','.'), CultureInfo.InvariantCulture);
                
                if (DatabaseServiceProvider.Instance.AddKomponentu(new Komponenta()
                {
                    //Id_komp = int.Parse(TxTBoxID_Komponente, CultureInfo.InvariantCulture),
                    Cijena_komp = cijena,
                    Naz_komp = TxTBoxNazKomp,
                    RacunarID_racunara = string.IsNullOrEmpty(CmbBoxID_racunara) ? 0 : int.Parse(CmbBoxID_racunara.Split(' ')[0], CultureInfo.InvariantCulture),
                    Racunar = DatabaseServiceProvider.Instance.GetRacunar(string.IsNullOrEmpty(CmbBoxID_racunara) ? 0 : int.Parse(CmbBoxID_racunara.Split(' ')[0], CultureInfo.InvariantCulture))
                }))
                {
                    LBL = "Nova komponenta uspjesno dodata \nu bazu!";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    Komponente = new ObservableCollection<Komponenta>(DatabaseServiceProvider.Instance.GetAllKomponente());

                }
                else
                {
                    LBL = "Greska pri dodavanju komponente!";
                    Foreground = Brushes.Red;
                }
            }
            catch (Exception e)
            {
                LBL = "Greska pri dodavanju komponente!\nCijena mora biti u formatu '0000.00'";
                Foreground = Brushes.Red;
            }

        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateKomponentu(new Komponenta()
                {
                    Id_komp = int.Parse(SelectedKomponenta.Id_komp.ToString(), CultureInfo.InvariantCulture),
                    Cijena_komp = double.Parse(TxtCijenaKomp, CultureInfo.InvariantCulture),
                    Naz_komp = TxTBoxNazKomp,
                    RacunarID_racunara = string.IsNullOrEmpty(CmbBoxID_racunara.Split(' ')[0]) ? -1 : int.Parse(CmbBoxID_racunara.Split(' ')[0], CultureInfo.InvariantCulture)
                });

                LBL = "Komponenta [" + SelectedKomponenta.Id_komp + "] uspjesno azurirana!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Komponente = new ObservableCollection<Komponenta>(DatabaseServiceProvider.Instance.GetAllKomponente());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju komponente!";
                Foreground = Brushes.Red;
            }
        }
    }
}
