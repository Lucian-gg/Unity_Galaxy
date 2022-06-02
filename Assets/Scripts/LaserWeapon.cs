using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour, IWeapon
{
    private Pool<Laser> LaserPool;
    public Transform BulletSpawnPos;

    public GameObject Nave;

    void Awake()
    {
        var factorylaser = new LaserFactory();

        LaserPool = new Pool<Laser>(factorylaser.Create, Laser.TurnOn, Laser.TurnOff, 3);

    }


    void Update()
    {
        
    }

    public void Shoot()
    {

                                                                                     //Instantiate(prefab, bulletSpawnPos.transform.position, Quaternion.identity);
            var laser  = LaserPool.Get();
            laser.pool = LaserPool;
            laser.transform.position = BulletSpawnPos.position;
            laser.transform.forward = transform.forward;
            laser.transform.rotation = transform.rotation;

       

    }
}
