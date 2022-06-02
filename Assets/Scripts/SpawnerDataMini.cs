using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpawnerDataMini
{
    public float x;
    public float y;
    public float z;

    public float speed;
    public bool saved = true;

    public List<float> xs = new List<float>();
    public List<float> ys = new List<float>();
    public List<float> zs = new List<float>();

    public List<float> speeds = new List<float>();

    public SpawnerDataMini(FindAteroidsToSaveMinis asteroidlist)
    {
        for (int i = 0; i < asteroidlist.misasteroides.Length; i++)
        {
            speeds.Add(asteroidlist.misasteroides[i].Speed);
            xs.Add(asteroidlist.misasteroides[i].transform.position.x);
            ys.Add(asteroidlist.misasteroides[i].transform.position.y);
            zs.Add(asteroidlist.misasteroides[i].transform.position.z);
            asteroidlist.misasteroides[i].Saved = true;
        }
        
    }
}
