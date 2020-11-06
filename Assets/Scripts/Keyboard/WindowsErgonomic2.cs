using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="WinErgonomic2-104key-enterflat",
menuName="TypeMan/Keyboard/WinErgonomic2")]
public class WindowsErgonomic2 : WindowsDesktop
{
    private void Awake() {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        defaultKeyList = new List<string>
        {
            "Backspace","1","2","3","4","5","6","7","8","9","0","-","=",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]",
            "Caps Lock","`","a","s","d","f","g","h","j","k","l",";","'","\\",
            "Shift","z","x","c","v","b","n","m",",",".","/"," Shift",
            "Ctrl","Alt"," Backspace","Delete","Enter","Space","AltGr"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
        AdjustRows();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"=","]","\\"," Shift"," Ctrl"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        UpdateKey("Backspace", 2.2f);
        UpdateKey("Tab", 2.2f);
        UpdateKey("\\", 1f);
        UpdateKey("Caps Lock", 1f);
        UpdateKey("Enter", 1.7f);
        UpdateKey(" Backspace", 1.7f);
        UpdateKey("Delete", 1.7f);
        UpdateKey("Shift", 2.2f);
        UpdateKey(" Shift", 2.2f);
        UpdateKey("Ctrl", 2.2f);
        UpdateKey("Alt", 1.6f);
        UpdateKey("Space", 1.7f);
        UpdateKey("AltGr", 1.6f);
        UpdateKey(" Ctrl", 2.2f);
    }
    public override void AdjustRows()
    {
        // Do nothing
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(WindowsErgonomic2))]
public class WindowsErgonomic2Editor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsErgonomic2;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif