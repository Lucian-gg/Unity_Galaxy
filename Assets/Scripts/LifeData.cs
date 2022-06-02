using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LifeData
{
    public int life;

    public LifeData(Lifemanager lifemanager)
    {
        life = lifemanager.Cantlife;
    }
}
