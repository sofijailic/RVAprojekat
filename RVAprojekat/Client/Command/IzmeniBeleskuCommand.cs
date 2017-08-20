using Client.View;
using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class IzmeniBeleskuCommand : ClientCommand
    {
        public IzmeniBeleskuViewModel model;
        public IzmeniBeleskuCommand(IzmeniBeleskuViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 3)
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                    return;
                }
            }

          
            try
            {
                Beleska beleskaZaProveru = model.proxyBeleska.uzmiBeleksuPoId(model.originalBeleska.Id);
                if (beleskaZaProveru.Naslov != model.originalBeleska.Naslov || beleskaZaProveru.Sadrzaj != model.originalBeleska.Sadrzaj)
                {
                    KonfliktView conflictV = new KonfliktView(model);
                    conflictV.ShowDialog();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Beleska je u medjuvremenu obrisana");
                model.proz.Close();
               
                return;
            }


            bool uspesno = model.proxyBeleska.izmeniBelesku(new Beleska()
            {
                Id = Int32.Parse(parameters[2].ToString()),
                Naslov = parameters[0].ToString(),
                Sadrzaj = parameters[1].ToString()
            });

            if (uspesno)
            {
                MessageBox.Show("Beleska uspesno izmenjena", "Uspeh");
                model.proz.Close();
                model.model.OsveziPocetnu();

            }
            else {
                MessageBox.Show("Niste izmenili belesku", "Neuspeh");
                model.proz.Close();
                model.model.OsveziPocetnu();
            } 
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
