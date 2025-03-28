using UnityEngine;

namespace Lasriel {

    public class Enemy : MonoBehaviour {

        [SerializeField] private string m_EnemyName = "Enemy";

        [Header("Health")]
        [SerializeField] private int m_CurrentHealth = 0;
        [SerializeField] private int m_InitialHealth = 10;
        [SerializeField] private int m_MinHealth = 0;
        [SerializeField] private int m_MaxHealth = 10;

        public string Name => m_EnemyName;
        public int CurrentHealth => m_CurrentHealth;
        public int MaxHealth => m_MaxHealth;
        public int MinHealth => m_MinHealth;

        private void Start() {
            m_CurrentHealth = m_InitialHealth;
        }

        public void Kill() {
            m_CurrentHealth = 0;
        }

    }

}
