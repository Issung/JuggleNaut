using Kino;
using System.Collections;
using UnityEngine;

//[ExecuteInEditMode]
public class CameraEffectsController : MonoBehaviour
{
    private static GameObject go;
    private static CameraEffectsController selfInstance;

    private static AnalogGlitch analogGlitch;
    private static DigitalGlitch digitalGlitch;


    private Vector3 lastFramePosition;

    public enum Effect { ScanLineJitter, VerticalJump, HorizontalShake, ColorDrift, DigitalGlitch }

    void Awake()
    {
        go = gameObject;
        selfInstance = this;

        analogGlitch = GetComponent<AnalogGlitch>();
        digitalGlitch = GetComponent<DigitalGlitch>();
    }

    public static GameObject GetCameraGameObject()
    {
        return go;
    }

    public static Vector3 GetCameraLocalPosition()
    {
        return go.transform.localPosition;
    }

    public static Vector3 GetCameraPosition()
    {
        return go.transform.position;
    }

    /*public static void CameraShake(float intensity, float time)
    {
        if (shakeCoroutine != null)
            selfInstance.StopCoroutine(shakeCoroutine);
        shakeCoroutine = selfInstance.StartCoroutine(selfInstance.Shake(intensity, time));
    }*/

    public static void SetEffect(Effect glitch, float value)
    {
        if (glitch == Effect.ScanLineJitter)
            analogGlitch.scanLineJitter = value;
        else if (glitch == Effect.VerticalJump)
            analogGlitch.verticalJump = value;
        else if (glitch == Effect.HorizontalShake)
            analogGlitch.horizontalShake = value;
        else if (glitch == Effect.ColorDrift)
            analogGlitch.colorDrift = value;
        else if (glitch == Effect.DigitalGlitch)
            digitalGlitch.intensity = value;
    }

    /*public static bool shaking;
    public static Coroutine shakeCoroutine;
    public static float shakeTimer;
    IEnumerator Shake(float intensity, float time)
    {
        shaking = true;
        shakeTimer = 0f;
        while (shakeTimer < time)
        {
            float m = (time - shakeTimer) * (1f / time);    // this will go from 1 at the start to 0 at the end, making the shaking reduce to 0 over time
            transform.position = new Vector3(transform.position.x + Random.Range(-intensity, intensity) * m, transform.position.y + Random.Range(-intensity, intensity) * m, transform.position.z);
            shakeTimer += Time.deltaTime;
            yield return null;
        }

        shaking = false;
        yield return null;
    }*/
}
