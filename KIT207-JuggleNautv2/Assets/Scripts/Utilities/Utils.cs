using UnityEngine;

public static class Utils
{
    public static Rect ScreenRectInWorldCoords()
    {
        // get coordinates of top-left and bottom-right of the screen (in world space, i.e. same coordinate system as GameObjects)
        Vector2 topLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector2 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    public static int Chance(int chance) => Random.Range(0, chance + 1);
    public static float Chance(float chance) => Random.Range(0f, chance + 1f);

    /// <summary>
    /// A 50% chance of returning true, otherwise returns false.
    /// </summary>
    public static bool EvenChance() => Chance(1) == 0;


    /// <summary>
    /// A 50% chance of returning "a", otherwise returns "b".
    /// </summary>
    public static int EvenChance(int a, int b) => EvenChance() ? a : b;

    /// <summary>
    /// A 50% chance of returning 0, otherwise returns 1.
    /// </summary>
    public static int EvenChanceI() => EvenChance(0, 1);

    /// <summary>
    /// A 50% chance of returning 1, otherwise returns -1.
    /// </summary>
    public static int EvenChanceI1() => EvenChance(1, -1);


    /// <summary>
    /// A 50% chance of returning "a", otherwise returns "b".
    /// </summary>
    public static float EvenChance(float a, float b) => EvenChance() ? a : b;

    /// <summary>
    /// A 50% chance of returning 0.0f, otherwise returns 1.0f.
    /// </summary>
    public static float EvenChanceF() => EvenChance(0f, 1f);

    /// <summary>
    /// A 50% chance of returning 1.0f, otherwise returns -1.0f.
    /// </summary>
    public static float EvenChanceF1() => EvenChance(1f, -1f);
}