using Client.Command;
using Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class KonfliktViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PregaziTudjeIzmeneCommand pregaziIzmeneCommand { get; set; }
        public OdbaciSvojeIzmeneCommand odbaciSvojeCommand { get; set; }
        public IzmeniBeleskuViewModel modelIzmeneBeleske;
        public KonfliktView view;

        public KonfliktViewModel(IzmeniBeleskuViewModel vm, KonfliktView view)
        {
            modelIzmeneBeleske = vm;
            this.view = view;
            this.pregaziIzmeneCommand = new PregaziTudjeIzmeneCommand(this);
            this.odbaciSvojeCommand = new OdbaciSvojeIzmeneCommand(this);
        }
    }
}
