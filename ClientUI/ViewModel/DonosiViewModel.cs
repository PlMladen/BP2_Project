﻿using Common.Models;
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
    public class DonosiViewModel : BindableBase 
    {
        private ObservableCollection<Donosi> donosiSet = new ObservableCollection<Donosi>(DatabaseServiceProvider.Instance.GetAllDonosi());
        private Donosi selectedDonosi;
        private static List<string> servisi = new List<string>(DatabaseServiceProvider.Instance.GetAllServiss().Where(x => x.Tip_serv == Tip_servisa.Servis_racunara).Select(x => x.ID_servisa.ToString()));
        private static List<string> posjeduje = new List<string>(DatabaseServiceProvider.Instance.GetAllPosjeduje().Select(x =>  String.Format(x.JMBG_vl+"-"+x.Id_racunara)));
        //public static List<string> racunari = new List<string>(DatabaseServiceProvider.Instance.GetAllRacunari().Where(x => x.).Select(x => x.ID_racunara.ToString()));
        //public static List<string> vlasnici = new List<string>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara().Select(x => x.JMBG_vl.ToString()));

        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));

        private string cmbBoxPosjeduje;
        private string cmbBoxID_Servisa;


        private string lbl = string.Empty;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public DonosiViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Donosi> DonosiSet
        {
            get
            {
                return new ObservableCollection<Donosi>(DatabaseServiceProvider.Instance.GetAllDonosi());
            }
            set
            {
                if (donosiSet != value)
                {
                    donosiSet = value;
                    OnPropertyChanged(nameof(DonosiSet));
                }
            }
        }
        public Donosi SelectedDonosi
        {
            get
            {
                return selectedDonosi;
            }
            set
            {
                if (selectedDonosi != value)
                {
                    selectedDonosi = value;
                    OnPropertyChanged(nameof(SelectedDonosi));
                    CmbBoxPosjeduje = SelectedDonosi == null ? "" : String.Format(SelectedDonosi.PosjedujeVlasnik_racunaraJMBG_vl+"-"+SelectedDonosi.PosjedujeRacunarID_racunara);
                    CmbBoxID_Servisa = SelectedDonosi == null ? "" : SelectedDonosi.Racunarski_servisID_servisa.ToString();



                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string CmbBoxPosjeduje
        {
            get => cmbBoxPosjeduje;
            set
            {
                cmbBoxPosjeduje = value;
                OnPropertyChanged("CmbBoxPosjeduje");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public List<string> Servisi
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllServiss().Where(x => x.Tip_serv == Tip_servisa.Servis_racunara).Select(x => x.ID_servisa.ToString()));
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

        public List<string> Posjeduje
        {
            get => new List<string>(DatabaseServiceProvider.Instance.GetAllPosjeduje().Select(x => String.Format(x.JMBG_vl + "-" + x.Id_racunara)));
            set
            {
                if (posjeduje != value)
                {
                    posjeduje = value;
                    OnPropertyChanged("Posjeduje");
                    AddCommand.RaiseCanExecuteChanged();
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
            return SelectedDonosi != null;
        }

        private void OnDelete()
        {
            int idServisa = SelectedDonosi.Racunarski_servisID_servisa;
            int idRacunara = SelectedDonosi.PosjedujeRacunarID_racunara;
            long idVlasnika = SelectedDonosi.PosjedujeVlasnik_racunaraJMBG_vl;
            if (DatabaseServiceProvider.Instance.DeleteDonosi(idVlasnika, idRacunara, idServisa))
            {
                LBL = "Veza 'donosi' ( " + idVlasnika + " - " + idRacunara +" + "+ idServisa + " ) obrisana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju asocijacije ( " + idVlasnika + " - " + idRacunara + " + " + idServisa + " )";
                Foreground = Brushes.Red;
            }
            DonosiSet = new ObservableCollection<Donosi>(DatabaseServiceProvider.Instance.GetAllDonosi());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(CmbBoxPosjeduje) &&
                   !String.IsNullOrEmpty(CmbBoxID_Servisa) &&
                    SelectedDonosi == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(CmbBoxID_Servisa) &&
                   !String.IsNullOrEmpty(CmbBoxPosjeduje);
        }

        private void OnAdd()
        {
            string[] keyParts = CmbBoxPosjeduje.Split('-');
            if (DatabaseServiceProvider.Instance.AddDonosi(new Donosi()
            {
                PosjedujeVlasnik_racunaraJMBG_vl = long.Parse(keyParts[0], CultureInfo.InvariantCulture),
                PosjedujeRacunarID_racunara = int.Parse(keyParts[1], CultureInfo.InvariantCulture),
                Racunarski_servisID_servisa = int.Parse(CmbBoxID_Servisa, CultureInfo.InvariantCulture),
                
                Pposjeduje = DatabaseServiceProvider.Instance.GetPosjeduje(int.Parse(keyParts[1], CultureInfo.InvariantCulture), long.Parse(keyParts[0], CultureInfo.InvariantCulture)),
                Racunarski_servis = DatabaseServiceProvider.Instance.GetRacunarskiServis(int.Parse(CmbBoxID_Servisa)),
            }))
            {
                LBL = "Servis racunara " + keyParts[1] + " uspjesno obavljen u servisu " + CmbBoxID_Servisa;
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                DonosiSet = new ObservableCollection<Donosi>(DatabaseServiceProvider.Instance.GetAllDonosi());

            }
            else
            {
                LBL = "Greska pri servisiranju racunara " + keyParts[1] + " u servisu " + CmbBoxID_Servisa + "!";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            string[] keyParts = CmbBoxPosjeduje.Split('-');
            int r = SelectedDonosi.Racunarski_servisID_servisa;

            try
            {
               Servis s = DatabaseServiceProvider.Instance.GetServis(int.Parse(CmbBoxID_Servisa, CultureInfo.InvariantCulture));

                DatabaseServiceProvider.Instance.UpdateDonosi(new Donosi()
                {
                    PosjedujeVlasnik_racunaraJMBG_vl = SelectedDonosi.PosjedujeVlasnik_racunaraJMBG_vl,
                    PosjedujeRacunarID_racunara = SelectedDonosi.PosjedujeRacunarID_racunara,
                    Racunarski_servisID_servisa = SelectedDonosi.Racunarski_servisID_servisa,

                    Pposjeduje = DatabaseServiceProvider.Instance.GetPosjeduje(int.Parse(keyParts[1], CultureInfo.InvariantCulture), long.Parse(keyParts[0], CultureInfo.InvariantCulture)),
                    Racunarski_servis = DatabaseServiceProvider.Instance.GetRacunarskiServis(int.Parse(CmbBoxID_Servisa)),
                });

                LBL = "Asocijacija sa kljucem " + keyParts[0] + "+"+keyParts[1]+ "-" + CmbBoxID_Servisa + " uspjesno azurirana";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                DonosiSet = new ObservableCollection<Donosi>(DatabaseServiceProvider.Instance.GetAllDonosi());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju asocijacije 'donosi'!";
                Foreground = Brushes.Red;
            }
        }
    }
}
