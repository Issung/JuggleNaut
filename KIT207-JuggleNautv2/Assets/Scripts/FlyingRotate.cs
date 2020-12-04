using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRotate : MonoBehaviour
{
    public bool upAndDown, backAndForth;

    public int multiplier;

    Vector3 lastFramePosition = Vector3.zero;

    public int limit = 15;

    public float ease;

    void Update()
    {
        Vector3 positionDifference = lastFramePosition - transform.position;

        float xrot = 0;
        float zrot = 0;

        //We rotate the x axis depending on the y position difference.
        if (upAndDown)
        {
            float xgoal = Mathf.Clamp(positionDifference.y * multiplier, -limit, limit);
            //xrot = transform.rotation.x + ((xgoal - transform.rotation.x) * ease);
            xrot = Mathf.Lerp(transform.rotation.x, xgoal, ease);
        }

        //We rotate on the z axis depending on the x position difference.
        if (backAndForth)
        {
            float zgoal = Mathf.Clamp(positionDifference.x * multiplier, -limit, limit);
            zrot = transform.rotation.z + ((zgoal - transform.rotation.z) * ease);
            zrot = Mathf.Lerp(transform.rotation.z, zgoal, ease);
        }

        transform.rotation = Quaternion.Euler(xrot, 0, zrot);

        lastFramePosition = transform.position;
    }
}
