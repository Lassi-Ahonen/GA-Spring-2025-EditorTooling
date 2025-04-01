using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Lasriel.Editor {

    /// <summary>
    /// Simple game object spawner editor window with position, rotation and count settings.
    /// </summary>
    public class SpawnerWindow : EditorWindow {

        private const string k_WindowName = "Spawner";

        private static VisualTreeAsset m_WindowUxml;
        private static VisualTreeAsset WindowUxml {
            get {
                // If we haven't loaded the UI structure yet, load it
                if (m_WindowUxml == null) {
                    m_WindowUxml = Resources.Load<VisualTreeAsset>("SpawnerWindowStructure");
                }
                return m_WindowUxml;
            }
            set => m_WindowUxml = value;
        }

        // Editor window values get stored in these variables
        [SerializeField] private GameObject SpawnObject = null;
        [SerializeField] private Vector3 Position = Vector3.zero;
        [SerializeField] private Vector3 Rotation = Vector3.zero;
        [SerializeField] private int Count = 1;

        // Creates a menu item to the top toolbar under Window
        [MenuItem("Window/Game Object Spawner")]
        public static void Open() {
            // Create a new editor window and give it a name
            EditorWindow window = GetWindow(typeof(SpawnerWindow));
            window.titleContent = new GUIContent(k_WindowName);
        }

        // Unity message used by UI Toolkit, called when GUI is first created
        public void CreateGUI() {
            // Get window structure created in UI Toolkit and add it to editor window root
            VisualElement root = WindowUxml.Instantiate();
            rootVisualElement.Add(root);

            // Query fields from the uxml strcuture, these are defined in UI Toolkit as the element names
            // Q returns the first found element
            ObjectField spawnObjectField = (ObjectField)root.Q(name: "SpawnObject");
            Vector3Field positionField = (Vector3Field)root.Q(name: "Position");
            Vector3Field rotationField = (Vector3Field)root.Q(name: "Rotation");
            IntegerField countField = (IntegerField)root.Q(name: "SpawnCount");
            Button spawnButton = (Button)root.Q(name: "SpawnButton");

            // Set field values, if we have previous serialized values they are applied
            spawnObjectField.value = SpawnObject;
            positionField.value = Position;
            rotationField.value = Rotation;
            countField.value = Count;

            // Register callbacks for value changes in the fields
            // New values are stored in the serialized fields so when Unity reloads the GUI the values are kept
            // Stored values can also then be used elsewhere in the code
            spawnObjectField.RegisterValueChangedCallback((evt) => {
                SpawnObject = (GameObject)evt.newValue;
            });

            positionField.RegisterValueChangedCallback((evt) => {
                Position = evt.newValue;
            });

            rotationField.RegisterValueChangedCallback((evt) => {
                Rotation = evt.newValue;
            });

            countField.RegisterValueChangedCallback((evt) => {
                Count = evt.newValue;
            });

            // Register callback for button click
            spawnButton.clicked += Spawn;
        }

        // Called when the spawn button is clicked
        // Spawns count amount of game objects to a specific position and rotation
        private void Spawn() {
            if (SpawnObject == null || Count < 1) return;

            for (int i = 0; i < Count; i++) {
                Object.Instantiate(SpawnObject, Position, Quaternion.Euler(Rotation));
            }
            
        }

    }

}
