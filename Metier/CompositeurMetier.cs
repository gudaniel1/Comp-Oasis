using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Metier
{
    [DataContract]
    public class CompositeurMetier : IEquatable<CompositeurMetier>
    {
        private string _Nom;
        private string _Prenom;
        private DateTime _DateNaissance;
        private DateTime _DateDeces;
        //private string _Oeuvres;
        private string _Description;
        private string _CheminImage;
        private List<OeuvreMetier> _Oeuvres;

        [DataMember]
        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
            }
        }

        [DataMember]
        public string Prenom
        {
            get
            {
                return _Prenom;
            }

            set
            {
                _Prenom = value;
            }
        }

        [DataMember]
        public DateTime DateNaissance
        {
            get
            {
                return _DateNaissance;
            }

            set
            {
                _DateNaissance = value;
            }
        }

        [DataMember]
        public DateTime DateDeces
        {
            get
            {
                return _DateDeces;
            }

            set
            {
                _DateDeces = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public string CheminImage
        {
            get
            {
                return _CheminImage;
            }

            set
            {
                _CheminImage = value;
            }
        }

        [DataMember]
        public List<OeuvreMetier> Oeuvres
        {
            get
            {
                return _Oeuvres;
            }

            set
            {
                _Oeuvres = value;
            }
        }

        public CompositeurMetier() { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as CompositeurMetier);
        }

        public bool Equals(CompositeurMetier other)
        {
            return Nom.Equals(other.Nom) && Prenom.Equals(other.Prenom) && (DateNaissance == other.DateNaissance);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode() + 7 * Prenom.GetHashCode() + 43 * DateNaissance.GetHashCode();
        }
    }
}
