using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName="WinPortable2-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsPortable2")]
public class WindowsPortable2 : WindowsDesktop
{
    private void Awake() {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        defaultKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/"," Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
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
        UpdateKey(" Shift", 2.9f);
        UpdateKey("Ctrl", 1.6f);
        UpdateKey("Fn", 1f);
        UpdateKey("Win", 1f);
        UpdateKey("Alt", 1.3f);
        UpdateKey("Space", 5.6f);
        UpdateKey("AltGr", 1.1f);
        UpdateKey(" Ctrl", 1f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRange("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRange("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRange("Caps Lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRange("Shift",endStringInRows[3]);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(WindowsPortable2))]
public class WindowsPortable2Editor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsPortable2;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif