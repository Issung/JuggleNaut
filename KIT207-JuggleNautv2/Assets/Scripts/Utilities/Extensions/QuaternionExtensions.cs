using UnityEngine;

public static class QuaternionExtensions
{
    public static Quaternion SetX(this Quaternion quaternion, float x) => Quaternion.Euler(x, quaternion.y, quaternion.z);
    public static Quaternion SetY(this Quaternion quaternion, float y) => Quaternion.Euler(quaternion.x, y, quaternion.z);
    public static Quaternion SetZ(this Quaternion quaternion, float z) => Quaternion.Euler(quaternion.x, quaternion.y, z);
}