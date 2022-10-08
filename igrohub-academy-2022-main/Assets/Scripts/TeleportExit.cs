using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider))]
    public class TeleportExit : MonoBehaviour
    {
        [SerializeField] private GameObject teleportEntrance;
        [SerializeField] private TeleportEntrance _teleportEntrance;
        public bool isActive;

        private void Awake()
        {
            _teleportEntrance = teleportEntrance.GetComponent<TeleportEntrance>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                var flatTeleportExitPosition = new Vector2(this.transform.position.x, this.transform.position.z);
                var flatPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.z);

                if (flatTeleportExitPosition == flatPlayerPosition && this.isActive)
                {
                    _teleportEntrance.isActive = false;
                    player.transform.position = teleportEntrance.transform.position;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            this.isActive = true;
        }
    }
}
