using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class Invoker
    {
        public readonly List<ICommand> _history = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Add(command);
        }
    }
}
