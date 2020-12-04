using UnityEngine;

public class DirectionBullet : Bullet
{
    public Vector3 direction = Vector3.zero;        //use the vector3 defaults.
	
	public override void Awake2() 
	{
        type = Type.Direction;
	}

    public void Shoot(Vector3 startPosition, Material material, bool friendly, Vector3 direction, float speed)
    {
        hit = false;
        transform.position = startPosition;
        this.material = material;
        tr.material = material;
        mr.material = material;
        this.friendly = friendly;
        this.gameObject.tag = (friendly) ? "PlayerBullet" : "EnemyBullet";
        this.direction = direction;
        this.speed = speed;
        gameObject.SetActive(true);
        StartCoroutine(TimeOut());
    }

    public new void Update()
    {
        if (!hit)
        {
            rb.velocity = direction * speed;
            base.Update();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("collision on bullet");
        if (other.gameObject.name.Contains("Bad"))
        {
            HitSomething();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //print("complicated collision");
    }
}
