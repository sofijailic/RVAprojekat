﻿using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class KlonirajBeleskuCommand : ClientCommand
    {
        public PocetnaViewModel model;
        public KlonirajBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;

        }

        public override void Execute(object parameter)
        {
            int id = Int32.Parse(model.selektovanaBeleska.Split('-')[0]);
            Beleska beleska = model.proxyBeleska.uzmiBeleksuPoId(id);
            Beleska klonirana = beleska.Kloniraj();
            bool uspesno = model.proxyBeleska.dodavanjeBeleske(klonirana);


            if (uspesno)
            {

                MessageBox.Show("Uspesno klonirana  beleska", "Uspeh");
            }
            else
            {
                MessageBox.Show("Neuspesno klonirana  beleska", "Neuspeh");
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}