using IHM.Models;
using IHM.ViewModels;
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
    /// Logique d'interaction pour EditerOeuvre.xaml
    /// </summary>
    public partial class EditerOeuvre : Window
    {
        public EditerOeuvre(CompositeurIHM c)
        {
            ViewModel = new EditerOeuvreViewModel(c);
            DataContext = ViewModel;
            InitializeComponent();

        }

        public EditerOeuvreViewModel ViewModel
        {
            get;
            set;
        }
    }
}
