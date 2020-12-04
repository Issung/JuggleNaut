//from: https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        string valueStr;

        switch (prop.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            /*case SerializedPropertyType.ObjectReference:
                valueStr = prop.objectReferenceValue?.name ?? "(none)";
                break;*/
            default:
                valueStr = "(not supported)";
                break;
        }

        if (prop.propertyType == SerializedPropertyType.Vector2)
        {
            GUI.enabled = false;
            EditorGUI.Vector2Field(position, label.text, prop.vector2Value);
            GUI.enabled = true;
        }
        else if (prop.propertyType == SerializedPropertyType.Quaternion)
        {
            GUI.enabled = false;
            EditorGUI.Vector4Field(position, label.text, new Vector4(prop.quaternionValue.x, prop.quaternionValue.y, prop.quaternionValue.z, prop.quaternionValue.w));
            GUI.enabled = true;
        }
        else if (prop.propertyType == SerializedPropertyType.ObjectReference)
        {
            GUI.enabled = false;
            EditorGUI.ObjectField(position, prop);
            GUI.enabled = true;
        }
        else
        {
            EditorGUI.LabelField(position, label.text, valueStr);
        }
    }
}