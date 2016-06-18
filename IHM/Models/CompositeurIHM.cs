using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.Models
{
    public class CompositeurIHM : NotifyPropertyChangedBase, IEquatable<CompositeurIHM>
    {
        private string _Nom;
        private string _Prenom;
        private DateTime _DateNaissance;
        private DateTime _DateDeces;
        //private string _Oeuvres;
        private string _Description;
        private string _CheminImage;
        private ObservableCollection<OeuvreIHM> _Oeuvres;

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
                NotifyPropertyChanged("Nom");
                NotifyPropertyChanged("NomPrenom");
            }
        }

        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
                NotifyPropertyChanged("Prenom");
                NotifyPropertyChanged("NomPrenom");
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return _DateNaissance;
            }

            set
            {
                _DateNaissance = value;
                NotifyPropertyChanged("DateNaissance");
            }
        }

        public DateTime DateDeces
        {
            get
            {
                return _DateDeces;
            }

            set
            {
                _DateDeces = value;
                NotifyPropertyChanged("DateDeces");
            }
        }

        public ObservableCollection<OeuvreIHM> Oeuvres
        {
            get
            {
                return _Oeuvres;
            }

            set
            {
                _Oeuvres = value;
                NotifyPropertyChanged("Oeuvres");
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string CheminImage
        {
            get
            {
                return _CheminImage;
            }

            set
            {
                _CheminImage = value;
                NotifyPropertyChanged("CheminImage");
            }
        }

        public CompositeurIHM(string nom, string prenom, DateTime ddn, DateTime ddd, ObservableCollection<OeuvreIHM> oeuvres, string description, string cheminImage)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = ddn;
            DateDeces = ddd;
            Oeuvres = oeuvres;
            Description = description;
            CheminImage = cheminImage;
        }

        public CompositeurIHM(CompositeurIHM other)
            : this(other.Nom, other.Prenom, other.DateNaissance, other.DateDeces, new ObservableCollection<OeuvreIHM>(), other.Description, other.CheminImage)
        {
            foreach (OeuvreIHM o in other.Oeuvres)
            {
                Oeuvres.Add(new OeuvreIHM(o));
            }
        }

        public CompositeurIHM()
        {
            Oeuvres = new ObservableCollection<OeuvreIHM>();
        }

        public string NomPrenom
        {
            get
            {
                return ToString();
            }
        }

         

        public override string ToString()
        {
            return string.Format("{0} {1}", Prenom, Nom);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            if (GetType() == obj.GetType())
            {
                return Equals(obj as CompositeurIHM);
            }
            return false;
        }

        public bool Equals(CompositeurIHM other)
        {
            return Nom.Equals(other.Nom) && Prenom.Equals(other.Prenom) && DateNaissance == other.DateNaissance;

        }
        public override int GetHashCode()
        {
            return Nom.GetHashCode() + 7 * Prenom.GetHashCode() + 43 * DateNaissance.GetHashCode();
        }
    }
}
