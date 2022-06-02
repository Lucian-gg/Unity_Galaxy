using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipmodelView : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    public Animator fireanimation;
    public ShipmodelModel model;

    private void Start()
    {
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[0];
        fireanimation  = GetComponentsInChildren<Animator>()[0];

        spriteRenderer.sprite = sprite;
        model = GetComponent<ShipmodelModel>();
    }

    private void Update()
    {
        if (model.vertical>0)
        {
            var fire = fireanimation.GetComponent<SpriteRenderer>();
            fire.enabled = true;
        }
        else
        {
            var fire = fireanimation.GetComponent<SpriteRenderer>();
            fire.enabled = false;
        }
    }


}
