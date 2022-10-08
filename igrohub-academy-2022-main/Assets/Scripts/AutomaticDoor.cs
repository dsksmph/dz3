using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider))]
    public class AutomaticDoor : MonoBehaviour
    {
        [SerializeField] private GameObject door;
        private int layerMaskWall;
        private int layerMaskDefault;
        private bool isDoorOpen;

        private void Awake()
        {
            layerMaskWall = LayerMask.NameToLayer("Wall");
            layerMaskDefault = LayerMask.NameToLayer("Default");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                OpenDoor();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                var flatPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
                var flatDoorPosition = new Vector2(door.transform.position.x, door.transform.position.z);

                if (flatPlayerPosition == flatDoorPosition && isDoorOpen)
                {
                    return;
                }
                else
                {
                    CloseDoor();
                }
            }
        }

        private void OpenDoor()
        {
            isDoorOpen = true;
            door.transform.localScale = new Vector3(1, (float)0.1, 1);
            door.gameObject.layer = layerMaskDefault;
        }

        private void CloseDoor()
        {
            isDoorOpen = false;
            door.transform.localScale = new Vector3(1, 1, 1);
            door.gameObject.layer = layerMaskWall;
        }
    }
}
