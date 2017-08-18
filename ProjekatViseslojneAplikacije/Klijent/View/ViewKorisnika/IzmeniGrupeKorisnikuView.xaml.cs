using Klijent.ViewModel.ViewmModelKorisnika;
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

namespace Klijent.View.ViewKorisnika
{
    /// <summary>
    /// Interaction logic for IzmeniGrupeKorisnikuView.xaml
    /// </summary>
    public partial class IzmeniGrupeKorisnikuView : Window
    {
        public IzmeniGrupeKorisnikuView()
        {
            InitializeComponent();
            DataContext = new IzmeniGrupeKorisnikaViewModel(this);
        }
    }
}
