using IHM.Models;
using Metier;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM.Factory
{
    public static class OeuvreFactory
    {
        public static OeuvreIHM ConvertOeuvre(OeuvreMetier o)
        {
            return new OeuvreIHM()
            {
                Nom = o.Nom,
                CheminMusique = o.CheminMusique

            };
        }

        public static ObservableCollection<OeuvreIHM> ConvertAllOeuvre(IEnumerable<OeuvreMetier> l)
        {
            ObservableCollection<OeuvreIHM> retour = new ObservableCollection<OeuvreIHM>();
            if (l != null)
            {
                foreach (OeuvreMetier oeuvre in l)
                {
                    retour.Add(ConvertOeuvre(oeuvre));
                }
            }
            return retour;
        }

        public static OeuvreMetier ConvertBackOeuvre(OeuvreIHM o)
        {
            return new OeuvreMetier()
            {
                Nom = o.Nom,
                CheminMusique = o.CheminMusique

            };
        }
    }
}
