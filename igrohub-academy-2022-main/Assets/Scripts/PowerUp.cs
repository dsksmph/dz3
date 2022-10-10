using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PowerUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                Destroy(gameObject);
                player.ActivatePowerUp();
            }
        }
    }
}
