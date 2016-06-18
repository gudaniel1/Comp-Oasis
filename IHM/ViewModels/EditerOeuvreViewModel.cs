using IHM.Models;
using Library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IHM.ViewModels
{
    public class EditerOeuvreViewModel : NotifyPropertyChangedBase
    {
        private CompositeurIHM _compositeurAncien;

        public EditerOeuvreViewModel(CompositeurIHM c)
        {
            _compositeurAncien = c;
            Compositeur = new CompositeurIHM(c);

            AnnulerCommand = new DelegateCommand(Annuler);
            ValiderCommand = new DelegateCommand(Valider);
            ParcourirCommand = new DelegateCommand(Parcourir, CanParcourir);
            SupprimerCommand = new DelegateCommand(Supprimer, CanSupprimer);
            AjouterCommand = new DelegateCommand(Ajouter);
            

        }

        private CompositeurIHM _compositeur;
        public CompositeurIHM Compositeur
        {
            get
            {
                return _compositeur;
            }

            set
            {
                _compositeur = value;
                NotifyPropertyChanged("Compositeur");
            }
        }

        private OeuvreIHM _oeuvreSelectionne;
        public OeuvreIHM OeuvreSelectionne
        {
            get
            {
                return _oeuvreSelectionne;
            }

            set
            {
                _oeuvreSelectionne = value;
                NotifyPropertyChanged("OeuvreSelectionne");
                SupprimerCommand.RaiseCanExecuteChanged();
                ParcourirCommand.RaiseCanExecuteChanged();
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged("SelectedIndex");
            }
        }

        #region Commandes

        public DelegateCommand ParcourirCommand
        {
            get;
            set;
        }

        private void Parcourir(object o)
        {
            OpenFileDialog fen = new OpenFileDialog();
            fen.Filter = "Fichier MP3 (*.mp3)|*.mp3";
            fen.ShowDialog();
            OeuvreSelectionne.CheminMusique = fen.FileName;
            NotifyPropertyChanged("OeuvreSelectionne");
            NotifyPropertyChanged("Compositeur");
        }

        private bool CanParcourir(object o)
        {
            return OeuvreSelectionne != null;
        }

        public DelegateCommand AjouterCommand
        {
            get;
            set;
        }

        private void Ajouter(object o)
        {
            Compositeur.Oeuvres.Add(new OeuvreIHM() { Nom = "Nouvelle Oeuvre" });
            SelectedIndex = Compositeur.Oeuvres.Count - 1;
        }

        public DelegateCommand SupprimerCommand
        {
            get;
            set;
        }

        private void Supprimer(object o)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous réellement supprimer : " + OeuvreSelectionne, "Attention !!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {    //suppression
                Compositeur.Oeuvres.Remove(OeuvreSelectionne);
            }
        }

        private bool CanSupprimer(object o)
        {
            return OeuvreSelectionne != null;
        }

        public DelegateCommand ValiderCommand
        {
            get;
            set;
        }

        private void Valider(object o)
        {
            _compositeurAncien.Oeuvres = Compositeur.Oeuvres;
            Fermer(this, EventArgs.Empty);
        }

        public DelegateCommand AnnulerCommand
        {
            get;
            set;
        }

        

        private void Annuler(object o)
        {
            Fermer(this, EventArgs.Empty);
        }

        public event EventHandler Fermer;
        
        #endregion





    }
}
