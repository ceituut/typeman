using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Just use it for creating keyboard in edit mode
// Attach it to Keyboard Object
// It will generate all keys
[ExecuteInEditMode]
public class KeyboardGenerator : MonoBehaviour
{
    [SerializeField] private KeyboardEdition keyboard;
    [SerializeField] private GameObject keyGameObject;
    private void Start() 
    {
        GameObject go;
        foreach(string primaryValue in keyboard.PrimaryKeyList)
        {
            go = GameObject.Instantiate(keyGameObject) as GameObject;
            go.transform.parent = gameObject.transform;
            go.name = primaryValue;
            go.GetComponent<Key>().KeyPrimaryValue = primaryValue;
            go.GetComponentInChildren<Text>().text = primaryValue;
            go.GetComponentInChildren<RectTransform>().localScale = Vector3.one;
        }
    }
}
