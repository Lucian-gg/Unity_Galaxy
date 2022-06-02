using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAsteroidScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float Speed;
    public GameObject Explosion1;
    public bool Saved = false;

    private LookUpTable<string, GameObject> LookpTableAsteroids;

    public Transform SafePos;

    void Start()
    {
        LookpTableAsteroids = new LookUpTable<string, GameObject>(Boom);

        rb = GetComponent<Rigidbody2D>();
        Speed = Random.Range(0.8f, 3.3f);
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * Speed;

        Explosion1 = Resources.Load<GameObject>("Prefabs/Particle");
    }

    private GameObject Boom(string codigo)
    {
        return Instantiate(Explosion1, transform.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "teleIzq")
        {
            transform.position += new Vector3(19, 0, 0);
        }

        if (collision.gameObject.tag == "teleder")
        {
            transform.position -= new Vector3(19, 0, 0);
        }

        if (collision.gameObject.tag == "arrib")
        {
            transform.position -= new Vector3(0, 10.5f, 0);
        }

        if (collision.gameObject.tag == "abajo")
        {
            transform.position += new Vector3(0, 10, 0);
        }
        
        if (collision.gameObject.tag == "Bala")
        {
            //LookpTableAsteroids.Get("PaticleEffects1");
            Instantiate(Explosion1, transform.position, Quaternion.identity);
            EventManager.instance.Trigger("OnAsteroidDestroyed");

            //Destroy(gameObject);
            transform.position = SafePos.position;
        }

        if (collision.gameObject.tag == "Player")
        {
            //LookpTableAsteroids.Get("PaticleEffects1");
            Instantiate(Explosion1, transform.position, Quaternion.identity);
            EventManager.instance.Trigger("OnPlayerCrash");
            //Destroy(gameObject);
            transform.position = SafePos.position;
        }
    }
}
