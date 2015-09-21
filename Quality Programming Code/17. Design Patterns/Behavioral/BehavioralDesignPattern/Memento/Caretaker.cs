using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memento
{
    class Caretaker
    {
        private Memento memento;

        public Memento Memento
        {
            get { return this.memento; }
            set { this.memento = value; }
        }
    }
}
