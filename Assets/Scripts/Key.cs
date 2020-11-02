using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject RelatedFinger; 
    [SerializeField] private Text textComponent;
    [SerializeField] private string keyPrimaryValue; 
    [SerializeField] private string keySecondaryValue;

    public string KeyPrimaryValue { get => keyPrimaryValue; set => keyPrimaryValue = value; }
    public string KeySecondaryValue { get => keySecondaryValue; set => keySecondaryValue = value; }
    public Text TextComponent { get => textComponent; set => textComponent = value; }

    private void Awake() 
    {
        textComponent = gameObject.GetComponentInChildren<Text>();   
    }
}
