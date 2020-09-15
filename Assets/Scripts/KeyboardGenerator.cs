using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Just use it for creating keyboard in edit mode
// Attach it to keyboard Object
// It will generate all keys
[ExecuteInEditMode]
public class KeyboardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject keyGameObject;
    [SerializeField] private KeyboardLayout keyboard;
    [SerializeField] private List<int> rowLimits;
    [SerializeField] private GameObject row0;
    [SerializeField] private GameObject row1;
    [SerializeField] private GameObject row2;
    [SerializeField] private GameObject row3;
    [SerializeField] private GameObject row4;

    private void Start() 
    {
        int length = keyboard.GetPrimaryKeyList.Count;
        rowLimits = keyboard.GetLimitedRows;

        GenerateRow(row0 , 0 , rowLimits[0]);
        GenerateRow(row1 , rowLimits[0] + 1 , rowLimits[1]);
        GenerateRow(row2 , rowLimits[1] + 1 , rowLimits[2]);
        GenerateRow(row3 , rowLimits[2] + 1 , rowLimits[3]);
        GenerateRow(row4 , rowLimits[3] + 1 , rowLimits[4]);
    }
    private void GenerateRow(GameObject thisRow , int startIndex , int endIndex)
    {
        GameObject key;
        for(int index = startIndex ; index <= endIndex ;  index++)
        {
            key = GameObject.Instantiate(keyGameObject) as GameObject;
            key.name = keyboard.GetPrimaryKeyList[index];
            key.transform.parent = thisRow.transform;
            key.GetComponentInChildren<Text>().text = keyboard.GetPrimaryKeyList[index];
            key.GetComponent<Key>().KeyPrimaryValue = keyboard.GetPrimaryKeyList[index];
            key.GetComponent<Key>().KeySecondaryValue = keyboard.GetSecondaryKeyList[index];
            key.GetComponentInChildren<RectTransform>().localScale = Vector3.one;
            key.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(25,20);
        }
    }
}
