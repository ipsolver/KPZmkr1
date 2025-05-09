using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _target;
        private readonly string _className;

        public AddClassCommand(LightElementNode target, string className)
        {
            _target = target;
            _className = className;
        }

        public void Execute()
        {
            _target.AddClass(_className);
        }
    }
}
