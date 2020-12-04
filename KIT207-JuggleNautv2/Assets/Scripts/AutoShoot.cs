using System.Collections;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public Transform bulletSpawn;

    bool shooting = true;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float shootingStartDelay;

    [SerializeField] private Material bulletMaterial;

    public int damage;
    public float knockback;

    public bool friendly;

    public Vector3 direction;

    public float bulletSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        this.InvokeDelay(shootingStartDelay, () =>
        {
            StartCoroutine(ShootingCoroutine());
        });
    }

    IEnumerator ShootingCoroutine()
    {
        while (shooting)
        {
            DirectionBullet bullet = Controller.GetBullet(Bullet.Type.Direction) as DirectionBullet;
            bullet.damage = 1;
            bullet.Shoot(transform.position, bulletMaterial, true, Vector3.right, bulletSpeed);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
