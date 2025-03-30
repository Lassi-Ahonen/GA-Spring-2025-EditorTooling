using UnityEngine;

namespace Lasriel.Editor {

    /// <summary>
    /// IMGUI styles for enemy tracker window.
    /// </summary>
    public static class EnemyTrackerStyles {

        private static GUIStyle m_SectionStyle;
        public static GUIStyle SectionStyle {
            get {
                if (m_SectionStyle == null) {
                    m_SectionStyle = new GUIStyle(GUI.skin.GetStyle("sv_iconselector_back")) {
                        padding = new RectOffset(4, 4, 4, 4),
                        margin = new RectOffset(4, 4, 4, 4),
                        stretchHeight = false,
                        stretchWidth = true
                    };
                }
                return m_SectionStyle;
            }
        }

        private static GUIStyle m_LabelStyle;
        public static GUIStyle LabelStyle {
            get {
                if (m_LabelStyle == null) {
                    m_LabelStyle = new GUIStyle(GUI.skin.GetStyle("label")) {
                        margin = new RectOffset(4, 4, 4, 4),
                        stretchHeight = false,
                        stretchWidth = false,
                        fixedWidth = 150,
                    };
                }
                return m_LabelStyle;
            }
        }

        private static GUIStyle m_ButtonStyle;
        public static GUIStyle ButtonStyle {
            get {
                if (m_ButtonStyle == null) {
                    m_ButtonStyle = new GUIStyle(GUI.skin.GetStyle("button")) {
                        stretchHeight = false,
                        stretchWidth = false,
                        fixedWidth = 50,
                    };
                }
                return m_ButtonStyle;
            }
        }

        private static GUIStyle m_ProgressBarStyle;
        public static GUIStyle ProgressBarStyle {
            get {
                if (m_ProgressBarStyle == null) {
                    m_ProgressBarStyle = new GUIStyle {
                        margin = new RectOffset(4, 4, 4, 4),
                        stretchHeight = false,
                        stretchWidth = true,
                    };
                }
                return m_ProgressBarStyle;
            }
        }


    }

}
