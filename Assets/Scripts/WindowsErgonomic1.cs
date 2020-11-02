using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="WinErgonomic1-104key-enterflat",
menuName="TypeMan/Keyboard/WinErgonomic1")]
public class WindowsErgonomic1 : WindowsDesktop
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
            "Ctrl","Win","Alt","Space","AltGr","Menu"," Ctrl"
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
        UpdateKey("t", 1.8f);
        UpdateKey("g", 1.6f);
        UpdateKey("7", 1.7f);
        UpdateKey("h", 1.4f);
        UpdateKey("n", 2.1f);
        UpdateKey("Backspace", 2.2f);
        UpdateKey("Tab", 1.6f);
        UpdateKey("\\", 1.6f);
        UpdateKey("Caps Lock", 1.9f);
        UpdateKey("Enter", 2.35f);
        UpdateKey("Shift", 2.5f);
        UpdateKey(" Shift", 2.9f);
        UpdateKey("Ctrl", 1.5f);
        UpdateKey("Win", 2f);
        UpdateKey("Alt", 1.7f);
        UpdateKey("Space", 7.5f);
        UpdateKey("AltGr", 2.1f);
        UpdateKey("Menu", 2.3f);
        UpdateKey(" Ctrl", 2.2f);
    }
    public override void AdjustRows()
    {
        // Do nothing
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(WindowsErgonomic1))]
public class WindowsErgonomic1Editor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsErgonomic1;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif