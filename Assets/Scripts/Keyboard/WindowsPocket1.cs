using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="WinPocket1-104key-enterflat",
menuName="TypeMan/Keyboard/WinPocket1")]
public class WindowsPocket1 : WindowsPortable1
{
    private void Awake() {
        InitializeDefualt();
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        UpdateKey("`", 0.8f);
        UpdateKey("Backspace", 2.4f);
        UpdateKey("Tab", 1.3f);
        UpdateKey("\\", 2f);
        UpdateKey("Caps Lock", 1.7f);
        UpdateKey("Enter", 2.9f);
        UpdateKey("Shift", 2.4f);
        UpdateKey(",", 0.8f);
        UpdateKey(".", 0.8f);
        UpdateKey("/", 0.8f);
        UpdateKey(" Shift", 2.1f);
        UpdateKey("Ctrl", 1.3f);
        UpdateKey("Fn", 1f);
        UpdateKey("Win", 1f);
        UpdateKey("Alt", 1.3f);
        UpdateKey(" ", 5.1f);
        UpdateKey("AltGr", 1.1f);
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
[CustomEditor(typeof(WindowsPocket1))]
public class WindowsPocket1Editor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsPocket1;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif
