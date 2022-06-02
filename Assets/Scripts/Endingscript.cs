using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Endingscript : MonoBehaviour
{
    public int Meteoritos = 0;
    public int CheckMeteoritos = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Meteoritos += 1;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            CheckMeteoritos += 1;

            if (CheckMeteoritos >= Meteoritos)
            {
                EventManager.instance.Trigger("OnWinning");
            }
        }
    }

}
