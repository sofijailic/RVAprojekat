﻿using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IBeleskaDB
    {
        [OperationContract]
        Beleska dodavanjeBeleske( Beleska beleska);

        [OperationContract]
        List<Beleska> uzmiBeleskeOdKorisnika(User u);

        [OperationContract]
        Beleska uzmiBeleksuPoId(int id);

        [OperationContract]
        bool izmeniBelesku(Beleska beleska);

        [OperationContract]
        bool obrisiBelesku(int Id);

        [OperationContract]
        List<Beleska> uzmiSveBeleske();
    }
}
