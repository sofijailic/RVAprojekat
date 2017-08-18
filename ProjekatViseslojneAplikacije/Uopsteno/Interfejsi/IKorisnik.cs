using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Klase;

namespace Uopsteno.Interfejsi
{
    [ServiceContract]
    public interface IKorisnik
    {
        [OperationContract]
        Korisnik ulogujKorisnika(string korisnickoIme, string lozinka);

        [OperationContract]
        bool dodajKorisnika(Korisnik noviKorisnik);

        [OperationContract]
        List<Korisnik> uzmiSveKorisnike();

        [OperationContract]
        bool izmeniPodatke(Korisnik k);

        [OperationContract]
        bool promeniGrupe(Korisnik k);
    }
}
