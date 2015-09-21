using System;
using System.Collections.Generic;

namespace Interpreter
{
    class MainApp
    {
        static void Main()
        {
            Context context = new Context();

            List<AbstractExpression> expressionList = new List<AbstractExpression>();

            expressionList.Add(new TerminalExpression());
            expressionList.Add(new NonterminalExpression());
            expressionList.Add(new TerminalExpression());
            expressionList.Add(new TerminalExpression());

            foreach (AbstractExpression exp in expressionList)
            {
                exp.Interpret(context);
            }
        }
    }
}
