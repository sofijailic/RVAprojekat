using Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorDodajBeleskuCommand : ClientCommand
    {
        public override void Execute(object parameter)
        {
            DodajNovuBeleskuView prozorDodajBelesku = new DodajNovuBeleskuView();
            prozorDodajBelesku.ShowDialog();
        }
    }
}
