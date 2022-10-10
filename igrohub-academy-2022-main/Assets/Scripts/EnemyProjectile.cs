using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game
{
    public class EnemyProjectile : MonoBehaviour
    {
        private Action<EnemyProjectile> _destroyAction;

        public void Init(Action<EnemyProjectile> destroyAction)
        {
            _destroyAction = destroyAction;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Kill();
            }
            else
            {
                if (other.CompareTag("Wall"))
                {
                    _destroyAction(this);
                }
            }
        }
    }
}
