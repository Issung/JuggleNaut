using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactTransform;
    public LayerMask layerMask;

    public bool RayHit => HitCount > 0;

    protected Collider2D[] Hits;
    protected int HitCount;
    protected float Distance;

    public bool debug;
    protected Color rayDebugColour;

    protected Collider2D Hit => Hits[0];

    protected virtual void Interact() { }

    private void Start()
    {
        Hits = new Collider2D[10];
        rayDebugColour = Color.green;
    }

    protected virtual void Update()
    {
        HitCount = SendRaycast();

        // Keep calculating the distance from the first hit object if it exists.
        if (Hit)
            Distance = (transform.position - Hit.transform.position).magnitude;

        //if (debug && RayHit)
        //    Debug.DrawLine(interactTransform.position, Hit.gameObject.transform.position, rayDebugColour);

        if (debug)
            for (int i = 0; i < HitCount; i++)
                Debug.DrawLine(interactTransform.position, Hits[i].gameObject.transform.position, rayDebugColour);
    }

    protected virtual int SendRaycast()
    {
        #region Debug
        if (!interactTransform || Hits == null)
            System.Diagnostics.Debugger.Break();
        #endregion

        return Physics2D.OverlapCircleNonAlloc(interactTransform.position, radius, Hits, layerMask.value);
    }

    protected virtual void OnGUI()
    {
        if (debug && RayHit)
            MyDebug.GuiBoxObj(gameObject.transform.position, $"Interactable ({gameObject.name}) hit: {Hit.gameObject.name}");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactTransform.position, radius);
    }
}