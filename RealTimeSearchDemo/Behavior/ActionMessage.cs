using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeSearchDemo.Behaviors
{
    class ActionMessage
    {
        public ActionMessage(ActionKind action)
            : this(action, null)
        {

        }

        public ActionMessage(ActionKind action, object data)
        {
            Action = action;
            Data = data;
        }

        public ActionKind Action { get; private set; }
        public object Data { get; private set; }
    }
}
