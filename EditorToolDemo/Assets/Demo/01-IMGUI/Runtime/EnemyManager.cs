using UnityEngine;
using System.Collections.Generic;

namespace Lasriel {

    /// <summary>
    /// Manager class that would keep track of enemies.
    /// Editor window utilizes this class to get references to all enemies.
    /// </summary>
    public class EnemyManager : MonoBehaviour {

        // For demo purposes enemies are added manually to the list
        // Normally manager would handle spawning and despawning them
        [SerializeField] private List<Enemy> m_Enemies;

        /// <summary>
        /// Enumerator to iterate through all enemies owned by this manager.
        /// </summary>
        public IEnumerator<Enemy> Enemies => m_Enemies.GetEnumerator();

    }

}
