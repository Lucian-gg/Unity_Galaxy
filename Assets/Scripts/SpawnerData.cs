using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpawnerData
{
    public float x;
    public float y;
    public float z;

    public float speed;

    public List<float> xs = new List<float>();
    public List<float> ys = new List<float>();
    public List<float> zs = new List<float>();

    public List<float> speeds = new List<float>();

    public SpawnerData(FindAteroidsToSave asteroidlist)
    {
        for (int i = 0; i < asteroidlist.misasteroides.Length; i++)
        {
            speeds.Add(asteroidlist.misasteroides[i].SSpeed);
            xs.Add(asteroidlist.misasteroides[i].transform.position.x);
            ys.Add(asteroidlist.misasteroides[i].transform.position.y);
            zs.Add(asteroidlist.misasteroides[i].transform.position.z);
        }
    }
}
