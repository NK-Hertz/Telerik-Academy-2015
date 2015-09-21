using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter
{
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
}
