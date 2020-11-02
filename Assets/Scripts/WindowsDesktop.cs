using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="WinDesktop-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsDesktop")]
public class WindowsDesktop : KeyboardLayout
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
            "Ctrl","Win","Alt","Space","AltGr"," Win","Menu"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
        changer = new WindowsDesktopChanger();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"Backspace","\\","Enter"," Shift"," Ctrl"};
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
        UpdateKey("Ctrl", 1.5f);
        UpdateKey("Win", 0.9f);
        UpdateKey("Alt", 1.4f);
        UpdateKey("Space", 7.5f);
        UpdateKey("AltGr", 1.4f);
        UpdateKey(" Win", .9f);
        UpdateKey("Menu", 1f);
        UpdateKey(" Ctrl", 1.5f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRange("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRange("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRange("Caps Lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRange("Shift",endStringInRows[3]);
        FixLastKeyWidthOfThisRange("Ctrl",endStringInRows[4]);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(WindowsDesktop))]
public class WindowsDesktopEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as WindowsDesktop;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif
