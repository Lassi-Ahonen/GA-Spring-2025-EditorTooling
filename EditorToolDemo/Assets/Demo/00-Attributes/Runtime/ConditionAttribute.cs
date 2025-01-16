using System;
using UnityEngine;

namespace Lasriel {

    // Creates a new property attribute that can be used on serializable fields
    // Usage: [Condition("ConditionVariableName")] or [Condition("ConditionVariableName", true)]
    // AttributeUsage prevents use on targets that are not specified
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
    public class ConditionAttribute : PropertyAttribute {

        // These variables can be accessed from the editor code side to modify GUI functionality
        public readonly string ConditionBoolean = "";
        public readonly bool HideInInspector = false;

        // Constructor
        // Takes in condition boolean name as string
        // Defaults field hiding to false
        public ConditionAttribute(string conditionBoolean) {
            ConditionBoolean = conditionBoolean;
            HideInInspector = false;
        }

        // Constructor overload
        // Takes in condition boolean name as string and boolean wether field should be hidden when condition is false
        public ConditionAttribute(string conditionBoolean, bool hideInInspector) {
            ConditionBoolean = conditionBoolean;
            HideInInspector = hideInInspector;
        }

    }

}
