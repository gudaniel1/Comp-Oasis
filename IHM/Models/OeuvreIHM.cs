using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.Models
{
    public class OeuvreIHM : NotifyPropertyChangedBase, IEquatable<OeuvreIHM>
    {
        private string _nom;
        private string _cheminMusique;

        public string CheminMusique
        {
            get
            {
                return _cheminMusique;
            }

            set
            {
                _cheminMusique = value;
                NotifyPropertyChanged("CheminMusique");
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
                NotifyPropertyChanged("Nom");

            }
        }

        public OeuvreIHM() { }

        public OeuvreIHM(OeuvreIHM other)
        {
            Nom = other.Nom;
            CheminMusique = other.CheminMusique;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            if (GetType() == obj.GetType())
            {
                return Equals(obj as OeuvreIHM);
            }
            return false;
        }

        public bool Equals(OeuvreIHM other)
        {
            return Nom.Equals(other.Nom);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
