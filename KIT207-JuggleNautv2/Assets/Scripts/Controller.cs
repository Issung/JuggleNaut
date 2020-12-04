using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefabDrag;
    private static Controller controller;
    private static GameObject bulletPrefab;
    //private static Queue<Bullet> bullets;
    private static List<Bullet> bulletPool;
    private static float dtf;
    
    public int fpsTarget;
    public float timeScale = 1;

    void Awake () 
	{
        //bullets = new Queue<Bullet>();
        bulletPool = new List<Bullet>();
        bulletPrefab = bulletPrefabDrag;
        controller = this;
    }

    public static void QueueBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        controller.InvokeDelay(0.1f, () => { bulletPool.Add(bullet); });
    }

    private void Update()
    {
        Application.targetFrameRate = fpsTarget;
        Time.timeScale = timeScale;

        dtf = 60f / (1.0f / Time.deltaTime);
    }

    public static float GetDtf()
    {
        return dtf;
    }

    /// <summary>
    /// Needs work, needs to dequeue the needed type of bullet, Queue might need to be turned into a list.
    /// </summary>
    public static Bullet GetBullet(Bullet.Type type)
    {
        List<Bullet> bulletsOfType = bulletPool.Where(t => t.type == type).ToList();

        if (bulletsOfType.Count < 1)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            if (type == Bullet.Type.Direction)
                bullet.AddComponent(typeof(DirectionBullet));

            return bullet.GetComponent<Bullet>();
        }
        else
        {
            Bullet bullet = bulletsOfType[0];
            bulletPool.Remove(bullet);
            return bullet;
        }
    }
}
