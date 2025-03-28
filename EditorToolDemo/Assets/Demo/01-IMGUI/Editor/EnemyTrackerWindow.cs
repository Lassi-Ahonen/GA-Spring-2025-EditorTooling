using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Lasriel.Editor {

    public class EnemyTrackerWindow : EditorWindow {

        private const string k_WindowName = "Enemy Tracker";

        [SerializeField] private Vector2 m_ScrollPosition;
        [SerializeField] private EnemyManager[] m_Managers;

        [MenuItem("Window/Enemy Tracker")]
        public static void Open() {
            // Open a new or existing editor window
            EditorWindow window = GetWindow(typeof(EnemyTrackerWindow));
            // Assign window title
            window.titleContent = new GUIContent(k_WindowName);
        }

        private void OnHierarchyChange() {
            Repaint();
        }

        private void Update() {
            if (Application.isPlaying) {
                Repaint();
            }
        }

        private void OnGUI() {
            GetManagers();
            Draw();
        }

        private void Draw() {

            GUIStyle section = new GUIStyle(GUI.skin.GetStyle("sv_iconselector_back")) {
                padding = new RectOffset(4, 4, 4, 4),
                margin = new RectOffset(4, 4, 4, 4),
                stretchHeight = false,
                stretchWidth = true
            };

            m_ScrollPosition = EditorGUILayout.BeginScrollView(m_ScrollPosition, false, false);

            GUILayout.Label(k_WindowName);
            EditorGUILayout.BeginVertical(section);

            if (m_Managers != null) {
                for (int i = 0; i < m_Managers.Length; i++) {
                    DrawEnemies(m_Managers[i]);
                }
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        private void DrawEnemies(EnemyManager manager) {
            if (manager == null) return;

            IEnumerator<Enemy> enemies = manager.Enemies;

            GUILayout.Label(manager.gameObject.name);

            while (enemies.MoveNext()) {
                EditorGUILayout.BeginHorizontal();
                Enemy enemy = enemies.Current;
                if (enemy == null) continue;
                GUIStyle nameStyle = new GUIStyle(GUI.skin.GetStyle("label")) {
                    margin = new RectOffset(4, 4, 4, 4),
                    stretchHeight = false,
                    stretchWidth = false,
                    fixedWidth = 150,
                };
                GUILayout.Label(enemy.Name, nameStyle);
                GUIStyle progressBarStyle = new GUIStyle {
                    margin = new RectOffset(4, 4, 4, 4),
                    stretchHeight = false,
                    stretchWidth = true,
                };
                EditorGUI.ProgressBar(GUILayoutUtility.GetRect(100, 20, progressBarStyle), (float)enemy.CurrentHealth / enemy.MaxHealth, "Health");
                EditorGUILayout.EndHorizontal();
            }

        }

        private void GetManagers() {
            m_Managers = FindObjectsByType<EnemyManager>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        }

    }

}
