using IHM.Models;
using IHM.ViewModels;
using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IHM.Views
{
    /// <summary>
    /// Logique d'interaction pour Editerview.xaml
    /// </summary>
    public partial class EditerView : Window
    {
        public EditerViewModel ViewModel
        {
            get;
            set;
        }

        public EditerView(CompositeurIHM c)
        {

            ViewModel = new EditerViewModel(c);
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
