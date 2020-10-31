using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinPocket1-104key-enterflat",
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
        SetWidthForSpecificKey("`", 0.8f);
        SetWidthForSpecificKey("Backspace", 2.4f);
        SetWidthForSpecificKey("Tab", 1.3f);
        SetWidthForSpecificKey("\\", 2f);
        SetWidthForSpecificKey("Caps Lock", 1.7f);
        SetWidthForSpecificKey("Enter", 2.9f);
        SetWidthForSpecificKey("Shift", 2.4f);
        SetWidthForSpecificKey(",", 0.8f);
        SetWidthForSpecificKey(".", 0.8f);
        SetWidthForSpecificKey("/", 0.8f);
        SetWidthForSpecificKey(" Shift", 2.1f);
        SetWidthForSpecificKey("Ctrl", 1.3f);
        SetWidthForSpecificKey("Fn", 1f);
        SetWidthForSpecificKey("Win", 1f);
        SetWidthForSpecificKey("Alt", 1.3f);
        SetWidthForSpecificKey("Space", 5.1f);
        SetWidthForSpecificKey("AltGr", 1.1f);
        SetWidthForSpecificKey("Prnt Scr", 1f);
        SetWidthForSpecificKey(" Ctrl", 1.8f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRow("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRow("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRow("Caps Lock",endStringInRows[2]);
    }
}
