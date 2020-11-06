using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


// Use this component only for generating keyboard.
// Attach it to an instance of KeyboardGenerator prefab ,
// Then Hit Run to generate keyboard.
[ExecuteInEditMode]
public class KeyboardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject keyGameObject;
    [SerializeField] private KeyboardLayout keyboard;
    [SerializeField] private List<GameObject> rows;

    private void Start() 
    {
        GenerateKeyboard();
    }
    private void GenerateKeyboard()
    {
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
        GameObject newKey = GameObject.Instantiate(keyGameObject) as GameObject;
        newKey.name = keyboard.GetDefaultKeyList[keyIndex];
        newKey.transform.parent = targetRow.transform;
        newKey.GetComponent<Key>().KeyPrimaryValue = keyboard.GetDefaultKeyList[keyIndex];
        StyleKey(newKey , keyIndex);
    }
    private void StyleKey(GameObject thisKey , int keyIndex)
    {
        float keyWidth = Key.GetDefaultKeyWidth * keyboard.GetKeyWidthList[keyIndex];
        thisKey.GetComponentInChildren<RectTransform>().localScale = Vector3.one;
        thisKey.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(keyWidth,Key.GetDefaultKeyWidth);
        thisKey.GetComponentInChildren<Text>().text = keyboard.GetDefaultKeyList[keyIndex];
    }
}
