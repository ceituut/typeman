using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ForEdit : MonoBehaviour
{
    [SerializeField] private GameObject keyboard;
    [SerializeField] private List<GameObject> rows;

    private void Start() 
    {
        Stylize();
    }
    private void Stylize()
    {
        foreach(Text text in keyboard.GetComponentsInChildren<Text>())
        {
            text.color = new Color(0f/255f,48f/255f,81f/255f,255f/255f);
        }
    }
}
