using UnityEngine;

public class Enemy : MonoBehaviour //use this as a inheritance base class for other enemies?
{
    [SerializeField] private int health;

    Rigidbody rb;

	void Awake () 
	{
        rb = GetComponent<Rigidbody>();
	}

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            TakeDamage(bullet.damage);
            bullet.HitSomething();

            rb.AddForce(bullet.lastFrameDirection * bullet.knockback);
        }
    }
}
