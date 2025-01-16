using UnityEngine;
using UnityEditor;

// It's good practise to have editor code in it's own namespace
namespace Lasriel.Editor {

    // This class uses IMGUI
    // Defines GUI funtionality for the attribute type InspectorReadOnlyAttribute
    [CustomPropertyDrawer(typeof(InspectorReadOnlyAttribute))]
    public class InspectorReadOnlyPropertyDrawer : PropertyDrawer {

        // Draw a disabled property field
        // OnGUI gets called every frame GUI is updated
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

            // DisabledScope uses IDisposable pattern so we can use "using" statement
            // to automatically release it from memory when exiting the scope.
            // Not releasing it might cause memory leaks
            using (new EditorGUI.DisabledScope(disabled: true)) {
                // Everything inside disabled scope will appear grayed out in the editor

                // Draws the default property field of whatever serialized property the attribute is attached to
                EditorGUI.PropertyField(position, property, label, includeChildren: true);
            }

        }

        // PropertyDrawer has hardcoded height set so we need to override it so everything draws properly
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // Get the height of the serialized property
            return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
        }

    }

}
