using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(CostumeBuilder))]
[CanEditMultipleObjects]
public class CostumeBuilderEditor : Editor
{
    SerializedProperty clothesSpriteProp, skinSpriteProp, hairSpriteProp;
    SerializedProperty previewDirectionProp;
    SerializedProperty genderProp, hairColourProp, skinColourProp, clothingProp;
    public void OnEnable()
    {
        clothesSpriteProp = serializedObject.FindProperty("clothesSprite");
        skinSpriteProp = serializedObject.FindProperty("skinSprite");
        hairSpriteProp = serializedObject.FindProperty("hairSprite");

        previewDirectionProp = serializedObject.FindProperty("previewDirection");

        genderProp = serializedObject.FindProperty("gender");
        hairColourProp = serializedObject.FindProperty("hairColour");
        skinColourProp = serializedObject.FindProperty("skinColour");
        clothingProp = serializedObject.FindProperty("clothing");
    }

    public override void OnInspectorGUI()
    {
        // always do this here
        serializedObject.Update();

        // the property fields
        EditorGUILayout.PropertyField(clothesSpriteProp);
        EditorGUILayout.PropertyField(skinSpriteProp);
        EditorGUILayout.PropertyField(hairSpriteProp);

        EditorGUILayout.PropertyField(previewDirectionProp);

        EditorGUILayout.PropertyField(genderProp);
        EditorGUILayout.PropertyField(hairColourProp);
        EditorGUILayout.PropertyField(skinColourProp);
        EditorGUILayout.PropertyField(clothingProp);

        // apply the changes
        serializedObject.ApplyModifiedProperties();
        Object[] builders = serializedObject.targetObjects;
        foreach (Object builder in builders)
        {
            ((CostumeBuilder)builder).EditorUpdate();
        }
    }
}
