using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName="MacPortable-104key-enterflat",
menuName="TypeMan/Keyboard/MacPortable")]
public class MacPortable : MacDesktop
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
            "fn","control","option","command","space"," command"," option"
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
        {"delete","\\","return"," shift"," option"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        UpdateKey("delete", 1.5f);
        UpdateKey("tab", 1.6f);
        UpdateKey("\\", 0.9f);
        UpdateKey("caps lock", 2f);
        UpdateKey("return", 1.8f);
        UpdateKey("shift", 2.6f);
        UpdateKey(" shift", 2.5f);
        UpdateKey("fn", 1f);
        UpdateKey("control", 1f);
        UpdateKey("option", 1f);
        UpdateKey("command", 1.4f);
        UpdateKey("space", 5.8f);
        UpdateKey(" command", 1.4f);
        UpdateKey(" option", 1f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRange("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRange("tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRange("caps lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRange("shift",endStringInRows[3]);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(MacPortable))]
public class MacPortableEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        var script = target as MacPortable;
        for(int index =0 ; index < script.GetDefaultKeyList.Count ; index++)
            script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetDefaultKeyList[index],script.GetKeyWidthList[index]);
    }
}
#endif