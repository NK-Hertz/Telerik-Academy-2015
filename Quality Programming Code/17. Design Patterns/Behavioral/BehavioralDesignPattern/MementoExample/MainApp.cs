using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class MainApp
    {
        static void Main()
        {
            Originator originator = new Originator();
            originator.State = "On";

            // Store internal state
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();

            originator.State = "Off";

            originator.SetMemento(caretaker.Memento);
        }
    }
}
