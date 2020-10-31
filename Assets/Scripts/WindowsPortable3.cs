using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinPortable3-104key-enterflat",
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
        SetWidthForSpecificKey("Backspace", 2.2f);
        SetWidthForSpecificKey("Tab", 1.6f);
        SetWidthForSpecificKey("\\", 1.6f);
        SetWidthForSpecificKey("Caps Lock", 1.9f);
        SetWidthForSpecificKey("Enter", 2.35f);
        SetWidthForSpecificKey("Shift", 2.5f);
        SetWidthForSpecificKey(" Shift", 1.7f);
        SetWidthForSpecificKey("Ctrl", 1.5f);
        SetWidthForSpecificKey("Win", 1f);
        SetWidthForSpecificKey("Fn", 1f);
        SetWidthForSpecificKey("Alt", 1f);
        SetWidthForSpecificKey("Space", 5.8f);
        SetWidthForSpecificKey("AltGr", 1f);
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