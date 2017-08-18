﻿using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class PretragaCommand : ClientCommand
    {
        private PocetnaViewModel model;
        public PretragaCommand(PocetnaViewModel model)
        {
            this.model = model;
        }
        public override void Execute(object parameter)
        {

            Object[] parameters = parameter as Object[];

            if ((parameters[0] == null || parameters[0] == "") && (bool)parameters[1] == false && (bool)parameters[2] == false && (bool)parameters[3] == false)
            {
                MessageBox.Show("Popunite parametre za pretragu", "Popunite paramtere");
                return;
            }

            List<Beleska> listaSvih = model.proxyBeleska.uzmiSveBeleske();
            List<Beleska> listaFiltriranih = new List<Beleska>();
            if ((bool)parameters[1] == false && (bool)parameters[2] == false && (bool)parameters[3] == false)
            {
                // samo filtriraj po nazivu
                listaFiltriranih = listaSvih.Where(x => x.Naslov.Contains(parameters[0].ToString())).ToList();
            }
            else if ((parameters[0] == null || parameters[0] == ""))
            {
                if ((bool)parameters[1])
                {
                    listaFiltriranih = listaSvih.Where(x => x.Grupe.Contains("Politika")).ToList();
                }
                if ((bool)parameters[2])
                {
                    listaFiltriranih.AddRange(listaSvih.Where(x => x.Grupe.Contains("Zabava")).ToList());
                }
                if ((bool)parameters[3])
                {
                    listaFiltriranih.AddRange(listaSvih.Where(x => x.Grupe.Contains("Sport")).ToList());
                }
            }
            else
            {
                if ((bool)parameters[1])
                {
                    listaFiltriranih.AddRange(listaSvih.Where(x => x.Grupe.Contains("Politika")).ToList());
                }
                if ((bool)parameters[2])
                {
                    listaFiltriranih.AddRange(listaSvih.Where(x => x.Grupe.Contains("Zabava")).ToList());
                }
                if ((bool)parameters[3])
                {
                    listaFiltriranih.AddRange(listaSvih.Where(x => x.Grupe.Contains("Sport")).ToList());
                }
                listaFiltriranih = listaFiltriranih.Where(x => x.Naslov.Contains(parameters[0].ToString())).ToList();
            }
            List<Beleska> distinctList = listaFiltriranih.Distinct().ToList();
            List<string> listaZaIspis = new List<string>();
            foreach (Beleska beleska in distinctList)
            {
                listaZaIspis.Add(beleska.Id + "-" + beleska.Naslov + " (" + beleska.Grupe.Substring(1) + ") ");
            }
            model.listaBeleskiPrikaz= listaZaIspis;
            model.OnPropertyChanged(new PropertyChangedEventArgs("listaBeleskiPrikaz"));
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
