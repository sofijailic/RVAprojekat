using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class PregaziTudjeIzmeneCommand : ClientCommand
    {
        private KonfliktViewModel modelKonfliktni;
        public PregaziTudjeIzmeneCommand(KonfliktViewModel vm)
        {
            modelKonfliktni = vm;
        }
        public override void Execute(object parameter)
        {
            bool uspesno;
            uspesno = modelKonfliktni.modelIzmeneBeleske.model.proxyBeleska.izmeniBelesku(new Beleska()
            {
                Id = modelKonfliktni.modelIzmeneBeleske.mojaIzmenjenaBeleska.Id,
                Naslov = modelKonfliktni.modelIzmeneBeleske.mojaIzmenjenaBeleska.Naslov,
                Sadrzaj = modelKonfliktni.modelIzmeneBeleske.mojaIzmenjenaBeleska.Sadrzaj
            });
            if (uspesno)
            {
                MessageBox.Show("Uspesno pregazene izmene", "Uspeh");
                modelKonfliktni.view.Close();
                modelKonfliktni.modelIzmeneBeleske.proz.Close();
                modelKonfliktni.modelIzmeneBeleske.model.OsveziPocetnu();
                
            }
            else
            {
                MessageBox.Show("Neuspesno pregazene izmene", "Neuspeh");
                modelKonfliktni.view.Close();
                modelKonfliktni.modelIzmeneBeleske.proz.Close();
                modelKonfliktni.modelIzmeneBeleske.model.OsveziPocetnu();
            }
        }

        public override void UnExecute()
        {

        }
    }
}
