﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreData
{
    public int puntaje;

    public ScoreData(ScoreManager scoremanager)
    {
        puntaje = scoremanager.Puntaje;
    }
}
