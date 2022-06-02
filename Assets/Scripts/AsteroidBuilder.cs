using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBuilder
{

    private float BaseSpeed;
    private Vector3 BaseDireccion;

    public void SetBaseSpeedAndDirection(float speed, Vector3 direccion)
    {
        BaseSpeed = speed;
        BaseDireccion = direccion;
    }

    public AsteroidScript Craft()
    {

        var prefab = Resources.Load<AsteroidScript>("Prefabs/Asteroid");
        prefab.SSpeed = BaseSpeed;
        prefab.DDirection = BaseDireccion;
        return UnityEngine.Object.Instantiate(prefab);
    }
}
