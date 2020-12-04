using UnityEngine;

public static class TransformExtensions
{
    public static Vector3 GetPosition(this Transform transform, Space space) =>
        space == Space.World ? transform.position : transform.localPosition;

    public static void SetPosition(this Transform transform, Vector3 position, Space space)
    {
        switch (space)
        {
            case Space.World:
                transform.position = position;
                break;
            case Space.Self:
                transform.localPosition = position;
                break;
            default:
                break;
        }
    }

    #region Position getters and setters.
    public static float GetX(this Transform transform, Space space) => GetPosition(transform, space).x;
    public static float GetY(this Transform transform, Space space) => GetPosition(transform, space).y;
    public static float GetZ(this Transform transform, Space space) => GetPosition(transform, space).z;

    public static void SetX(this Transform transform, float x, Space space)
    {
        switch (space)
        {
            case Space.World:
                transform.position = transform.position.SetX(x);
                break;
            case Space.Self:
                transform.localPosition = transform.localPosition.SetX(x);
                break;
            default:
                break;
        }
    }

    public static void SetY(this Transform transform, float z, Space space)
    {
        switch (space)
        {
            case Space.World:
                transform.position = transform.position.SetY(z);
                break;
            case Space.Self:
                transform.localPosition = transform.localPosition.SetY(z);
                break;
            default:
                break;
        }
    }

    public static void SetZ(this Transform transform, float z, Space space)
    {
        switch (space)
        {
            case Space.World:
                transform.position = transform.position.SetZ(z);
                break;
            case Space.Self:
                transform.localPosition = transform.localPosition.SetZ(z);
                break;
            default:
                break;
        }
    }
    #endregion

    #region World position getters and setters.
    public static float GetX(this Transform transform) => transform.position.x;
    public static float GetY(this Transform transform) => transform.position.y;
    public static float GetZ(this Transform transform) => transform.position.z;

    public static void SetX(this Transform transform, float x) => transform.position = transform.position.SetX(x);
    public static void SetY(this Transform transform, float y) => transform.position = transform.position.SetY(y);
    public static void SetZ(this Transform transform, float z) => transform.position = transform.position.SetZ(z);
    #endregion

    #region Local position getters and setters.
    public static float GetLocalX(this Transform transform) => transform.localPosition.x;
    public static float GetLocalY(this Transform transform) => transform.localPosition.y;
    public static float GetLocalZ(this Transform transform) => transform.localPosition.z;

    public static void SetLocalX(this Transform transform, float x) => transform.localPosition = transform.localPosition.SetX(x);
    public static void SetLocalY(this Transform transform, float y) => transform.localPosition = transform.localPosition.SetY(y);
    public static void SetLocalZ(this Transform transform, float z) => transform.localPosition = transform.localPosition.SetZ(z);
    #endregion

    #region World rotation getters and setters.
    public static float GetXRotation(this Transform transform) => transform.rotation.x;
    public static float GetYRotation(this Transform transform) => transform.rotation.y;
    public static float GetZRotation(this Transform transform) => transform.rotation.z;

    public static void SetXRotation(this Transform transform, float x) => transform.rotation = transform.rotation.SetX(x);
    public static void SetYRotation(this Transform transform, float y) => transform.rotation = transform.rotation.SetY(y);
    public static void SetZRotation(this Transform transform, float z) => transform.rotation = transform.rotation.SetZ(z);
    #endregion

    #region Local rotation getters and setters.
    public static float GetXLocalRotation(this Transform transform) => transform.localRotation.x;
    public static float GetYLocalRotation(this Transform transform) => transform.localRotation.y;
    public static float GetZLocalRotation(this Transform transform) => transform.localRotation.z;

    public static void SetXLocalRotation(this Transform transform, float x) => transform.localRotation = transform.localRotation.SetX(x);
    public static void SetYLocalRotation(this Transform transform, float y) => transform.localRotation = transform.localRotation.SetY(y);
    public static void SetZLocalRotation(this Transform transform, float z) => transform.localRotation = transform.localRotation.SetZ(z);
    #endregion
}