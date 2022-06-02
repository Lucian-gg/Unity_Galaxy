
using UnityEngine;

public class Bullet : MonoBehaviour
{
   

    public float TimeToDestroy;
    public Pool<Bullet> BulletPool;
    private float SpawnTime;

    public float SSpeed; 

    void OnEnable()
    {
        SpawnTime = Time.time;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
       
       transform. position += transform.up * (SSpeed * Time. deltaTime);

        
    }

    private void LateUpdate()
    {
        if (SpawnTime + TimeToDestroy <= Time.time)
            Die();
    }

    public static void TurnOn(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public static void TurnOff(
        Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void Die()
    {
        BulletPool.ReturnToPool(this);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Meteorito")
        {
            
            Destroy(gameObject);
        }
    }

    
    
      
}
