using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KennethDevelops.Serialization;

public class FindAteroidsToSaveMinis : MonoBehaviour
{
    public MiniAsteroidScript[] misasteroides;
    public MiniAsteroidScript[] checkifnotsaved;

    private void Start()
    {

        EventManager.instance.Suscribe("OnGameLoaded", OnGameLoaded);
        EventManager.instance.Suscribe("OnGameSaved", OnGameSaved);

        SaveData();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            misasteroides = FindObjectsOfType(typeof(MiniAsteroidScript)) as MiniAsteroidScript[];
            SaveData();
            if (Input.GetKeyDown(KeyCode.K)) LoadData();
        } 
    }

    private void SaveData()
    {
        var spawnerdata = new SpawnerDataMini(this);
        spawnerdata.SaveBinary(Application.dataPath + "/Resources/spawnerminis.dat");

    }

    private void LoadData()
    {
        var spawnerdata = BinarySerializer.LoadBinary<SpawnerDataMini>(Application.dataPath + "/Resources/spawnerminis.dat");

        for (int i = 0; i < misasteroides.Length; i++)
        {
            if (misasteroides[i] != null)
            {
                misasteroides[i].Speed = spawnerdata.speeds[i];
                misasteroides[i].transform.position = new Vector3(spawnerdata.xs[i], spawnerdata.ys[i], spawnerdata.zs[i]);
                if (misasteroides[i].Saved == false) checkifnotsaved[i].transform.position = checkifnotsaved[i].SafePos.position;
            }
        }

        checkifnotsaved = FindObjectsOfType(typeof(MiniAsteroidScript)) as MiniAsteroidScript[];

        for (int i = 0; i < checkifnotsaved.Length; i++)
        {
            if (checkifnotsaved[i].Saved == false)
            {
                checkifnotsaved[i].transform.position = checkifnotsaved[i].SafePos.position;
            }
        }
    }

    public void OnGameLoaded(params object[] parameters)
    {
        var spawner = BinarySerializer.LoadBinary<SpawnerDataMini>(Application.dataPath + "/Resources/spawnerminis.dat");

        for (int i = 0; i < misasteroides.Length; i++)
        {
            if (misasteroides[i] != null)
            {
                misasteroides[i].Speed = spawner.speeds[i];
                misasteroides[i].transform.position = new Vector3(spawner.xs[i], spawner.ys[i], spawner.zs[i]);
            }
        }

        checkifnotsaved = FindObjectsOfType(typeof(MiniAsteroidScript)) as MiniAsteroidScript[];

        for (int i = 0; i < checkifnotsaved.Length; i++)
        {

            if (checkifnotsaved[i].Saved == false)
            {
                checkifnotsaved[i].transform.position = checkifnotsaved[i].SafePos.position;
            }
        }
    }

    public void OnGameSaved(params object[] parameters)
    {
        var spawnerdata = new SpawnerDataMini(this);
        spawnerdata.SaveBinary(Application.dataPath + "/Resources/spawnerminis.dat");
    }
}
