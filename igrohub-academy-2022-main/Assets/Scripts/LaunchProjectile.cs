using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private float launchVelocity;
        [SerializeField] private Level _level;

        private void Start()
        {
            StartCoroutine(ShootingCoroutine());
        }

        private void Update()
        {

        }

        private IEnumerator ShootingCoroutine()
        {
            while (!_level._gameIsEnded)
            {
                GameObject _projectile = ObjectPool.SharedInstance.GetPooledObject();
                if(_projectile != null)
                {
                    _projectile.transform.position = transform.position;
                    _projectile.transform.rotation = transform.rotation;
                    _projectile.SetActive(true);
                }
                _projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
