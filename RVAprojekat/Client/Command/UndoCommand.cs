using Client.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class UndoCommand : ClientCommand
    {

        private PocetnaViewModel model;
        public UndoCommand(PocetnaViewModel mod)
        {
            this.model = mod;
        }

        public override void Execute(object parameter)
        {
            if (model.UndoHistory.Count == 0)
            {
                MessageBox.Show("Ne postoji komanda za undo", "Ne postoji");
            }
            else
            {
                ClientCommand beleskaCommand = model.UndoHistory[model.UndoHistory.Count - 1];
                beleskaCommand.UnExecute();
                model.UndoHistory.Remove(beleskaCommand);
                Sesija.listaBeleskiUndo.RemoveAt(Sesija.listaBeleskiUndo.Count - 1);
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
