using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Turret : MonoBehaviour //터렛에서 발사
{
    public List<Transform> turretBarrels;
    public GameObject bulletProfab;
    public float reloadDelay = 1;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField]
    private int bulletPoolCount = 10;

    private void Awake()
    {
        tankColliders = GetComponentsInChildren<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        bulletPool.Initialized(bulletProfab, bulletPoolCount);
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                //GameObject bullet = Instantiate(bulletProfab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.transform.position;
                bullet.transform.rotation = barrel.transform.rotation;
                bullet.GetComponent<Bullet>().Initializes();    //초기화

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider); //콜리젼을 무시해라
                }
            }
        }
    }
}
