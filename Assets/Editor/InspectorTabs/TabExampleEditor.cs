using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TabExample))]
public class TabExampleEditor : Editor
{
    private TabExample _myTarget;
    private SerializedObject soTarget;

    private SerializedProperty stringVar1;
    private SerializedProperty stringVar2;
    private SerializedProperty stringVar3;
    private SerializedProperty stringVar4;
    private SerializedProperty stringVar5;

    private SerializedProperty intVar1;
    private SerializedProperty intVar2;
    private SerializedProperty intVar3;
    private SerializedProperty intVar4;
    private SerializedProperty intVar5;

    private void OnEnable()
    {
        _myTarget = (TabExample)target;
        soTarget = new SerializedObject(target);

        stringVar1 = soTarget.FindProperty("stringVar1");
        stringVar2 = soTarget.FindProperty("stringVar2");
        stringVar3 = soTarget.FindProperty("stringVar3");
        stringVar4 = soTarget.FindProperty("stringVar4");
        stringVar5 = soTarget.FindProperty("stringVar5");

        intVar1 = soTarget.FindProperty("intVar1");
        intVar2 = soTarget.FindProperty("intVar2");
        intVar3 = soTarget.FindProperty("intVar3");
        intVar4 = soTarget.FindProperty("intVar4");
        intVar5 = soTarget.FindProperty("intVar5");
    }

    public override void OnInspectorGUI()
    {
        soTarget.Update();
        //DrawDefaultInspector();

        EditorGUI.BeginChangeCheck();

        _myTarget.toolbarTop = GUILayout.Toolbar(_myTarget.toolbarTop, new string[] { "Strings", "Integer", "Tab3", "Tab4" });
        switch (_myTarget.toolbarTop)
        {
            case 0:
                _myTarget.toolbarBot = 4;
                _myTarget.currentTab = "Strings";
                break;
            case 1:
                _myTarget.toolbarBot = 4;
                _myTarget.currentTab = "Integers";
                break;
            case 2:
                _myTarget.toolbarBot = 4;
                _myTarget.currentTab = "Tab3";
                break;
            case 3:
                _myTarget.toolbarBot = 4;
                _myTarget.currentTab = "Tab4";
                break;
        }

        
        _myTarget.toolbarBot = GUILayout.Toolbar(_myTarget.toolbarBot, new string[] { "Tab5", "Tab6", "Tab7", "Tab8" }); 

        switch (_myTarget.toolbarBot)
        {
            case 0:
                _myTarget.toolbarTop = 4;
                _myTarget.currentTab = "Tab5";
                break;

            case 1:
                _myTarget.toolbarTop = 4;
                _myTarget.currentTab = "Tab6";
                break;

            case 2:
                _myTarget.toolbarTop = 4;
                _myTarget.currentTab = "Tab7";
                break;

            case 3:
                _myTarget.toolbarTop = 4;
                _myTarget.currentTab = "Tab8";
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch (_myTarget.currentTab)
        {
            case "Strings":
                EditorGUILayout.PropertyField(stringVar1);
                EditorGUILayout.PropertyField(stringVar2);
                EditorGUILayout.PropertyField(stringVar3);
                EditorGUILayout.PropertyField(stringVar4);
                EditorGUILayout.PropertyField(stringVar5);
                break;
            case "Integer":
                EditorGUILayout.PropertyField(intVar1);
                EditorGUILayout.PropertyField(intVar2);
                EditorGUILayout.PropertyField(intVar3);
                EditorGUILayout.PropertyField(intVar4);
                EditorGUILayout.PropertyField(intVar5);
                break;
            case "Tab3":
                break;
            case "Tab4":
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }

    }
}