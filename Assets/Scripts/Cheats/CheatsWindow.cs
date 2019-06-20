using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheatsWindow : EditorWindow
{  
    [MenuItem("My Game/Cheats")]
    public static void ShowWindow()
    {
        GetWindow<CheatsWindow>(false, "Cheats", true);
    }

    private void OnGUI()
    {
        Cheats.MuteAllSound = EditorGUILayout.Toggle("Mute All Sounds", Cheats.MuteAllSound);
        Cheats.PlayerLifes = EditorGUILayout.IntField("Player Lifes", Cheats.PlayerLifes);
        Cheats.PlayerTwoName = EditorGUILayout.TextField("Player Two Name", Cheats.PlayerTwoName);

        GUILayout.FlexibleSpace();
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUI.backgroundColor = Color.red;

        if (GUILayout.Button("Reset",GUILayout.Width(100),GUILayout.Height(30)))
        {
            Cheats.MuteAllSound = false;
            Cheats.PlayerLifes = 3;
            Cheats.PlayerTwoName = "John";
        }
        EditorGUILayout.EndHorizontal();
    }

}
