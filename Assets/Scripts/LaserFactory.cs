using UnityEngine;

public class LaserFactory : IFactory<Laser>
{

    public Laser Create()
    {
        var prefab = Resources.Load<Laser>("Prefabs/Laser");

        return Object.Instantiate(prefab);
    }
}
