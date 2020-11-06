﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    // Fields
    private static float defaultKeyWidth;
    public int indexInRefLayout;
    [SerializeField] private Text textComponent;
    [SerializeField] private string keyPrimaryValue; 
    [SerializeField] private string keySecondaryValue;
    [SerializeField] private RectTransform rectTransform;
    // public GameObject RelatedFinger; 

    // Properties
    public static float GetDefaultKeyWidth { get => defaultKeyWidth; set => defaultKeyWidth = value; }
    public string KeyPrimaryValue { get => keyPrimaryValue; set => keyPrimaryValue = value; }
    public string KeySecondaryValue { get => keySecondaryValue; set => keySecondaryValue = value; }
    public Text TextComponent { get => textComponent; set => textComponent = value; }

    // Methods
    private void Awake() 
    {
        defaultKeyWidth = 25f;
        textComponent = gameObject.GetComponentInChildren<Text>();  
        rectTransform = gameObject.GetComponent<RectTransform>(); 
    }
    public void SetHeightScale(float heightScale)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x , defaultKeyWidth * heightScale);
    }
    public void SetWidthScale(float widthScale)
    {
        rectTransform.sizeDelta = new Vector2(widthScale * defaultKeyWidth , rectTransform.sizeDelta.y);
    }
}