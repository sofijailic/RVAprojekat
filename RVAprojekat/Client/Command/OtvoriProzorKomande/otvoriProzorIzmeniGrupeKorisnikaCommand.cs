using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorIzmeniGrupeKorisnikaCommand : ClientCommand
    {
        private  PocetnaViewModel model;

        public otvoriProzorIzmeniGrupeKorisnikaCommand(PocetnaViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            IzmeniGrupeKorisnikaView prozor = new IzmeniGrupeKorisnikaView();
            prozor.ShowDialog();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
