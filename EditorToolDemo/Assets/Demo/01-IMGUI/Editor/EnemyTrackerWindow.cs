using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Lasriel.Editor {

    /// <summary>
    /// Editor window to visualize enemy data and have functionality to modify enemy data.
    /// </summary>
    public class EnemyTrackerWindow : EditorWindow {

        private const string k_WindowName = "Enemy Tracker";

        // Scroll position is serialized to this field
        [SerializeField] private Vector2 m_ScrollPosition;
        // Enemy managers that are being drawn
        [SerializeField] private EnemyManager[] m_Managers;

        // Creates a menu item to the top toolbar under Window
        [MenuItem("Window/Enemy Tracker")]
        public static void Open() {
            // Open a new or existing editor window
            EditorWindow window = GetWindow(typeof(EnemyTrackerWindow));
            // Assign window title
            window.titleContent = new GUIContent(k_WindowName);
        }

        // Repaint the GUI when scene hierarchy changes
        private void OnHierarchyChange() {
            Repaint();
        }

        private void Update() {
            // While editor is in play mode, update GUI to see changes in enemy variables
            if (Application.isPlaying) {
                Repaint();
            }
        }

        private void OnGUI() {
            // Can't really cache the managers since hierarchy might change during runtime
            // There might be a better way to do this but Unity's documentation on it is not great
            // You could also use global manager for all enemies which would solve this issue
            GetManagers();

            // Draw the GUI
            Draw();
        }

        private void Draw() {
            // Tree view of the GUI structure
            // Scroll view
            // > Window Name Label
            // > Manager Section (Vertical Layout)
            // > > Manager Label
            // > > Enemy (Horizontal Layout)
            // > > > Enemy Name Label
            // > > > Enemy Health Progress Bar
            // > > > Enemy Kill Button

            // Scroll view position can be saved to serialized field
            m_ScrollPosition = EditorGUILayout.BeginScrollView(
                scrollPosition: m_ScrollPosition,
                alwaysShowHorizontal: false,
                alwaysShowVertical: false
            );

            GUILayout.Label(k_WindowName);

            // Each manager is put in their own section and enemies are drawn inside the section
            GUIStyle section = EnemyTrackerStyles.SectionStyle;
            if (m_Managers != null) {
                for (int i = 0; i < m_Managers.Length; i++) {
                    EditorGUILayout.BeginVertical(section);
                    DrawEnemies(m_Managers[i]);
                    EditorGUILayout.EndVertical();
                }
            }

            EditorGUILayout.EndScrollView();
        }

        // Draws enemy manager
        private void DrawEnemies(EnemyManager manager) {
            if (manager == null) return;

            // Get all enemies to iterate through
            IEnumerator<Enemy> enemies = manager.Enemies;

            // Manager game object name
            GUILayout.Label(manager.gameObject.name);

            // Draw all enemies owned by the manager
            while (enemies.MoveNext()) {
                Enemy enemy = enemies.Current;
                if (enemy == null) continue; // Skip empty list entries
                DrawEnemy(enemy);
            }

        }

        // Draws a single enemy GUI element
        private void DrawEnemy(Enemy enemy) {
            EditorGUILayout.BeginHorizontal();

            // Enemy name label
            GUILayout.Label(enemy.Name, EnemyTrackerStyles.LabelStyle);

            // Enemy health bar
            EditorGUI.ProgressBar(
                position: GUILayoutUtility.GetRect(100, 16, EnemyTrackerStyles.ProgressBarStyle),
                value: (float)enemy.CurrentHealth / enemy.MaxHealth,
                text: "Health"
            );

            // Enemy kill button
            if (GUILayout.Button("Kill", EnemyTrackerStyles.ButtonStyle)) {
                // Button press action
                enemy.Kill();
            }

            EditorGUILayout.EndHorizontal();
        }

        // Finds all enemy manager objects
        private void GetManagers() {
            m_Managers = FindObjectsByType<EnemyManager>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID);
        }

    }

}
