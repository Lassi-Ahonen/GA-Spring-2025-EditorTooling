using UnityEngine;

/// <summary>
/// Framerate cap for working in editor, laptop battery will thank you.
/// </summary>
public class EditorFramerateCap : MonoBehaviour {
#if UNITY_EDITOR

    public static EditorFramerateCap Instance;

    [SerializeField]
    private int fps = 60;

    private int m_Value {
        get {
            m_LastValue = fps;
            return fps;
        }
    }

    private int m_LastValue;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        // Set initial target framerate
        Application.targetFrameRate = m_Value;
    }

    private void Update() {
        // Update target framerate only when value was changed
        if (fps != m_LastValue) {
            Application.targetFrameRate = m_Value;
        }
    }

#endif
}