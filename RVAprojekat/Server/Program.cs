using Common.Data;
using Common.Interfaces;
using Server.Access;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static ServiceHost serviceHost;
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            Console.WriteLine(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            //UserDB.Instance.DodajKorisnika(new User()
            //{
            //    Username = "admin",
            //    Password = "admin",
            //    Ime = "Admin",
            //    Prezime = "Admin",
            //    Admin = true,
            //    Grupe = ""
            //});


            serviceHost = new ServiceHost(typeof(UserDB));
            var binding1 = new NetTcpBinding();
            binding1.TransactionFlow = true;
            serviceHost.AddServiceEndpoint(typeof(IUserDB), binding1, new Uri("net.tcp://localhost:50000/UserConnection"));
            serviceHost.Open();

            Console.ReadKey();
        }
    }
}
