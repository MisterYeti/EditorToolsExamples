using UnityEngine;
using UnityEditor;
public class ExampleWindow : EditorWindow
{

    private Color _color;

    [MenuItem("Brackeys/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Color the selected objects", EditorStyles.boldLabel);

        _color = EditorGUILayout.ColorField("Color", _color);

        if (GUILayout.Button("COLORIZE !"))
        {
            Colorize();
        }
    }

    private void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Debug.Log(obj);
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = _color;
            }
        }
    }
}
