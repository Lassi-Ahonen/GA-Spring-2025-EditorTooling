using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lasriel {

    /// <summary>
    /// Custom data type with minimum and maximum floating point numbers.
    /// </summary>
    [Serializable]
    public struct FloatRange {

        [SerializeField] private float m_Min;
        [SerializeField] private float m_Max;

        /// <summary>
        /// Minimum value of the range.
        /// </summary>
        public float Min => m_Min;

        /// <summary>
        /// Maximum value of the range.
        /// </summary>
        public float Max => m_Max;

        /// <summary>
        /// Center value between the min and max values.
        /// </summary>
        public float Center => (m_Max + m_Min) / 2f;

        /// <summary>
        /// The difference between max and min values of this range.
        /// </summary>
        public float Size => m_Max - m_Min;

        /// <summary>
        /// Creates a new float range.
        /// </summary>
        /// <param name="min"> Minimum possible number. </param>
        /// <param name="max"> Maximum possible number. </param>
        public FloatRange(float min, float max) {
            m_Min = min;
            m_Max = max;
        }

        /// <summary>
        /// Get a random floating point number between the ranges min and max values.
        /// </summary>
        /// <returns> Random value inside the range. </returns>
        public float GetRandomValue() => Random.Range(m_Min, m_Max);

    }

}
