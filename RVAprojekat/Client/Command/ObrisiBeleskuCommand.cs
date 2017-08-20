using Client.ViewModel;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class ObrisiBeleskuCommand : ClientCommand
    {
        private PocetnaViewModel model;

        private Beleska beleskaZaBrisanje;

        public ObrisiBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;
        }
        public ObrisiBeleskuCommand()
        {
        }

        public override void Execute(object parameter)
        {

            int id = 0;
            // provera dalje za parameters[5]
            if (parameter == null)
            {
                if (model.selektovanaBeleska == null || model.selektovanaBeleska == "")
                {
                    MessageBox.Show("Selektujte belesku za brisanje");
                    return;
                }
                id = Int32.Parse(model.selektovanaBeleska.Split('-')[0]);
            }
            else
            {
                Object[] parameters = parameter as Object[];
                id = Int32.Parse(parameters[5].ToString());
            }
            beleskaZaBrisanje = model.proxyBeleska.uzmiBeleksuPoId(id);
            //Globals.listaObrisanih.Add(beleskaZaBrisanje);
            model.proxyBeleska.obrisiBelesku(id);
            model.OsveziPocetnu();
            model.UndoHistory.Add(this);
            Sesija.listaBeleskiUndo.Add(beleskaZaBrisanje);
        }

        public override void UnExecute()
        {
            Beleska dodataBeleska = model.proxyBeleska.dodavanjeBeleske(Sesija.listaBeleskiUndo[Sesija.listaBeleskiUndo.Count - 1]);
            //model.OsveziPocetnu(); 
            model.RedoHistory.Add(this);
            Sesija.listaBeleskiRedo.Add(dodataBeleska);
        }
    }
}
