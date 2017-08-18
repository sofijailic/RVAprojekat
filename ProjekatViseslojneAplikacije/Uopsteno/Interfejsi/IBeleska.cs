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
    public interface IBeleska
    {
        [OperationContract]
        bool dodajBelesku(Beleska beleska);

        [OperationContract]
        bool obrisiBelesku(int id);

        [OperationContract]
        bool izmeniBelesku(Beleska beleska);

        [OperationContract]
        List<Beleska> uzmiBeleskeOdKorisnika(Korisnik k);

        [OperationContract]
        Beleska uzmiBeleskuPoId(int id);

    }
}
