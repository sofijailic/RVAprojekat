using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorDodajBeleskuCommand : ClientCommand
    {
        public PocetnaViewModel model;
        public otvoriProzorDodajBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;
        }
        public override void Execute(object parameter)
        {
            DodajNovuBeleskuView prozorDodajBelesku = new DodajNovuBeleskuView(model);
            prozorDodajBelesku.ShowDialog();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
