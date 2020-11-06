using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName="MacDesktop-104key-enterflat",
menuName="TypeMan/Keyboard/MacDesktop")]
public class MacDesktop : KeyboardLayout
{
    private void Awake()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        defaultKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","delete",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","return",
            "shift","z","x","c","v","b","n","m",",",".","/"," shift",
            "control","option","command","space"," command"," option"," control"
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
        {"delete","\\","return"," shift"," control"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        UpdateKey("delete", 2.2f);
        UpdateKey("tab", 1.6f);
        UpdateKey("\\", 1.6f);
        UpdateKey("caps lock", 1.8f);
        UpdateKey("return", 2.45f);
        UpdateKey("shift", 2.5f);
        UpdateKey(" shift", 2.9f);
        UpdateKey("control", 1.5f);
        UpdateKey("option", 1.4f);
        UpdateKey("command", 1.6f);
        UpdateKey("space", 7.6f);
        UpdateKey(" command", 1.6f);
        UpdateKey(" option", 1.4f);
        UpdateKey(" control", 1.5f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRange("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRange("tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRange("caps lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRange("shift",endStringInRows[3]);
        FixLastKeyWidthOfThisRange("control",endStringInRows[4]);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(MacDesktop))]
public class MacDesktopEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as MacDesktop;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif
