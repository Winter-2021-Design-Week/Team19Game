using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CashItem))]
public class ItemSOUpdater : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CashItem targetItem = (CashItem)target;
        serializedObject.Update();
        SerializedProperty CashItemType = serializedObject.FindProperty("profile");

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(CashItemType);

        if (EditorGUI.EndChangeCheck())
        {
            // Code to execute if GUI.changed
            serializedObject.ApplyModifiedProperties();
            foreach (CashItem target in targets)
            {
                ((CashItem)target).profile = targetItem.profile;
                ((CashItem)target).UpdateFromProfile();
            }
        }
    }
}
