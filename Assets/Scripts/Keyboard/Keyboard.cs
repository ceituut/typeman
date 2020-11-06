using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class Keyboard : MonoBehaviour
{
    // Fields
    [SerializeField] private KeyboardLayout keyboardLayout;
    private List<Key> keyList;

    // Properties
    public List<Key> GetKeyList { get => keyList;}
    public KeyboardLayout GetKeyboardLayout { get => keyboardLayout;}

    // Methods
    private void Start()
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