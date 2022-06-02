using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFlyweight
{
    public float Speed;
    public float Min;
    public float Max;
    public float Base;
}

public class AsteroidFlyweightPointer
{
    public static AsteroidFlyweight normal = new AsteroidFlyweight { Speed = 0.1f, Min = 0.3f, Max = 1.7f, Base = 1f };
}

