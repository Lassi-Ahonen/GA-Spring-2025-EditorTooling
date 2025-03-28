using UnityEngine;

namespace Lasriel {

    // Demonstrates the usage of custom proprty drawers using UI Toolkit
    public class InspectorDemo : MonoBehaviour {

        [SerializeField] private FloatRange m_Range;

        [Tooltip("There is also tooltip support.")]
        [SerializeField] private FloatRange m_InitializedRange = new FloatRange(1f, 5f);

    }

}
