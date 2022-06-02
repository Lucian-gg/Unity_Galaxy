using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookUpTable<TKey, TValue>
{
    private Dictionary<TKey, TValue> _Values = new Dictionary<TKey, TValue>();

    private Func<TKey, TValue> _process;

    public LookUpTable(Func<TKey, TValue> process)
    {
        _process = process;
    }

    public TValue Get(TKey key)
    {
        if (!_Values.ContainsKey(key))
        {
            _Values[key] = _process(key);
            //Debug.Log("PruebaSiTieneCargadaLaExplosion");
        }

        return _Values[key];

    }
}
