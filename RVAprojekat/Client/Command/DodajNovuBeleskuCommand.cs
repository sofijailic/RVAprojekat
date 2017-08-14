using Client.View;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    class DodajNovuBeleskuCommand : ClientCommand
    {
        private DodajNovuBeleskuViewModel prozorModel;

        public DodajNovuBeleskuCommand(DodajNovuBeleskuViewModel proz ) {
            this.prozorModel = proz;
        }
        public override void Execute(object parameter)
        {
        }
    }
}
