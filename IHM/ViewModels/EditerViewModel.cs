using IHM.Factory;
using IHM.Models;
using IHM.Views;
using Library;
using Metier;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IHM.ViewModels
{
    public class EditerViewModel : NotifyPropertyChangedBase
    {

        public EditerViewModel(CompositeurIHM c)
        {

            AnnulerCommand = new DelegateCommand(Annuler);
            ValiderCommand = new DelegateCommand(Valider);
            ParcourirCommand = new DelegateCommand(Parcourir);
            EditerOeuvreCommand = new DelegateCommand(EditerOeuvre);
            Data = DataManager.Get();
            CompoInitial = c; 
            if (CompoInitial == null)
            {
                CompoModifie = new CompositeurIHM();
            }
            else
            {
                CompoModifie = new CompositeurIHM(c);
            }
            
        }

        #region Propriétés

        private CompositeurIHM _CompoInitial;
        

        private CompositeurIHM _CompoModifie;

        public CompositeurIHM CompoInitial
        {
            get
            {
                return _CompoInitial;
            }

            set
            {
                _CompoInitial = value;
                NotifyPropertyChanged("CompoInitial");
            }
        }

        public CompositeurIHM CompoModifie
        {
            get
            {
                return _CompoModifie;
            }

            set
            {
                _CompoModifie = value;
                NotifyPropertyChanged("CompoModifie");
            }
        }

        
        private DataManager Data
        {
            get;
            set;
        }
        #endregion

        #region Boutons

        public DelegateCommand ParcourirCommand
        {
            get;
            set;
        }

        private void Parcourir(object o)
        {
            OpenFileDialog fen = new OpenFileDialog();
            fen.ShowDialog();
            CompoModifie.CheminImage = fen.FileName;
            NotifyPropertyChanged("CompoModifie");
        }

        public DelegateCommand ValiderCommand
        {
            get;
            set;
        }

        private void Valider(object o)
        {
            if (CompoModifie.Nom != null && CompoModifie.Prenom != null)
            {
                if (CompoInitial == null)
                {
                    Data.Ajouter(CompositeurFactory.ConvertBackCompositeur(CompoModifie));
                }
                else
                {
                    Data.Modifier(CompositeurFactory.ConvertBackCompositeur(CompoInitial), CompositeurFactory.ConvertBackCompositeur(CompoModifie));
                }
                Fermer(this, EventArgs.Empty);
            }
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

        public DelegateCommand EditerOeuvreCommand
        {
            get;
            set;
        }

        private EditerOeuvre fen;

        private void FermerFen(object sender, EventArgs e)
        {
            fen.Close();
        }

        private void EditerOeuvre(object o)
        {
            fen = new EditerOeuvre(CompoModifie);
            fen.Title = "Editer";
            fen.ViewModel.Fermer += FermerFen;
            fen.ShowDialog();
            fen.ViewModel.Fermer -= FermerFen;
        }

        

        #endregion
    }
}
