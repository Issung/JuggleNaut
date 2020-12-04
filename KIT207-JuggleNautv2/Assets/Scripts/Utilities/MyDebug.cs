using UnityEngine;

public static class MyDebug
{
    // Fix this to work in 3D space!
    public static Vector2 AlignWithObject(Vector3 position)
    {
        var pos = Camera.main.WorldToScreenPoint(position);
        return new Vector2(pos.x, Screen.height - pos.y);
    }

    /// <summary>
    /// Draws a label at the centre of the specified position using <see cref="GUI.Box(Rect, string)"/>.
    /// </summary>
    /// <param name="position">The world position.</param>
    /// <param name="content">The content to display.</param>
    public static void GuiBoxObj(Vector3 position, string content)
    {
        var textSize = GUI.skin.box.CalcSize(new GUIContent(content));
        var pos = AlignWithObject(position);
        GUI.Box(new Rect(pos.x - textSize.x / 2f, pos.y - textSize.y / 2f, textSize.x, textSize.y), content);
    }

    public static void GuiBoxObj(Vector3 position, object obj)        => GuiBoxObj(position, obj.ToString());
    public static void GuiBoxObj(Transform transform, string content) => GuiBoxObj(transform.position, content);
    public static void GuiBoxObj(Transform transform, object obj)     => GuiBoxObj(transform.position, obj.ToString());

    public static void GuiAutoBox(Vector3 position, string content) => GUI.Box(new Rect(position, GUI.skin.box.CalcSize(new GUIContent(content))), content);
    public static void GuiAutoBox(float x, float y, string content) => GuiAutoBox(new Vector3(x, y), content);
}