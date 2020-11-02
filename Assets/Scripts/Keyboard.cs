using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class Keyboard : MonoBehaviour
{
    [SerializeField] private KeyboardLayout keyboardLayout;
    [SerializeField] private Key UpperHiddenKey;
    [SerializeField] private Key LowerHiddenKey;
    [SerializeField] private Key LeftHiddenKey;
    [SerializeField] private Key RightHiddenKey;

    public void ChangeKeyboard(StandardTypes standard , EnterTypes enterType)
    {
        ChangeStandard(standard);
        ChangeEnter(enterType);
    }
    private void ChangeStandard(StandardTypes standard)
    {
        switch(standard)
        {
            case StandardTypes.the104key :
                keyboardLayout.GetChanger.MakeIt104Key(LeftHiddenKey,RightHiddenKey);
                break;
            case StandardTypes.the105key :
                keyboardLayout.GetChanger.MakeIt105Key(LeftHiddenKey,RightHiddenKey);
                break;
            case StandardTypes.the107key :
                keyboardLayout.GetChanger.MakeIt107Key(LeftHiddenKey,RightHiddenKey);
                break;
        }
    }
    private void ChangeEnter(EnterTypes enterType)
    {
        switch(enterType)
        {
            case EnterTypes.flat :
                keyboardLayout.GetChanger.MakeEnterFlat(UpperHiddenKey,LowerHiddenKey);
                break;
            case EnterTypes.high :
                keyboardLayout.GetChanger.MakeEnterHigh(UpperHiddenKey,LowerHiddenKey);
                break;
            case EnterTypes.big :
                keyboardLayout.GetChanger.MakeEnterBig(UpperHiddenKey,LowerHiddenKey);
                break;
        }
    }
}