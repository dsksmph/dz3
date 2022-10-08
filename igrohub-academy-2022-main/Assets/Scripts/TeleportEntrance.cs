using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider))]
    public class TeleportEntrance : MonoBehaviour
    {
        [SerializeField] private GameObject teleportExit;
        [SerializeField] private TeleportExit _teleportExit;
        public bool isActive;

        private void Awake()
        {
            _teleportExit = teleportExit.GetComponent<TeleportExit>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                var flatTeleportEntrancePosition = new Vector2(this.transform.position.x, this.transform.position.z);
                var flatPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.z);

                if(flatTeleportEntrancePosition == flatPlayerPosition && this.isActive)
                {
                    _teleportExit.isActive = false;
                    player.transform.position = teleportExit.transform.position;
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            this.isActive = true;
        }
    }
}
