using UnityEngine;

public static class BoundsExtensions
{
    /// <summary>
    /// Gets the width. Shorthand for "bounds.extents.x".
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetWidth(this Bounds bounds) => bounds.extents.x;

    /// <summary>
    /// Gets the width. Shorthand for "bounds.extents.y".
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetHeight(this Bounds bounds) => bounds.extents.y;

    /// <summary>
    /// Gets the upper bound.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetUpper(this Bounds bounds) => bounds.center.y + bounds.extents.y;

    /// <summary>
    /// Gets the upper bound using the specified transform's y position.
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float GetUpper(this Bounds bounds, Transform t) => t.position.y + bounds.extents.y;

    /// <summary>
    /// Gets the lower bound.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetLower(this Bounds bounds) => bounds.center.y - bounds.extents.y;

    /// <summary>
    /// Gets the lower bound using the specified transform's y position.
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float GetLower(this Bounds bounds, Transform t) => t.position.y - bounds.extents.y;

    /// <summary>
    /// Gets the left bound.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetLeft(this Bounds bounds) => bounds.center.x - bounds.extents.y;

    /// <summary>
    /// Gets the left bound using the specified transform's x position.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetLeft(this Bounds bounds, Transform t) => t.position.x - bounds.extents.y;

    /// <summary>
    /// Gets the right bound.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetRight(this Bounds bounds) => bounds.center.x + bounds.extents.y;

    /// <summary>
    /// Gets the right bound using the specified transform's x position.
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public static float GetRight(this Bounds bounds, Transform t) => t.position.x + bounds.extents.y;
}