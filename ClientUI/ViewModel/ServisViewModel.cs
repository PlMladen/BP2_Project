﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientUI.ViewModel
{
    public class ServisViewModel : BindableBase
    {
        private ObservableCollection<Servis> servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());
        public static List<string> ServisTypes { get; set; } = new List<string> { Tip_servisa.Servis_racunara.ToString(), Tip_servisa.Servis_mobilnih_telefona.ToString() };

        public ObservableCollection<Servis> Servisi
        {
            get
            {
                return servisi;
            }
            set
            {
                if (servisi != value)
                {
                    servisi = value;
                    OnPropertyChanged(nameof(Servisi));
                }
            }
        }
        private Servis selectedServis;
        private string lbl = string.Empty;
        private string txTBoxNazivServ = "Naziv...";
        private string txTBoxAdresaUlica = "Ulica...";
        private string txTBoxAdresaBroj = "Broj...";
        private string txTBoxAdresaGrad = "Grad...";
        private string txTBoxAdresaPPTBroj = "Post. broj...";
        private string txTBoxBrTelPozBroj = "00381";
        private string txTBoxBrTelBrojOkruga = "65";
        private string txTBoxBrTelBroj = "1234567";
        private string selectedTypeServis = string.Empty;
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));



        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public ServisViewModel()
        {

            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public Servis SelectedServis
        {
            get
            {
                return selectedServis;
            }
            set
            {
                selectedServis = value;
                TxTBoxNazivServ = SelectedServis == null ? "Naziv..." : SelectedServis.Naziv_serv;
                TxTBoxAdresaUlica = SelectedServis == null ? "Ulica..." : SelectedServis.Adresa_serv.Ulica;
                TxTBoxAdresaBroj = SelectedServis == null ? "Broj..." : SelectedServis.Adresa_serv.Broj.ToString();
                TxTBoxAdresaGrad = SelectedServis == null ? "Grad..." : SelectedServis.Adresa_serv.Grad;
                TxTBoxAdresaPPTBroj = SelectedServis == null ? "Post. broj..." : SelectedServis.Adresa_serv.PostanskiBroj.ToString();
                TxTBoxBrTelPozBroj = SelectedServis == null ? "00381" : SelectedServis.Br_tel_serv.Pozivni_broj.ToString();
                TxTBoxBrTelBrojOkruga = SelectedServis == null ? "65" : SelectedServis.Br_tel_serv.Okrug.ToString();
                TxTBoxBrTelBroj = SelectedServis == null ? "1234567" : SelectedServis.Br_tel_serv.Broj.ToString();
                SelectedTypeServis = SelectedServis == null ? string.Empty : SelectedServis.Tip_serv.ToString();
                
                DeleteCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        public string SelectedTypeServis
        {
            get => selectedTypeServis;
            set
            {
                if (selectedTypeServis != value)
                {
                    selectedTypeServis = value;
                    OnPropertyChanged("SelectedTypeServis"); 
                    AddCommand.RaiseCanExecuteChanged();
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
        public string LBL
        {
            get => lbl;
            set
            {
                lbl = value;
                OnPropertyChanged("LBL");
            }
        }
        public string TxTBoxNazivServ
        {
            get => txTBoxNazivServ;
            set
            {
                txTBoxNazivServ = value;
                AddCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("TxTBoxNazivServ");
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxAdresaUlica
        {
            get => txTBoxAdresaUlica;
            set
            {
                txTBoxAdresaUlica = value;
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("TxTBoxAdresaUlica");
            }
        }
        public string TxTBoxAdresaBroj
        {
            get => txTBoxAdresaBroj;
            set
            {
                txTBoxAdresaBroj = value;
                OnPropertyChanged("TxTBoxAdresaBroj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxAdresaGrad
        {
            get => txTBoxAdresaGrad;
            set
            {
                txTBoxAdresaGrad = value;
                OnPropertyChanged("TxTBoxAdresaGrad");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxAdresaPPTBroj
        {
            get => txTBoxAdresaPPTBroj;
            set
            {
                txTBoxAdresaPPTBroj = value;
                OnPropertyChanged("TxTBoxAdresaPPTBroj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxBrTelPozBroj
        {
            get => txTBoxBrTelPozBroj;
            set
            {
                txTBoxBrTelPozBroj = value;
                OnPropertyChanged("TxTBoxBrTelPozBroj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxBrTelBrojOkruga
        {
            get => txTBoxBrTelBrojOkruga;
            set
            {
                txTBoxBrTelBrojOkruga = value;
                OnPropertyChanged("TxTBoxBrTelBrojOkruga");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxTBoxBrTelBroj
        {
            get => txTBoxBrTelBroj;
            set
            {
                txTBoxBrTelBroj = value;
                OnPropertyChanged("TxTBoxBrTelBroj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        private bool CanDelete()
        {
            return SelectedServis != null;
        }

        private void OnDelete()
        {
            int idServisa = SelectedServis.ID_servisa;
            if (DatabaseServiceProvider.Instance.DeleteServis(idServisa))
            {
                LBL = "Servis (ID: " + idServisa + ") obrisan";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju servisa - ID: " + idServisa;
                Foreground = Brushes.Red;
            }
            Servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxTBoxNazivServ) &&
                   !String.IsNullOrEmpty(SelectedTypeServis) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaUlica) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaBroj) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaGrad) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaPPTBroj) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelBroj) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelBrojOkruga) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelPozBroj) &&
                   TxTBoxAdresaPPTBroj.All(char.IsDigit) &&
                   TxTBoxBrTelBroj.All(char.IsDigit) &&
                   TxTBoxBrTelBrojOkruga.All(char.IsDigit) &&
                   TxTBoxBrTelPozBroj.All(char.IsDigit)
                   && SelectedServis == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxTBoxNazivServ) &&
                   !String.IsNullOrEmpty(SelectedTypeServis) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaUlica) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaBroj) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaGrad) &&
                   !String.IsNullOrEmpty(TxTBoxAdresaPPTBroj) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelBroj) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelBrojOkruga) &&
                   !String.IsNullOrEmpty(TxTBoxBrTelPozBroj) &&
                   TxTBoxAdresaPPTBroj.All(char.IsDigit) &&
                   TxTBoxBrTelBroj.All(char.IsDigit) &&
                   TxTBoxBrTelBrojOkruga.All(char.IsDigit) &&
                   TxTBoxBrTelPozBroj.All(char.IsDigit);
        }

        private void OnAdd()
        {
            if (DatabaseServiceProvider.Instance.AddServis(new Servis()
            {
                Naziv_serv = TxTBoxNazivServ,
                Tip_serv = (Tip_servisa)Enum.Parse(typeof(Tip_servisa), SelectedTypeServis),
                Adresa_serv = new Adresa()
                {
                    Ulica = TxTBoxAdresaUlica,
                    Grad = TxTBoxAdresaGrad,
                    Broj = Int32.Parse(TxTBoxAdresaBroj),
                    PostanskiBroj = Int32.Parse(TxTBoxAdresaPPTBroj)
                },
                Br_tel_serv = new Broj_telefona()
                {
                    Broj = Int32.Parse(TxTBoxBrTelPozBroj),
                    Okrug = Int32.Parse(TxTBoxBrTelBrojOkruga),
                    Pozivni_broj = Int32.Parse(TxTBoxBrTelBroj)
                }
            }))
            {
                LBL = "Novi servis uspjesno dodat \nu bazu!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());

            }
            else
            {
                LBL = "Greska pri dodavanju servisa!";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateServis(new Servis()
                {
                    ID_servisa = SelectedServis.ID_servisa,
                    Naziv_serv = TxTBoxNazivServ,
                    Tip_serv = (Tip_servisa)Enum.Parse(typeof(Tip_servisa), SelectedTypeServis),
                    Adresa_serv = new Adresa()
                    {
                        Ulica = TxTBoxAdresaUlica,
                        Grad = TxTBoxAdresaGrad,
                        Broj = Int32.Parse(TxTBoxAdresaBroj),
                        PostanskiBroj = Int32.Parse(TxTBoxAdresaPPTBroj)
                    },
                    Br_tel_serv = new Broj_telefona()
                    {
                        Broj = Int32.Parse(TxTBoxBrTelPozBroj),
                        Okrug = Int32.Parse(TxTBoxBrTelBrojOkruga),
                        Pozivni_broj = Int32.Parse(TxTBoxBrTelBroj)
                    }
                });

                LBL = "Servis [" + SelectedServis.ID_servisa + "] uspjesno azuriran!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju servisa!";
                Foreground = Brushes.Red;
            }
        }
    }
}