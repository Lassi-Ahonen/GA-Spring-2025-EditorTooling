using UnityEngine;
using UnityEditor;

// It's good practise to have editor code in it's own namespace
namespace Lasriel.Editor {

    // This class uses IMGUI
    // Defines GUI funtionality for the attribute type ConditionAttribute
    [CustomPropertyDrawer(typeof(ConditionAttribute))]
    public class ConditionAttributeDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Get the attribute reference and check the condition boolean value
            ConditionAttribute conditionAttribute = (ConditionAttribute)attribute;
            bool conditionEnabled = GetConditionAttributeResult(conditionAttribute, property);

            // If condition boolean is false we want to gray out the property, otherwise it's drawn normally
            using (new EditorGUI.DisabledScope(disabled: !conditionEnabled)) {
                // Draw the property field only if it is marked not to be hidden or condition is true
                if (!conditionAttribute.HideInInspector || conditionEnabled) {
                    EditorGUI.PropertyField(position, property, label, includeChildren: true);
                }
            }
        }

        // PropertyDrawer has hardcoded height set so we need to override it so everything draws properly
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // Get the attribute reference and check the condition boolean value
            ConditionAttribute conditionAttribute = (ConditionAttribute)attribute;
            bool enabled = GetConditionAttributeResult(conditionAttribute, property);

            if (!conditionAttribute.HideInInspector || enabled) {
                // Get the height of the serialized property
                return EditorGUI.GetPropertyHeight(property, label);
            } else {
                // If serialized property is hidden, we need to negate the property height
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }

        // Tries to find condition boolean by name and returns it's value, defaults to true
        private bool GetConditionAttributeResult(ConditionAttribute conditionAttribute, SerializedProperty property) {
            bool enabled = true; // By default we want to draw the property
            string propertyPath = property.propertyPath; // Gets path to the property field

            // Try find condition boolean from the same path where the attribute is located at
            string conditionPath = propertyPath.Replace(property.name, conditionAttribute.ConditionBoolean);
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

            if (sourcePropertyValue != null) {
                // Get condition boolean value
                enabled = sourcePropertyValue.boolValue;
            } else {
                // If condition name string is invalid we want to log it
                Debug.LogWarning($"[ConditionAttributeDrawer]: No matching boolean found for ConditionAttribute in: {conditionAttribute.ConditionBoolean}");
            }

            return enabled;
        }

    }

}
