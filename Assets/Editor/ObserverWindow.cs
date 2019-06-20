using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObserverWindow : EditorWindow
{
    private Vector3 _location = Vector3.zero;

    [MenuItem("Tools/Observer")]
    public static void CreateObserver()
    {
        EditorWindow.GetWindow<ObserverWindow>();
    }

    public void OnGUI()
    {
        EditorGUILayout.Vector3Field("Location", _location);
        if (GUILayout.Button("Commit"))
        {
            Debug.Log("OK");
        }
    }


}
