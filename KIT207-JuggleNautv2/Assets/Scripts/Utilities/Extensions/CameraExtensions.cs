using UnityEngine;

public static class CameraExtensions
{
    /// <summary>
    /// Gets the half-height of the camera.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    private static float GetHeight(Camera camera) => camera.orthographicSize;

    /// <summary>
    /// Gets the half-width of the camera.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static float GetWidth(this Camera camera) => GetHeight(camera) * camera.aspect;

    /// <summary>
    /// Gets the height of the camera.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static float GetFullHeight(this Camera camera) => camera.orthographicSize * 2;

    /// <summary>
    /// Gets the width of the camera.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static float GetFullWidth(this Camera camera) => GetWidth(camera) * 2;

    /// <summary>
    /// Gets the camera's top-left vector.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector2 GetBoundTopLeft(this Camera camera) => new Vector2(-GetWidth(camera), GetHeight(camera));

    /// <summary>
    /// Gets the camera's top-right vector.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector2 GetBoundTopRight(this Camera camera) => new Vector2(GetWidth(camera), GetHeight(camera));

    /// <summary>
    /// Gets the camera's bottom-left vector.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector2 GetBoundBottomLeft(this Camera camera) => new Vector2(-GetWidth(camera), -GetHeight(camera));

    /// <summary>
    /// Gets the camera's bottom-right vector.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector2 GetBoundBottomRight(this Camera camera) => new Vector2(GetWidth(camera), -GetHeight(camera));
}