﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.View;
using Client.ViewModel;
using System.ServiceModel;
using Common;
using Common.Interfaces;
using Common.Data;
using System.Windows.Controls;

namespace Client.Command
{
    class LoginCommand : ClientCommand
    {
        private LoginViewModel viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
                return;

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 2)
                return;

            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                    return;
            }

            string username = parameters[0].ToString();
            PasswordBox passwordBox = parameters[1] as PasswordBox;
            string password = passwordBox.Password;

            User korisnik = viewModel.proxyKorisnik.UlogujKorisnika(username, password);

            if (korisnik != null)
            {
                Sesija.trenutniKorisnik = korisnik;
                PocetnaView pocetniProzor = new PocetnaView();
                MainWindow.glavni.Close();
                pocetniProzor.ShowDialog();
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
