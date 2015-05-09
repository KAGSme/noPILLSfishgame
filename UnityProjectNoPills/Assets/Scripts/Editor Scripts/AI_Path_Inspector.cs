using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(AI_Path))]
public class AI_Path_Inspector : Editor {

    private ReorderableList list;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    void OnEnable()
    {
        list = new ReorderableList(serializedObject, 
            serializedObject.FindProperty("waypoints"), true, true, true, true);

       /* list.drawElementCallback =
        (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Transform"), GUIContent.none);
        };*/
    }
    
}
