using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 SetX(this Vector3 vec, float x) => new Vector3(x, vec.y, vec.z);
    public static Vector3 SetY(this Vector3 vec, float y) => new Vector3(vec.x, y, vec.z);
    public static Vector3 SetZ(this Vector3 vec, float z) => new Vector3(vec.x, vec.y, z);

    // :(
    //public static void SetX(this Vector3 vec, float x) => vec.Set(x, vec.y, vec.z);
    //public static void SetY(this Vector3 vec, float y) => vec.Set(vec.x, y, vec.z);
    //public static void SetZ(this Vector3 vec, float z) => vec.Set(vec.x, vec.y, z);
}