using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Metier
{
    public class DataManager
    {
        private static DataManager singleton;

        public static DataManager Get()
        {
            if (singleton == null)
            {
                singleton = new DataManager();
            }

            return singleton;
        }

        private DataManager()
        {
            Charger();
        }

        public event EventHandler miseAJour;

        private List<CompositeurMetier> listeCompo;

        public List<CompositeurMetier> ListeCompo
        {
            get
            {
                return listeCompo;
            }

            set
            {
                listeCompo = value;
                if (miseAJour != null)
                {
                    miseAJour(this, EventArgs.Empty);
                }
            }
        }

        public void Ajouter(CompositeurMetier c)
        {
            listeCompo.Add(c);
            Enregister();
            if (miseAJour != null)
            {
                miseAJour(this, EventArgs.Empty);
            }
        }

        public void Supprimer(CompositeurMetier c)
        {
            listeCompo.Remove(c);
            Enregister();
            if (miseAJour != null)
            {
                miseAJour(this, EventArgs.Empty);
            }
        }

        public void Modifier(CompositeurMetier avant, CompositeurMetier apres)
        {
            listeCompo.Remove(avant);
            listeCompo.Add(apres);
            Enregister();
            if (miseAJour != null)
            {
                miseAJour(this, EventArgs.Empty);
            }
        }

        public void Enregister()
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            var serialiser = new DataContractSerializer(typeof(List<CompositeurMetier>));
            using (XmlWriter writer = XmlWriter.Create("sauvegarde\\fichier.xml", settings))
            {
                serialiser.WriteObject(writer, ListeCompo);
            }
        }

        public void Charger()
        {
            var serialiser = new DataContractSerializer(typeof(List<CompositeurMetier>));
            using (Stream s = File.OpenRead("sauvegarde\\fichier.xml"))
            {
                try
                {
                    ListeCompo = serialiser.ReadObject(s) as List<CompositeurMetier>;
                }
                catch
                {

                }
                if (ListeCompo == null)
                {
                    ListeCompo = new List<CompositeurMetier>();
                }
            }
        }
    }
}
