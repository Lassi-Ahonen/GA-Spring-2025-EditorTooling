using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Lasriel.Editor {

    /// <summary>
    /// Custom property drawer for drawing <see cref="FloatRange"/> in the inspector.
    /// </summary>
    [CanEditMultipleObjects] // Makes multi object editing possible in the inspector
    [CustomPropertyDrawer(typeof(FloatRange))] // Define this property drawer to be for the FloatRange type
    public class FloatRangeEditor : PropertyDrawer {

        // File path for the uxml file in the resources, since it's in the root we can just use the file name
        private const string k_UxmlPath = "FloatRangeStructure";

        private VisualTreeAsset m_InspectorStructure;

        // Override the default propert GUI functionality with the uxml strcuture
        // Field values are bound from the UI Toolkit editor so we don't need to do it here
        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
            // Load uxml from resources and initialize it
            m_InspectorStructure = Resources.Load<VisualTreeAsset>(k_UxmlPath);
            VisualElement root = m_InspectorStructure.Instantiate();

            // Find our field name element and give it the serialized field's name and tooltip
            Label fieldLabel = (Label)root.Q(name: "FieldName");
            fieldLabel.text = property.displayName;
            fieldLabel.tooltip = property.tooltip;

            // We return the element we want to be drawn in the inspector
            return root;
        }

    }
}
