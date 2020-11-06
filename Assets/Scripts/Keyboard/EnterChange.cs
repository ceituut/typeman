using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class EnterChange : MonoBehaviour
{
    // Fields
    private Keyboard keyboard;
    [SerializeField] private Key UpperHiddenKey;
    [SerializeField] private Key LowerHiddenKey;
    [SerializeField] private Key Enter;
    [SerializeField] private Key Backslash;
    [SerializeField] private Key Backspace;

    // Methods
    private void Start()
    {
        keyboard = gameObject.GetComponent<Keyboard>();
    }
    public void ChangeEnter(EnterTypes enterType)
    {
        switch(enterType)
        {
            case EnterTypes.flat :
                MakeEnterFlat();
                break;
            case EnterTypes.high :
                MakeEnterHigh();
                break;
            case EnterTypes.big :
                MakeEnterBig();
                break;
        }
    }
    public void MakeEnterFlat()
    {
        keyboard.ChangeKeyWidthByRef(Enter , 0);
        keyboard.ChangeKeyWidthByRef(Backspace , 0);
        Backslash.SetHeightScale(1f);
        Enter.SetHeightScale(1f);
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(false);
    }
    public void MakeEnterHigh()
    {
        keyboard.ChangeKeyWidthByRef(Enter , -1.2f);
        keyboard.ChangeKeyWidthByRef(Backspace , 0);
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(true);
        Backslash.SetHeightScale(1f);
        Enter.SetHeightScale(1.4f);
        Backslash.KeyPrimaryValue = "  ";
        Backslash.KeySecondaryValue = "  ";
        Backslash.TextComponent.text = "  ";
    }
    public void MakeEnterBig()
    {
        keyboard.ChangeKeyWidthByRef(Enter , 0);
        keyboard.ChangeKeyWidthByRef(Backspace , -1.2f);
        UpperHiddenKey.gameObject.SetActive(true);
        LowerHiddenKey.gameObject.SetActive(false);
        Backslash.SetHeightScale(1.4f);
        Enter.SetHeightScale(1f);
        Backslash.KeyPrimaryValue = "  ";
        Backslash.KeySecondaryValue = "  ";
        Backslash.TextComponent.text = "  ";
    }
}