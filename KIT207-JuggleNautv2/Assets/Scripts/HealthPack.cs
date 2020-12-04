using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int minHelth = 1;
    public int maxHelth = 10;

    private int m_health;
    private float m_yRotation, m_yPosition;
    
    /*[ShowOnly]*/ public float moveHeight = 1f;
    /*[ShowOnly]*/ public float speed = 3f;
    [SerializeField][ShowOnly] private float m_yPositionStart;

    private void Start()
    {
        m_health = Random.Range(minHelth, maxHelth);
        m_yPositionStart = transform.GetY() + moveHeight / 2f;
    }

    private void FixedUpdate()
    {
        m_yPosition = m_yPositionStart + (Mathf.Sin(Time.time * speed) * moveHeight) / 2f;
        transform.SetY(m_yPosition);

        m_yRotation += 1f; // DIRTY!
        transform.SetYRotation(m_yRotation);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            HealthBar health = other.GetComponent<HealthBar>();

            if (health)
            {
                health.SetHealth(health.GetHealth() + m_health);
                Destroy(gameObject);
            }
        }*/
    }
}