using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorIzmeniPodatkeCommand : ClientCommand
    {

        public IzmeniPodatkeViewModel model;

        public otvoriProzorIzmeniPodatkeCommand( ) {
            
        }

        public override void Execute(object parameter)
        {
            IzmeniPodatkeView view = new IzmeniPodatkeView();
            view.ShowDialog();
        }
    }
}
