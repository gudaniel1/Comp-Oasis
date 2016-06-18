using IHM.Factory;
using IHM.Models;
using IHM.Views;
using Library;
using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IHM.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés

        private ObservableCollection<CompositeurIHM> _listeCompo;
        public ObservableCollection<CompositeurIHM> ListeCompo
        {
            get
            {
                return _listeCompo;
            }

            set
            {
                _listeCompo = value;
                NotifyPropertyChanged("ListeCompo");
            }
        }

        private CompositeurIHM _SelectedCompositeur;
        public CompositeurIHM SelectedCompositeur
        {
            get
            {
                return _SelectedCompositeur;
            }

            set
            {
                _SelectedCompositeur = value;
                NotifyPropertyChanged("SelectedCompositeur");
                EditerCommand.RaiseCanExecuteChanged();
                SupprimerCommand.RaiseCanExecuteChanged();
            }
        }

        private MediaPlayer mediaPlayer = new MediaPlayer();

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
                //mediaPlayer.Stop();
                if (value != null)
                {
                    mediaPlayer.Open(new Uri(value.CheminMusique));
                }
                PlayCommand.RaiseCanExecuteChanged();
                PauseCommand.RaiseCanExecuteChanged();
                StopCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commandes

        private EditerView fen;

        private void FermerFen(object sender, EventArgs e)
        {
            fen.Close();
        }

        #region Ajouter
        public DelegateCommand AjouterCommand
        {
            get;
            set;
        }

        private void Ajouter(object o)
        {
            fen = new EditerView(null);
            fen.Title = "Ajouter";
            fen.ViewModel.Fermer += FermerFen;
            fen.ShowDialog();
            fen.ViewModel.Fermer -= FermerFen;
        }

       
        #endregion

        #region Editer

        public DelegateCommand EditerCommand
        {
            get;
            set;
        }

        private void Editer(object o)
        {
            fen = new EditerView(SelectedCompositeur);
            fen.Title = "Editer";
            fen.ViewModel.Fermer += FermerFen;
            fen.ShowDialog();
            fen.ViewModel.Fermer -= FermerFen;

        }

        private bool CanEditer(object o)
        {
            return _SelectedCompositeur != null;
        }

        #endregion

        #region Supprimer

        public DelegateCommand SupprimerCommand
        {
            get;
            set;
        }

        

        private void Supprimer(object o)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous réellement supprimer : " + SelectedCompositeur, "Attention !!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {    //suppression
                dataManager.Supprimer(CompositeurFactory.ConvertBackCompositeur(SelectedCompositeur));
                NotifyPropertyChanged("ListeCompo");
            }
        }

        private bool CanSupprimer(object o)
        {
            return _SelectedCompositeur != null;
        }

        #region play
        public DelegateCommand PlayCommand
        {
            get;
            set;
        }

        private void Play(object o)
        {
            mediaPlayer.Play();
        }

        private bool CanPlay(object o)
        {
            return OeuvreSelectionne != null;
        }
        #endregion

        #region pause
        public DelegateCommand PauseCommand
        {
            get;
            set;
        }

        private void Pause(object o)
        {
            mediaPlayer.Pause();

        }

        private bool CanPause(object o)
        {
            return OeuvreSelectionne != null;
        }
        #endregion

        #region stop

        public DelegateCommand StopCommand
        {
            get;
            set;
        }

        private void Stop(object o)
        {
            mediaPlayer.Stop();

        }

        private bool CanStop(object o)
        {
            return OeuvreSelectionne != null;
        }

        #endregion

        #endregion

        #endregion

        private DataManager dataManager;

        public MainWindowViewModel()
        {
            dataManager = DataManager.Get();
            ListeCompo = CompositeurFactory.ConvertAllCompositeur(dataManager.ListeCompo);
            AjouterCommand = new DelegateCommand(Ajouter);
            EditerCommand = new DelegateCommand(Editer, CanEditer);
            SupprimerCommand = new DelegateCommand(Supprimer, CanSupprimer);
            StopCommand = new DelegateCommand(Stop, CanStop);
            PlayCommand = new DelegateCommand(Play, CanPlay);
            PauseCommand = new DelegateCommand(Pause, CanPause);
            dataManager.miseAJour += DataManager_miseAJour;
        }

        private void DataManager_miseAJour(object sender, EventArgs e)
        {
            ListeCompo = CompositeurFactory.ConvertAllCompositeur(dataManager.ListeCompo);
            NotifyPropertyChanged("ListeCompo");
           

        }
    }
}
