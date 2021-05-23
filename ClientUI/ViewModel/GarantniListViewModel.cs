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
    public class GarantniListViewModel : BindableBase
    {
        private ObservableCollection<Garantni_list> gListovi = new ObservableCollection<Garantni_list>(DatabaseServiceProvider.Instance.GetAllGarantni_listove());
        private Garantni_list selectedGList;
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        private string txTBoxIDGL;
        private string lbl;
        private DateTime dpVaziDo = DateTime.Now;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public GarantniListViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Garantni_list> GarantniListovi
        {
            get
            {
                return gListovi;
            }
            set
            {
                if (gListovi != value)
                {
                    gListovi = value;
                    OnPropertyChanged(nameof(GarantniListovi));
                }
            }
        }
        public Garantni_list SelectedGList
        {
            get
            {
                return selectedGList;
            }
            set
            {
                if (selectedGList != value)
                {
                    selectedGList = value;
                    OnPropertyChanged(nameof(SelectedGList));
                    TxTBoxIDGL = SelectedGList == null ? "12345" : SelectedGList.Id_gar_list.ToString();
                    
                    DpVaziDo = SelectedGList == null ? DateTime.Now : SelectedGList.Period_vazenja;


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
        public string TxTBoxIDGL
        {
            get => txTBoxIDGL;
            set
            {
                if (txTBoxIDGL != value)
                {
                    txTBoxIDGL = value;
                    OnPropertyChanged("TxTBoxIDGL");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        
        public DateTime DpVaziDo
        {
            get => dpVaziDo;
            set
            {
                if (dpVaziDo != value)
                {
                    dpVaziDo = value;
                    OnPropertyChanged("DpVaziDo");
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
        private bool CanDelete()
        {
            return SelectedGList != null;
        }

        private void OnDelete()
        {
            int idgl= SelectedGList.Id_gar_list;
            if (DatabaseServiceProvider.Instance.DeleteGarantni_list(idgl))
            {
                LBL = "Garantni list (ID: " + idgl + ") obrisan";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju garantnog lista - ID: " + idgl;
                Foreground = Brushes.Red;
            }
            GarantniListovi = new ObservableCollection<Garantni_list>(DatabaseServiceProvider.Instance.GetAllGarantni_listove());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxTBoxIDGL) &&
                   !String.IsNullOrEmpty(DpVaziDo.ToString()) &&
                    SelectedGList == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxTBoxIDGL) &&
                   !String.IsNullOrEmpty(DpVaziDo.ToString());
        }

        private void OnAdd()
        {
            if (DatabaseServiceProvider.Instance.AddGarantni_list(new Garantni_list()
            {
                Id_gar_list = int.Parse(TxTBoxIDGL, CultureInfo.InvariantCulture),
                Period_vazenja = DateTime.Parse(DpVaziDo.ToString())
            }))
            {
                LBL = "Novi garantni list uspjesno dodat \nu bazu!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                GarantniListovi = new ObservableCollection<Garantni_list>(DatabaseServiceProvider.Instance.GetAllGarantni_listove());

            }
            else
            {
                LBL = "Greska pri dodavanju garantnog lista!";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateGarantni_list(new Garantni_list()
                {
                    Id_gar_list = int.Parse(SelectedGList.Id_gar_list.ToString(), CultureInfo.InvariantCulture),
                    Period_vazenja = DateTime.Parse(DpVaziDo.ToString())
                });

                LBL = "Garantni list [" + SelectedGList.Id_gar_list + "] uspjesno azuriran!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                GarantniListovi = new ObservableCollection<Garantni_list>(DatabaseServiceProvider.Instance.GetAllGarantni_listove());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju garantnog lista!";
                Foreground = Brushes.Red;
            }
        }
    }
}
