using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateExample
{
    class Context
    {
        private State state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                //Console.WriteLine("State: " + this.state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
