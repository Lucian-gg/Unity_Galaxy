using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using KennethDevelops.Serialization;



public class shipmodelController : MonoBehaviour
{
    private List<IWeapon> Weapons = new List<IWeapon>();
    private IWeapon CurrentWeapon;
    private Rigidbody2D rb;

    private ShipmodelModel Model;

    private List<IPowerUp> Buffs = new List<IPowerUp>();

    private void Awake()
    {
        Model = GetComponent<ShipmodelModel>();

        IWeapon arma1 = GetComponentInChildren<AutomaticWeapon>();
        IWeapon armaLaser = GetComponentInChildren<LaserWeapon>();

        Weapons.Add(arma1);
        Weapons.Add(armaLaser);

        CurrentWeapon = Weapons[0];
        
        //Buffs.Add()

        SaveData();
    }

    public void FixedUpdate()
    {
         Model.vertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(transform.up * Model.SSpeed * Model.vertical * Time.deltaTime);
        }

        if (rb.velocity.magnitude > Model.MaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * Model.MaxSpeed;
        }

    }

    void Start()
    {
        EventManager.instance.Suscribe("OnLoosing", OnLoosing);
        EventManager.instance.Suscribe("OnGameLoaded", OnGameLoaded);
        EventManager.instance.Suscribe("OnGameSaved", OnGameSaved);
        rb = GetComponent<Rigidbody2D>();
    }


    public void OnGameLoaded(params object[] parameters)
    {
        var shipdata = BinarySerializer.LoadBinary<ShipData>(Application.dataPath + "/Resources/player.dat");
        transform.position = new Vector3(shipdata.x, shipdata.y, shipdata.z);
        rb.velocity = new Vector2(0, 0);
    }

    private void OnLoosing(params object[] parameters)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(0, 0, -Model.RotSpeed * h * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = Weapons[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = Weapons[0];
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.K)) LoadData();
        if (Input.GetKeyDown(KeyCode.J)) SaveData();
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
        if (collision.gameObject.tag == "Buff")
        {
            IPowerUp buff1 = FindObjectOfType<MediKit>();
            buff1.Buff();
        }
        


    }

    public void OnPickupUpgrade(IPowerUp upgrade)
    {

    }

    private void SaveData()
    {
        var shipdata = new ShipData(this);
        shipdata.SaveBinary(Application.dataPath + "/Resources/player.dat");
        Debug.Log("game saved!");
    }

    private void LoadData()
    {
        var shipdata = BinarySerializer.LoadBinary<ShipData>(Application.dataPath + "/Resources/player.dat");
        transform.position = new Vector3(shipdata.x, shipdata.y, shipdata.z);
        rb.velocity = new Vector2(0, 0);         // Me parecia molesto que mantuviera la inercia del save, asi que a diferencia de los meteoritos no mantiene su velocidad.
    }

    public void OnGameSaved(params object[] parameters)
    {
        var shipdata = new ShipData(this);
        shipdata.SaveBinary(Application.dataPath + "/Resources/player.dat");
        Debug.Log("game saved!");
    }

}

