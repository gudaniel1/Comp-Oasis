using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    [DataContract]
    public class OeuvreMetier : IEquatable<OeuvreMetier>
    {
        private string _nom;
        private string _cheminMusique;

        [DataMember]
        public string CheminMusique
        {
            get
            {
                return _cheminMusique;
            }

            set
            {
                _cheminMusique = value;
            }
        }

        [DataMember]
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            if (GetType() == obj.GetType()) {
                return Equals(obj as OeuvreMetier);
            }
            return false;
        }

        public bool Equals(OeuvreMetier other)
        {
            return Nom.Equals(other.Nom);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
