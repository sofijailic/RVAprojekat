using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public class OsveziBeleskuCommand : ClientCommand
    {
        private PocetnaViewModel model;
        public OsveziBeleskuCommand(PocetnaViewModel model) {
            this.model = model;
        }

        public override void Execute(object parameter)
        {
            model.OsveziPocetnu();
        }
    }
}
