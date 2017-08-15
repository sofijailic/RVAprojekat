using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public class ObrisiBeleskuCommand : ClientCommand
    {
        private PocetnaViewModel model;
        public ObrisiBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;
        }

        public override void Execute(object parameter)
        {
            int id = Int32.Parse(model.selektovanaBeleska.Split('-')[0]);
            model.proxyBeleska.obrisiBelesku(id);
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
