using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class Keyboard : MonoBehaviour
{
    // Fields
    private List<Key> keyList;
    private Language keyboardLanguage;
    [SerializeField] private KeyboardLayout keyboardLayout;
    [SerializeField] private KeyboardLanguageChange KeyboardLanguageChanger;

    // Properties
    public List<Key> GetKeyList { get => keyList;}
    public Language KeyboardLanguage { get => keyboardLanguage; set => keyboardLanguage = value; }
    public KeyboardLayout GetKeyboardLayout { get => keyboardLayout;}
    public KeyboardLanguageChange GetKeyboardLanguageChanger { get => KeyboardLanguageChanger;}

    // Methods
    private void Awake()
    {
        keyList = new List<Key>( gameObject.GetComponentsInChildren<Key>() );
        SetReferenceIndexOfKeys();
    }
    private void SetReferenceIndexOfKeys()
    {
        int index = 0;
        foreach( Key key in keyList )
            if( key.gameObject.activeSelf )
            {
                key.indexInRefLayout = index;
                index++;
            }
    }
    public void ChangeKeyWidthByRef(Key targetKey , float amount)
    {
        int indexInRefLayout = targetKey.indexInRefLayout;
        float widthInRefLayout = keyboardLayout.GetKeyWidthList[indexInRefLayout];
        targetKey.SetWidthScale(widthInRefLayout + amount);
    }
}