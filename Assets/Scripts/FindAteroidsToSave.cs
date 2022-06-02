using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KennethDevelops.Serialization;

public class FindAteroidsToSave : MonoBehaviour
{
    public AsteroidScript[] misasteroides;

    private Pool<AsteroidScript> AsteroidPool;

    public int Cantidad = 8;

    void Awake()
    {
        var factory = new AsteroidFactory();
        AsteroidPool = new Pool<AsteroidScript>(factory.Create, AsteroidScript.TurnOn, AsteroidScript.TurnOff, Cantidad);

        for (int i = 0; i < Cantidad; i++)
        {
            Spawn();
        }
        SaveData();
        EventManager.instance.Suscribe("OnGameLoaded", OnGameLoaded);
        EventManager.instance.Suscribe("OnGameSaved", OnGameSaved);
    }


    public void Spawn()
    {
        var asti = AsteroidPool.Get();
        asti.pool = AsteroidPool;
        asti.transform.position = transform.position + new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            misasteroides = FindObjectsOfType(typeof(AsteroidScript)) as AsteroidScript[];
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.K)) LoadData();
    }

    private void SaveData()
    {
        var spawnerdata = new SpawnerData(this);
        spawnerdata.SaveBinary(Application.dataPath + "/Resources/spawner.dat");
    }

    private void LoadData()
    { 
        var spawner = BinarySerializer.LoadBinary<SpawnerData>(Application.dataPath + "/Resources/spawner.dat");
        
        for (int i = 0; i < misasteroides.Length; i++)
        {
            if (misasteroides[i]!=null)
            {
                misasteroides[i].SSpeed = spawner.speeds[i];
                misasteroides[i].transform.position = new Vector3(spawner.xs[i], spawner.ys[i], spawner.zs[i]);
            }
        }
    }


    public void OnGameLoaded(params object[] parameters)
    {
        var spawner = BinarySerializer.LoadBinary<SpawnerData>(Application.dataPath + "/Resources/spawner.dat");

        for (int i = 0; i < misasteroides.Length; i++)
        {
            if (misasteroides[i] != null)
            {
                misasteroides[i].SSpeed = spawner.speeds[i];
                misasteroides[i].transform.position = new Vector3(spawner.xs[i], spawner.ys[i], spawner.zs[i]);
            }
        }
    }

    public void OnGameSaved(params object[] parameters)
    {
        misasteroides = FindObjectsOfType(typeof(AsteroidScript)) as AsteroidScript[];
        var spawnerdata = new SpawnerData(this);
        spawnerdata.SaveBinary(Application.dataPath + "/Resources/spawner.dat");                
    }
}

