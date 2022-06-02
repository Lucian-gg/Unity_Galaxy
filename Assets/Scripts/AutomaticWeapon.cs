using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AutomaticWeapon : MonoBehaviour, IWeapon
{
    
    private Pool<Bullet> BulletPool;
    public Transform BulletSpawnPos;

    public GameObject Nave; 

    void Awake()
    {
        var factory = new BulletFactory();
        BulletPool = new Pool<Bullet>(factory.Create, Bullet.TurnOn, Bullet.TurnOff, 5);

    }


    public void Shoot()
    {
        
        var bullet = BulletPool.Get();
        bullet.BulletPool = BulletPool;
        bullet.transform.position = BulletSpawnPos.position;
        bullet.transform.forward =  Nave.transform.forward;
        bullet.transform.rotation = Nave.transform.rotation;
    }

   

}
