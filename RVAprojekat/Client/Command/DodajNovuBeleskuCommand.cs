using Client.View;
using Client.ViewModel;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    class DodajNovuBeleskuCommand : ClientCommand
    {
        private DodajNovuBeleskuViewModel prozorModel;
        public PocetnaViewModel pocetniModel;
        // private Beleska beleskaZaDodavanjeDodatno;

        private Beleska beleskaZaDodavanje;

        public DodajNovuBeleskuCommand(DodajNovuBeleskuViewModel proz ) {
            this.prozorModel = proz;
        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            //if (parameters == null || parameters.Length != 5)
            //{
            //    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
            //    return;
            //}


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                    return;
                }
            }

            if ((bool)parameters[2] == false && (bool)parameters[3] == false && (bool)parameters[4] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            // izvuci parametre
            string naslov = parameters[0].ToString();
            string sadrzaj = parameters[1].ToString();
            string grupe = "";
            if ((bool)parameters[2] == true)
            {
                grupe += ";Politika";
            }
            if ((bool)parameters[3] == true)
            {
                grupe += ";Zabava";
            }
            if ((bool)parameters[4] == true)
            {
                grupe += ";Sport";
            }

            beleskaZaDodavanje = new Beleska()
            {
                Naslov = naslov,
                Sadrzaj = sadrzaj,
                Grupe = grupe
            };

            Beleska uspesnoDodato = prozorModel.proxyBeleska.dodavanjeBeleske(beleskaZaDodavanje); 

            prozorModel.model.UndoHistory.Add(this);
            Sesija.listaBeleskiUndo.Add(uspesnoDodato);

            if (uspesnoDodato != null)
            {
                MessageBox.Show("Uspesno dodato!", "Uspeh");
                
                prozorModel.model.OsveziPocetnu();
                prozorModel.prozor.Close();
            }
            else MessageBox.Show("Neuspesno dodato!", "Neuspeh");
        }

        public override void UnExecute()
        {
            prozorModel.model.proxyBeleska.obrisiBelesku(Sesija.listaBeleskiUndo[Sesija.listaBeleskiUndo.Count-1].Id); 
            //prozorModel.model.RefreshBeleske();
            prozorModel.model.RedoHistory.Add(this);
            Sesija.listaBeleskiRedo.Add(beleskaZaDodavanje);
        }
    }
}
