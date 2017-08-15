using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorIzmeniBeleskuCommand : ClientCommand
    {

        private PocetnaViewModel model;
        public otvoriProzorIzmeniBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            IzmeniBeleskuView view = new IzmeniBeleskuView(model);
            view.ShowDialog();
        }
    }
}
