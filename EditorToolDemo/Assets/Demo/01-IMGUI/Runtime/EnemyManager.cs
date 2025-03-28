using UnityEngine;
using System.Collections.Generic;

namespace Lasriel {

    public class EnemyManager : MonoBehaviour {

        [SerializeField] private List<Enemy> m_Enemies;

        public IEnumerator<Enemy> Enemies => m_Enemies.GetEnumerator();

    }

}
