using UnityEngine;
using UnityEditor;
using System.Collections;

/*[CustomEditor(typeof(TriggerSpeech))]
public class TriggerSpeechEditor : Editor
{
    public SerializedProperty textProp;
    public SerializedProperty destroyOnDoneProp;
    public SerializedProperty playerTagProp;
    public SerializedProperty randomizedTextsProp;

    void OnEnable()
    {
        textProp = serializedObject.FindProperty("text");
        destroyOnDoneProp = serializedObject.FindProperty("destroyOnDone");
        playerTagProp = serializedObject.FindProperty("playerTag");
        randomizedTextsProp = serializedObject.FindProperty("randomizeTexts");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(destroyOnDoneProp);
        EditorGUILayout.PropertyField(playerTagProp);
        EditorGUILayout.PropertyField(randomizedTextsProp);
        GUILayout.Label("Speech Text (grouped by \\n\\n)");
        textProp.stringValue = EditorGUILayout.TextArea(textProp.stringValue, GUILayout.MaxHeight(150));

        serializedObject.ApplyModifiedProperties();
    }
}
*/