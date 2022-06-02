using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder
{
    private float SpeedBuilder;
    

    public void SetSpeed(float speed)
    {
        SpeedBuilder = speed;
    }


    public Bullet Craft()
    {

         var prefab = Resources.Load<Bullet>("Prefabs/Bullet1");
          
         prefab.SSpeed = SpeedBuilder;
         return UnityEngine.Object.Instantiate(prefab);

    }

}
