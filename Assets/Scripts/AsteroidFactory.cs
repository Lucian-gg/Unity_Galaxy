using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : IFactory<AsteroidScript>
{
    public AsteroidScript Create()
    {
        var astiBuilder = new AsteroidBuilder();
        astiBuilder.SetBaseSpeedAndDirection(AsteroidFlyweightPointer.normal.Speed + Random.Range(AsteroidFlyweightPointer.normal.Min, AsteroidFlyweightPointer.normal.Max), new Vector3(Random.Range(-AsteroidFlyweightPointer.normal.Base, AsteroidFlyweightPointer.normal.Base), Random.Range(-AsteroidFlyweightPointer.normal.Base, AsteroidFlyweightPointer.normal.Base), 0));
        var asti = astiBuilder.Craft();
        return asti;
    }
}
