using UnityEngine;

namespace Lasriel {

    // Demonstrates the usage of custom attributes
    public class AttributeDemo : MonoBehaviour {

        [Header("ReadOnly Attribute")]

        // These fields are disabled in the inspector but you can see their values
        [InspectorReadOnly]
        public int Health = 10;

        [InspectorReadOnly]
        public Rigidbody RigidbodyComponent = null;


        [Header("Condition Attribute")]

        public bool UsePosition = true;

        // This field gets disabled when UsePosition is false
        [Condition("UsePosition")]
        public Vector3 Position = Vector3.zero;

        [Space(8)]

        public bool UseRotation = true;

        // This field gets hidden when UseRotation is false
        [Condition("UseRotation", hideInInspector: true)]
        public Vector3 Rotation = Vector3.zero;


    }

}
