using Client.Command;
using Client.View;
using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class DodajNovuBeleskuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DodajNovuBeleskuCommand dodajBeleskuKomanda { get; set; }
        public DodajNovuBeleskuView prozor { get; set; }

        public string politikaDostupan { get; set; }
        public string zabavaDostupan { get; set; }
        public string sportDostupan { get; set; }

        public IBeleskaDB proxyBeleska;
        public DodajNovuBeleskuViewModel(DodajNovuBeleskuView proz) {


            this.dodajBeleskuKomanda = new DodajNovuBeleskuCommand(this);
            this.prozor = proz;


            if (Sesija.trenutniKorisnik.Grupe.Contains("Politika"))
            {
                politikaDostupan = "True";
            }
            else politikaDostupan = "False";

            if (Sesija.trenutniKorisnik.Grupe.Contains("Zabava"))
            {
                zabavaDostupan = "True";
            }
            else zabavaDostupan = "False";

            if (Sesija.trenutniKorisnik.Grupe.Contains("Sport"))
            {
                sportDostupan = "True";
            }
            else sportDostupan = "False";

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskaDB> factory = new ChannelFactory<IBeleskaDB>(binding, new EndpointAddress("net.tcp://localhost:51000/BeleskaConnection"));
            proxyBeleska = factory.CreateChannel();
        }


        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
