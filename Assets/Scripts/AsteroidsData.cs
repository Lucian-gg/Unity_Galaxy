using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AsteroidsData
{
    public float x;
    public float y;
    public float z;
    public float speedx;
    public float speedy;

    public AsteroidsData(AsteroidScript model)
    {
        x = model.transform.position.x;
        y = model.transform.position.y;
        z = model.transform.position.z;

        speedx = model.rb.velocity.x;
        speedy = model.rb.velocity.y;
    }
}
