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
    private EnterTypes currentType;
    [SerializeField] private Key UpperHiddenKey;
    [SerializeField] private Key LowerHiddenKey;
    [SerializeField] private Key Enter;
    [SerializeField] private Key Backslash;
    [SerializeField] private Key Backspace;

    // Properties
    public EnterTypes GetCurrentType { get => currentType;}

    // Methods
    private void Awake()
    {
        keyboard = gameObject.GetComponent<Keyboard>();
    }
    public void ChangeEnter(EnterTypes enterType)
    {
        currentType = enterType;
        switch(currentType)
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
    private void MakeEnterFlat()
    {
        keyboard.ChangeKeyWidthByRef(Enter , 0);
        keyboard.ChangeKeyWidthByRef(Backspace , 0);
        Backslash.SetHeightScale(1f);
        Enter.SetHeightScale(1f);
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(false);
        keyboard.GetLanguageUpdator.UpdateSingleKey(Backslash.indexInRefLayout);     
    }
    private void MakeEnterHigh()
    {
        keyboard.ChangeKeyWidthByRef(Enter , -1.2f);
        keyboard.ChangeKeyWidthByRef(Backspace , 0);
        Backslash.SetHeightScale(1f);
        Enter.SetHeightScale(1.4f);
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(true);
        keyboard.GetLanguageUpdator.UpdateSingleKey(Backslash.indexInRefLayout);     
        LowerHiddenKey.CloneKey(Backslash);
        Backslash.MakeEmpty();
    }
    private void MakeEnterBig()
    {
        keyboard.ChangeKeyWidthByRef(Enter , 0);
        keyboard.ChangeKeyWidthByRef(Backspace , -1.2f);
        Backslash.SetHeightScale(1.4f);
        Enter.SetHeightScale(1f);
        UpperHiddenKey.gameObject.SetActive(true);
        LowerHiddenKey.gameObject.SetActive(false);
        keyboard.GetLanguageUpdator.UpdateSingleKey(Backslash.indexInRefLayout);     
        UpperHiddenKey.CloneKey(Backslash);
        Backslash.MakeEmpty();
    }
}