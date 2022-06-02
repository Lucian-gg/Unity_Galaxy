using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using KennethDevelops.Serialization;

public class AsteroidScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject MiniSteroid;
    public float SSpeed;
    public Vector3 DDirection;

    public GameObject Explosion1;
    public Pool<AsteroidScript> pool;

    public Transform SafePos;

    private LookUpTable<string, GameObject> LookpTableAsteroids;

    void Start()
    {

        LookpTableAsteroids = new LookUpTable<string, GameObject>(Boom);
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = DDirection.normalized * SSpeed;

        Explosion1 = Resources.Load<GameObject>("Prefabs/Particle");

    }


    private GameObject Boom(string codigo)
    {
        return Instantiate(Explosion1, transform.position, Quaternion.identity);
    }

    public static void TurnOn(AsteroidScript asti)
    {
        asti.gameObject.SetActive(true);
    }

    public static void TurnOff(AsteroidScript asti)
    {
        asti.gameObject.SetActive(false);
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
            Instantiate(MiniSteroid, transform.position, Quaternion.identity);
            Instantiate(MiniSteroid, transform.position, Quaternion.identity);
            EventManager.instance.Trigger("OnAsteroidDestroyed");

            Instantiate(Explosion1, transform.position, Quaternion.identity);
            //LookpTableAsteroids.Get("PaticleEffects1");

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
