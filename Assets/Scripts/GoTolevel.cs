using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoTolevel : MonoBehaviour
{

    public void siguiente()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HOW()
    {
        SceneManager.LoadScene("HowToPlay");
    }


    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Español()
    {
        LocalizationManager.Instance.SwitchLanguage();
        EventManager.instance.Trigger("OnLanguageChanged");
    }
}
