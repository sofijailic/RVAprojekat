using Klijent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Komande.BeleskaKomande
{
    public class ObrisiBeleskuKomanda : KlijentKomanda
    {
        private PocetnaViewModel model;
        public ObrisiBeleskuKomanda(PocetnaViewModel model)
        {
            this.model = model;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
