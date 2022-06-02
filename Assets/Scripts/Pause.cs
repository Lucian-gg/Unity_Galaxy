using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    bool ispaused = false;
    public TextMeshProUGUI Pausa;

    public GameObject Save;
    public GameObject Load;

    private void Start()
    {
        Pausa = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) PauseGame();
    }

    public void PauseGame()
    {
        if (ispaused)
        {
            Time.timeScale = 1;
            ispaused = false;
            Pausa.enabled = false;
            Save.gameObject.SetActive(false);
            Load.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            ispaused = true;
            Pausa.enabled = true;
            Save.gameObject.SetActive(true);
            Load.gameObject.SetActive(true);
        }
    }

    public void SaveGame()
    {
        EventManager.instance.Trigger("OnGameSaved");
    }

    public void LoadGame()
    {
        EventManager.instance.Trigger("OnGameLoaded");
    }

}
