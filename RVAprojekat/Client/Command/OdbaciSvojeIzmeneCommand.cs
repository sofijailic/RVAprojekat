using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command
{
    public class OdbaciSvojeIzmeneCommand : ClientCommand
    {
        public KonfliktViewModel conflictVM;
        public OdbaciSvojeIzmeneCommand(KonfliktViewModel viewModel)
        {
            conflictVM = viewModel;
        }
        public override void Execute(object parameter)
        {
            conflictVM.view.Close();
            conflictVM.modelIzmeneBeleske.proz.Close();
            //conflictVM.viewModel.homeVM.RefreshBeleske();
        }

        public override void UnExecute()
        {

        }
    }
}
