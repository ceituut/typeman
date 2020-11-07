using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KeyboardDefinition;
#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName="English",
menuName="TypeMan/KeyboardLanguage/New Langugae")]
public class Language : ScriptableObject
{
    public List<string> primaryKeyList;
    public List<string> secondaryKeyList;

    private void Awake() 
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=",
            "q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "a","s","d","f","g","h","j","k","l",";","'",
            "z","x","c","v","b","n","m",",",".","/"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+",
            "Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "A","S","D","F","G","H","J","K","L",":","\"",
            "Z","X","C","V","B","N","M","<",">","?"
        };
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Language))]
public class LanguageEditor : Editor {
    public override void OnInspectorGUI() {
        var script = target as Language;
        EditorGUILayout.BeginVertical();
        EditorGUILayout.Foldout(false , "Primary Keys" , true);
        for(int index = 0 ; index < script.primaryKeyList.Count ; index++)
            script.primaryKeyList[index] = 
            EditorGUILayout.TextField(primaryLiteralKeys[index],script.primaryKeyList[index]);
        EditorGUILayout.EndVertical();
           
        EditorGUILayout.BeginVertical();
        EditorGUILayout.Foldout(false , "Secondary Keys" , true);
        for(int index = 0 ; index < script.primaryKeyList.Count ; index++)
            script.secondaryKeyList[index] = 
            EditorGUILayout.TextField(secondaryLiteralKeys[index],script.secondaryKeyList[index]);
        EditorGUILayout.EndVertical();
    }
}
#endif