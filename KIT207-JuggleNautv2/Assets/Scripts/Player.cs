using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Credit goes to "Jayanam Games" for this script.
   Found here: https://www.patreon.com/posts/unity-3d-drag-22917454. */

public class Player : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Rigidbody rb;

    //Defaults are x=11.2 & y=6
    [SerializeField]
    private float xRange, yRange;

    [SerializeField] HealthBar healthbar;
    [SerializeField] private int health, maxHealth;

    bool dragging = false;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        rb = GetComponent<Rigidbody>();
        rb.position = transform.position;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit();
        }

        if (dragging)
        {
            //rb.position = GetMouseAsWorldPoint() + mOffset;

            //rb.position = new Vector3(
            //    Mathf.Clamp(rb.position.x, -xRange, xRange),
            //    Mathf.Clamp(rb.position.y, -yRange, yRange),
            //    rb.position.z);

            transform.position = GetMouseAsWorldPoint() + mOffset;

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -xRange, xRange),
                Mathf.Clamp(transform.position.y, -yRange, yRange),
                transform.position.z);
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    /*void OnMouseDrag()
    {
        //rb.position = GetMouseAsWorldPoint() + mOffset;

        //rb.position = new Vector3(
        //    Mathf.Clamp(rb.position.x, -xRange, xRange),
        //    Mathf.Clamp(rb.position.y, -yRange, yRange),
        //    rb.position.z);

        transform.position = GetMouseAsWorldPoint() + mOffset;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xRange, xRange),
            Mathf.Clamp(transform.position.y, -yRange, yRange),
            transform.position.z);
    }*/

    private void Hit()
    {
        // Subtract health
        health -= 15;

        // Tell health bar new health value.
        healthbar.SetHealth(health);

        // Camera effects.
        LeanTween.value(gameObject, (float i) => {
            CameraEffectsController.SetEffect(CameraEffectsController.Effect.ColorDrift, i);
            CameraEffectsController.SetEffect(CameraEffectsController.Effect.ScanLineJitter, i);
        }, 0.3f, 0f, 1f);

        LeanTween.value(gameObject, (float i) => {
            CameraEffectsController.SetEffect(CameraEffectsController.Effect.DigitalGlitch, i);
        }, 0.025f, 0f, 0.5f);
    }
}
