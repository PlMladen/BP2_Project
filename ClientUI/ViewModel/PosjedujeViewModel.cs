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
    public class PosjedujeViewModel : BindableBase
    {
        private ObservableCollection<Posjeduje> posjedujeSet = new ObservableCollection<Posjeduje>(DatabaseServiceProvider.Instance.GetAllPosjeduje());
        private Posjeduje selectedPosjeduje;
        private static List<string> vlasnici = new List<string>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara().Select(x =>  x.JMBG_vl.ToString() ));
        public static List<string> racunari = new List<string>(DatabaseServiceProvider.Instance.GetAllRacunari().Select(x => x.ID_racunara.ToString()));

        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        
        private string cmbBoxID_racunara;
        private string cmbBoxJMBG_Vl;
        

        private string lbl;
        private DateTime dpDat_rodj_vl = DateTime.Now;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public PosjedujeViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Posjeduje> PosjedujeSet
        {
            get
            {
                return new ObservableCollection<Posjeduje>(DatabaseServiceProvider.Instance.GetAllPosjeduje());
            }
            set
            {
                if (posjedujeSet != value)
                {
                    posjedujeSet = value;
                    OnPropertyChanged(nameof(PosjedujeSet));
                }
            }
        }
        public Posjeduje SelectedPosjeduje
        {
            get
            {
                return selectedPosjeduje;
            }
            set
            {
                if (selectedPosjeduje != value)
                {
                    selectedPosjeduje = value;
                    OnPropertyChanged(nameof(SelectedPosjeduje));
                    CmbBoxID_racunara = SelectedPosjeduje == null ? "" : SelectedPosjeduje.Id_racunara.ToString();
                    CmbBoxJMBG_Vl = SelectedPosjeduje == null ? "" : SelectedPosjeduje.JMBG_vl.ToString();
                    


                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
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

        public List<string> Vlasnici
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara().Select(x => x.JMBG_vl.ToString()));
            set
            {
                if (vlasnici != value)
                {
                    vlasnici = value;
                    OnPropertyChanged("Vlasnici");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public List<string> Racunari
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllRacunari().Select(x => x.ID_racunara.ToString()));
            set
            {
                if (racunari != value)
                {
                    racunari = value;
                    OnPropertyChanged("Racunari");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string CmbBoxJMBG_Vl
        {
            get => cmbBoxJMBG_Vl;
            set
            {
                cmbBoxJMBG_Vl = value;
                OnPropertyChanged("CmbBoxJMBG_Vl");
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
            return SelectedPosjeduje != null;
        }

        private void OnDelete()
        {
            long idVlasnika = SelectedPosjeduje.JMBG_vl;
            int idRacunara = SelectedPosjeduje.Id_racunara;
            if (DatabaseServiceProvider.Instance.DeletePosjeduje(idRacunara, idVlasnika))
            {
                LBL = "Veza 'posjeduje' ( " + idVlasnika + " - "+idRacunara +" ) obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju asocijacije ( " + idVlasnika+" - "+idRacunara+" )";
                Foreground = Brushes.Red;
            }
            PosjedujeSet = new ObservableCollection<Posjeduje>(DatabaseServiceProvider.Instance.GetAllPosjeduje());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(CmbBoxID_racunara) &&
                   !String.IsNullOrEmpty(CmbBoxJMBG_Vl) &&
                    SelectedPosjeduje == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(CmbBoxID_racunara) &&
                   !String.IsNullOrEmpty(CmbBoxJMBG_Vl) ;
        }

        private void OnAdd()
        {
            if (DatabaseServiceProvider.Instance.AddPosjeduje(new Posjeduje()
            {
                Id_racunara = int.Parse(CmbBoxID_racunara, CultureInfo.InvariantCulture),
                JMBG_vl = long.Parse(CmbBoxJMBG_Vl, CultureInfo.InvariantCulture),
                Racunar = DatabaseServiceProvider.Instance.GetRacunar(int.Parse(CmbBoxID_racunara, CultureInfo.InvariantCulture)),
                Vlasnik_racunara = DatabaseServiceProvider.Instance.GetVlasnikRacunara(long.Parse(CmbBoxJMBG_Vl, CultureInfo.InvariantCulture))
            }))
            {
                LBL = "Racunar "+ CmbBoxID_racunara +" uspjesno dodat vlasniku "+CmbBoxJMBG_Vl;
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                PosjedujeSet = new ObservableCollection<Posjeduje>(DatabaseServiceProvider.Instance.GetAllPosjeduje());

            }
            else
            {
                LBL = "Greska pri dodavanju racunara vlasniku!";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdatePosjeduje(new Posjeduje()
                {
                    Id_racunara = SelectedPosjeduje.Id_racunara,
                    JMBG_vl = SelectedPosjeduje.JMBG_vl,
                    Racunar = DatabaseServiceProvider.Instance.GetRacunar(int.Parse(CmbBoxID_racunara, CultureInfo.InvariantCulture)),
                    Vlasnik_racunara = DatabaseServiceProvider.Instance.GetVlasnikRacunara(long.Parse(CmbBoxJMBG_Vl, CultureInfo.InvariantCulture))
                });
                
                LBL = "Racunar " + CmbBoxID_racunara + " uspjesno azuriran za vlasnika " + CmbBoxJMBG_Vl;
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                PosjedujeSet = new ObservableCollection<Posjeduje>(DatabaseServiceProvider.Instance.GetAllPosjeduje());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju asocijacije 'posjeduje'!";
                Foreground = Brushes.Red;
            }
        }
    }
}
