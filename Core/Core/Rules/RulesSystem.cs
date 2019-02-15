using System;
using System.Collections.Generic;
using System.Text;
using Core.Data;
using Core.Debug;

namespace Core.Rules
{
    public interface IRulesSystem
    {
        void Run(RulesDefinition rule);
    }

    public class RulesSystem : IRulesSystem
    {
        private Dictionary<string, RulesAction> actionLibrary = new Dictionary<string, RulesAction>();

        public delegate void RulesAction(string value);

        public RulesSystem()
        {
            actionLibrary["Debug"] = Debug;
        }

        public void Run (RulesDefinition rule)
        {
            string functionName = rule.function;
            string value = rule.value;

            RulesAction function;
            if(actionLibrary.TryGetValue(functionName, out function))
            {
                function(value);
            }
            else
            {
                Core.Debug.Debug.Error(string.Format("Could not find a registered function"));
            }
        }

        public void Debug(string text)
        {
            Console.WriteLine("Hello World");
        }
    }
}