using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KennethDevelops.Serialization;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Victoria;
    public int Puntaje;

    private void Awake()
    {
        SaveData();
    }
    void Start()
    {
        EventManager.instance.Suscribe("OnWinning", OnWinning);
        EventManager.instance.Suscribe("OnAsteroidDestroyed", OnAsteroidDestroyed);
        EventManager.instance.Suscribe("OnPlayerCrash", OnPlayerCrash);
        EventManager.instance.Suscribe("OnGameSaved", OnGameSaved);
        EventManager.instance.Suscribe("OnGameLoaded", OnGameLoaded);
    }

    private void OnAsteroidDestroyed(params object[] parameters)
    {
        Puntaje += 10;
        Score.text = "" + Puntaje;
    }

    private void OnPlayerCrash(params object[] parameters)
    {
        Puntaje += -30;
        Score.text = "" + Puntaje;
    }

    private void OnWinning(params object[] parameters)
    {
        Victoria.enabled = true;
    }

    private void SaveData()
    {
        var scoredata = new ScoreData(this);
        scoredata.SaveBinary(Application.dataPath + "/Resources/score.dat");
    }

    private void LoadData()
    {
        var scoredata = BinarySerializer.LoadBinary<ScoreData>(Application.dataPath + "/Resources/score.dat");
        Puntaje = scoredata.puntaje;
        Score.text = "" + Puntaje;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) LoadData();
        if (Input.GetKeyDown(KeyCode.K)) LoadData();
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
