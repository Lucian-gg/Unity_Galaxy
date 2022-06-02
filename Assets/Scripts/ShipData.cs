using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ShipData
{
    public float x;
    public float y;
    public float z;


    public ShipData(shipmodelController model)
    {
        x = model.transform.position.x;
        y = model.transform.position.y;         
        z = model.transform.position.z;
    }
}
