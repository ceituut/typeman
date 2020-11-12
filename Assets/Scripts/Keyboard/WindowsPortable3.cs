using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="WinPortable3-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsPortable3")]
public class WindowsPortable3 : WindowsPortable1
{
    private void Awake() {
        InitializeDefualt();
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        UpdateKey("Backspace", 2.2f);
        UpdateKey("Tab", 1.6f);
        UpdateKey("\\", 1.6f);
        UpdateKey("Caps Lock", 1.9f);
        UpdateKey("Enter", 2.35f);
        UpdateKey("Shift", 2.5f);
        UpdateKey(" Shift", 1.7f);
        UpdateKey("Ctrl", 1.5f);
        UpdateKey("Win", 1f);
        UpdateKey("Fn", 1f);
        UpdateKey("Alt", 1f);
        UpdateKey(" ", 5.8f);
        UpdateKey("AltGr", 1f);
        UpdateKey("Prnt Scr", 1f);
        UpdateKey(" Ctrl", 1.8f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRange("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRange("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRange("Caps Lock",endStringInRows[2]);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(WindowsPortable3))]
public class WindowsPortable3Editor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsPortable3;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif