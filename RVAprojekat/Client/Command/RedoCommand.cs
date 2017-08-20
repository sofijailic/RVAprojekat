using Client.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class RedoCommand : ClientCommand
    {
        private PocetnaViewModel model;
        public RedoCommand(PocetnaViewModel mod)
        {
            this.model = mod;
        }

        public override void Execute(object parameter)
        {
            if (model.RedoHistory.Count == 0)
            {
                MessageBox.Show("Nema komandi za redo", "Nema komandi");
            }
            else
            {
                ClientCommand beleskaCommand = model.RedoHistory[model.RedoHistory.Count - 1];
                Object[] parametri = new Object[6];
                parametri[0] = Sesija.listaBeleskiRedo[Sesija.listaBeleskiRedo.Count - 1].Naslov;
                parametri[1] = Sesija.listaBeleskiRedo[Sesija.listaBeleskiRedo.Count - 1].Sadrzaj;
                // provera za grupe
                parametri[2] = true;
                parametri[3] = false;
                parametri[4] = true;
                parametri[5] = Sesija.listaBeleskiRedo[Sesija.listaBeleskiRedo.Count - 1].Id;
                beleskaCommand.Execute(parametri);
                model.RedoHistory.Remove(beleskaCommand);
                Sesija.listaBeleskiRedo.RemoveAt(Sesija.listaBeleskiRedo.Count - 1);
                model.OsveziPocetnu();
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
