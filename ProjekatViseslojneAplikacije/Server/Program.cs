using Server.PristupBazi.ImplementacijeInterfejsa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Interfejsi;
using Uopsteno.Klase;

namespace Server
{
    class Program
    {
       
        private static ServiceHost serviceHost;
        private static ServiceHost serviceHostBeleska;
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "Database";
            Console.WriteLine(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

              KorisnikBP.Instance.dodajKorisnika(new Korisnik()
               {
                    Username = "admin",
                    Password = "admin",
                    Ime = "Admin",
                    Prezime = "Admin",
                    Admin = true,
                    Grupe = ""
                });


            serviceHost = new ServiceHost(typeof(KorisnikBP));
            var binding1 = new NetTcpBinding();
            binding1.TransactionFlow = true;
            serviceHost.AddServiceEndpoint(typeof(IKorisnik), binding1, new Uri("net.tcp://localhost:50000/UserConnection"));
            serviceHost.Open();

            serviceHostBeleska = new ServiceHost(typeof(BeleskaBP));
            var binding2 = new NetTcpBinding();
            binding2.TransactionFlow = true;
            serviceHostBeleska.AddServiceEndpoint(typeof(IBeleska), binding2, new Uri("net.tcp://localhost:51000/BeleskaConnection"));
            serviceHostBeleska.Open();

            Console.ReadKey();
        }
    }
}
