using System;
using UnityEngine;

namespace Lasriel {

    // Creates a new property attribute that can be used on serializable fields
    // Usage: [InspectorReadOnly]
    // AttributeUsage prevents use on targets that are not specified
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
    public class InspectorReadOnlyAttribute : PropertyAttribute { }

}
