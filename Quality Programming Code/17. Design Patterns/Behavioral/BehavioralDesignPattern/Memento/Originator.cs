using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memento
{
    class Originator
    {
        private string state;

        public string State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                Console.WriteLine("State = " + this.state);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(this.state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            this.State = memento.State;
        }
    }
}
