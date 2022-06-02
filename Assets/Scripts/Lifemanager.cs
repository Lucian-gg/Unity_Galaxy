using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using KennethDevelops.Serialization;

public class Lifemanager : MonoBehaviour
{
    public TextMeshProUGUI Vidas;
    public TextMeshProUGUI Perdida;

    public int Cantlife;
    public bool Lost = false;



    private void Awake()
    {
        SaveData();
    }
    void Start()
    {
        EventManager.instance.Suscribe("OnPlayerCrash", OnPlayerCrash);
        EventManager.instance.Suscribe("OnGameSaved", OnGameSaved);
        EventManager.instance.Suscribe("OnGameLoaded", OnGameLoaded);
        EventManager.instance.Suscribe("MedikitBuff", MedikitBuff);
    }

    private void Update()
    {
        if (Cantlife <= 0 && Lost==false)
        {
            Perdida.enabled = true;
            EventManager.instance.Trigger("OnLoosing");
            Lost = true;
        }

        if (Input.GetKeyDown(KeyCode.K)) LoadData();
    }

    private void MedikitBuff(params object[] parameters)
    {
        Cantlife = 3;
        Vidas.text = "" + Cantlife;
    }

    private void OnPlayerCrash(params object[] parameters)
    {
        Cantlife -= 1;
        Vidas.text = "" + Cantlife;
    }

    private void SaveData()
    {
        var lifedata = new LifeData(this);
        lifedata.SaveBinary(Application.dataPath + "/Resources/life.dat");
    }

    private void LoadData()
    {
        var lifedata = BinarySerializer.LoadBinary<LifeData>(Application.dataPath + "/Resources/life.dat");
        Cantlife = lifedata.life;
        Vidas.text = "" + Cantlife;
    }

    public void OnGameLoaded(params object[] parameters)
    {
        LoadData();
    }

    public void OnGameSaved(params object[] parameters)
    {
        LoadData();
    }




}
