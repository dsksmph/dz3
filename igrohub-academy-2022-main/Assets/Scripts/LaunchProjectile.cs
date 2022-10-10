using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] private EnemyProjectile projectilePrefab;
        [SerializeField] private float launchVelocity;
        [SerializeField] private Level _level;
        [SerializeField] private int defaultPoolCapacity;
        [SerializeField] private int maxSizePoolCapacity;
        [SerializeField] private bool usePool;

        private ObjectPool<EnemyProjectile> pool;

        private void Start()
        {
            pool = new ObjectPool<EnemyProjectile>(() =>
            {
                return Instantiate(projectilePrefab, transform.position, transform.rotation);
            },
                projectile => { projectile.gameObject.SetActive(true); },
                projectile => { projectile.gameObject.SetActive(false); },
                projectile => { Destroy(projectile.gameObject); },
                true, defaultPoolCapacity, maxSizePoolCapacity);

            StartCoroutine(ShootingCoroutine());
        }

        private void DestroyProjectile(EnemyProjectile projectile)
        {
            if (usePool) pool.Release(projectile);
            else Destroy(projectile.gameObject);
        }

        private IEnumerator ShootingCoroutine()
        {
            while (!_level._gameIsEnded)
            {
                yield return new WaitForSeconds(2f);
                var _projectile = usePool ? pool.Get() : Instantiate(projectilePrefab, transform.position, transform.rotation);
                _projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
                _projectile.Init(DestroyProjectile);
            }
        }
    }
}
