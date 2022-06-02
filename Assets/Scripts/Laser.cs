using UnityEngine;

public class Laser : MonoBehaviour
{
    private float SSpeed = 0f;
    

    public float TimeToDestroy;
    public Pool<Laser> pool;


    private float SpawnTime;

    void OnEnable()
    {
        SpawnTime = Time.time;
    }

    private void Update()
    {
        transform.position += transform.up * (SSpeed * Time.deltaTime);


    }

    private void LateUpdate()
    {
        if (SpawnTime + TimeToDestroy <= Time.time)
            Die();
    }

    public static void TurnOn(Laser laser)
    {
        laser.gameObject.SetActive(true);
    }

    public static void TurnOff(
        Laser laser)
    {
        laser.gameObject.SetActive(false);
    }

    private void Die()
    {
        pool.ReturnToPool(this);
    }

    


}
