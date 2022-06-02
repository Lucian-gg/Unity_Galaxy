using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizatedText : MonoBehaviour
{
    public string textName;
    public TextMeshProUGUI _text;
    

    public void Start()
    {
        OnLanguageChanged();
        EventManager.instance.Suscribe("OnLanguageChanged", OnLanguageChanged);
    }

    public void OnLanguageChanged(params object[] parameters)
    {
        if (_text == null) _text = GetComponent<TextMeshProUGUI>();
        _text.text = LocalizationManager.Instance.GetText(textName);
    }
}
