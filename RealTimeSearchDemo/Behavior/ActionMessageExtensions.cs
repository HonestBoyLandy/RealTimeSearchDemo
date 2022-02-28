using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeSearchDemo.Behaviors
{
    static class ActionMessageExtensions
    {
        internal static bool TryExtract<T>(this ActionMessage message, ActionKind action, out T data)
        {
            data = default(T);

            if (message.Action == action)
            {
                if (message.Data is T typedData)
                {
                    data = typedData;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
