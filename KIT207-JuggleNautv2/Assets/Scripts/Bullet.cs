using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum Type { Direction, Homing }

    public Type type;
    public bool friendly = false;
    public float speed = 1f;
    public Material material;

    public int damage = 0;           // Amount of damage this bullet will do to the object that gets hit(?)
    public float knockback = 0f;        // Amount of knockback to give on object that gets hit(?)

    protected MeshRenderer mr;
    protected TrailRenderer tr;
    protected Rigidbody rb;

    public Vector3 lastFramePosition = Vector3.zero;
    public Vector3 lastFrameDirection = Vector3.zero;

    protected bool hit = false;

    Coroutine poolCoroutine = null;

    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody>();
        Awake2();
    }

    public virtual void Awake2()
    {
        // override this in an extending class.
    }

    public void Update()
    {
        // Disable and queue bullets if they shoot off the right hand side of the screen
        if (transform.position.x > 14)
        {
            StopAndQueueBullet();
        }

        lastFrameDirection = transform.position - lastFramePosition;
        lastFramePosition = this.transform.position;
    }

    public void SetVisible(bool visible)
    {
        mr.enabled = visible;
    }

    public void HitSomething()
    {
        StopAndQueueBullet();
    }

    private void StopAndQueueBullet()
    {
        hit = true;
        speed = 0;
        rb.velocity = Vector3.zero;
        poolCoroutine = this.InvokeDelay(0.1f, () =>
        {
            Controller.QueueBullet(this);
        });
    }

    protected IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(speed * 0.25f + 2);
        Controller.QueueBullet(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("OnTriggerEnter -bullet");

        //StopAndQueueBullet();
    }
}
