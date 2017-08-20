using Client.Command;
using Client.View;
using Common;
using Common.Data;
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
    public class IzmeniBeleskuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IzmeniBeleskuView proz { get; set; }
        public IzmeniBeleskuCommand izmena { get; set; }
        public Beleska originalBeleska { get; set; }

        private int Id;
        public Beleska mojaIzmenjenaBeleska { get; set; }
        public PocetnaViewModel model { get; set; }


        public string politikaDostupna { get; set; }
        public string zabavaDostupna { get; set; }
        public string sportDostupan { get; set; }

        public string politikaOtkacena { get; set; }
        public string zabavaOtkacena { get; set; }
        public string sportOtkacen { get; set; }

      

        public IBeleskaDB proxyBeleska;


        public IzmeniBeleskuViewModel(IzmeniBeleskuView prozor,PocetnaViewModel model) {

            this.proz = prozor;
            this.izmena = new IzmeniBeleskuCommand(this);
            this.model = model;
            Id = Int32.Parse(model.selektovanaBeleska.Split('-')[0]);


            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskaDB> factory = new ChannelFactory<IBeleskaDB>(binding, new EndpointAddress("net.tcp://localhost:51000/BeleskaConnection"));
            proxyBeleska = factory.CreateChannel();

            mojaIzmenjenaBeleska = proxyBeleska.uzmiBeleksuPoId(Id);

            originalBeleska = new Beleska();
            originalBeleska.Id = mojaIzmenjenaBeleska.Id;
            originalBeleska.Naslov = mojaIzmenjenaBeleska.Naslov;
            originalBeleska.Sadrzaj = mojaIzmenjenaBeleska.Sadrzaj;

            /*
            if (mojaIzmenjenaBeleska.Grupe.Contains("Politika"))
            {
                politikaOtkacena = "True";
            }
            else politikaOtkacena = "False";

            if (mojaIzmenjenaBeleska.Grupe.Contains("Zabava"))
            {
                zabavaOtkacena = "True";
            }
            else zabavaOtkacena = "False";

            if (mojaIzmenjenaBeleska.Grupe.Contains("Sport"))
            {
                sportOtkacen = "True";
            }
            else sportOtkacen = "False";


    
            if (Sesija.trenutniKorisnik.Grupe.Contains("Politika"))
            {
                politikaDostupna = "True";
            }
            else politikaDostupna = "False";

            if (Sesija.trenutniKorisnik.Grupe.Contains("Zabava"))
            {
                zabavaDostupna = "True";
            }
            else zabavaDostupna = "False";

            if (Sesija.trenutniKorisnik.Grupe.Contains("Sport"))
            {
                sportDostupan = "True";
            }
            else sportDostupan = "False";
            */
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
