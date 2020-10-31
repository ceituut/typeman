using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;

public class KeyboardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject keyGameObject;

    ////////////////// We should use a list for keyboard layouts
    [SerializeField] private KeyboardLayout keyboard;
    [SerializeField] private StandardTypes standard;
    [SerializeField] private EnterTypes enterType;

    [SerializeField] private List<GameObject> rows;

    private void Start() 
    {
        FormatKeyboard();
        GenerateKeyboard();
        // gameObject.transform.SetSiblingIndex()////////////////////////
    }
    private void GenerateKeyboard()
    {
        keyboard.AdjustRows();
        GenerateRow(rows[0] , 0 , keyboard.GetEndIndexInRows[0]);
        GenerateRow(rows[1] , keyboard.GetEndIndexInRows[0] + 1 , keyboard.GetEndIndexInRows[1]);
        GenerateRow(rows[2] , keyboard.GetEndIndexInRows[1] + 1 , keyboard.GetEndIndexInRows[2]);
        GenerateRow(rows[3] , keyboard.GetEndIndexInRows[2] + 1 , keyboard.GetEndIndexInRows[3]);
        GenerateRow(rows[4] , keyboard.GetEndIndexInRows[3] + 1 , keyboard.GetEndIndexInRows[4]);
    }
    private void GenerateRow(GameObject targetRow , int startIndex , int endIndex)
    {
        for(int index = startIndex ; index <= endIndex ;  index++)
            GenerateKey(targetRow , index);
    }
    private void GenerateKey(GameObject targetRow , int keyIndex)
    {
        GameObject key = GameObject.Instantiate(keyGameObject) as GameObject;
        key.name = keyboard.GetPrimaryKeyList[keyIndex];
        key.transform.parent = targetRow.transform;
        key.GetComponent<Key>().KeyPrimaryValue = keyboard.GetPrimaryKeyList[keyIndex];
        key.GetComponent<Key>().KeySecondaryValue = keyboard.GetSecondaryKeyList[keyIndex];
        StyleKey(key , keyIndex);
    }
    private void StyleKey(GameObject key , int keyIndex)
    {
        float keyWidth = 25 * keyboard.GetKeyWidthList[keyIndex];
        key.GetComponentInChildren<RectTransform>().localScale = Vector3.one;
        key.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(keyWidth,25);
        key.GetComponentInChildren<Text>().text = keyboard.GetPrimaryKeyList[keyIndex];
    }
    // Formats shape of keyboard using standards
    private void FormatKeyboard()
    {
        keyboard.InitializeDefualt();
        bool isStandardDefault = standard == StandardTypes.the104key;
        bool isEnterDefault = enterType == EnterTypes.flat;
        bool noNeedForOtherFormats = isStandardDefault && isEnterDefault;
        if (!noNeedForOtherFormats)
            FormatToOthers();
    }
    private void FormatToOthers()
    {
        if ( standard == StandardTypes.the105key )
            keyboard.MakeIt105Key();
        else if (  standard == StandardTypes.the107key )
            keyboard.MakeIt107Key();
        if ( enterType == EnterTypes.high )
            keyboard.MakeEnterHigh();
        else if ( enterType == EnterTypes.big)
            keyboard.MakeEnterBig();
    }
}
