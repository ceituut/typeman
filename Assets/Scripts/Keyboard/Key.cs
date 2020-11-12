using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    // Fields
    private static float defaultKeyWidth;
    public int indexInRefLayout;
    [SerializeField] private Text textComponent;
    [SerializeField] private string primaryValue; 
    [SerializeField] private string secondaryValue;
    [SerializeField] private RectTransform rectTransform;
    // public GameObject RelatedFinger; 

    // Properties
    public static float GetDefaultKeyWidth { get => defaultKeyWidth; set => defaultKeyWidth = value; }
    public string PrimaryValue { get => primaryValue; set => primaryValue = value; }
    public string SecondaryValue { get => secondaryValue; set => secondaryValue = value; }
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
    public void CloneKey(Key cloneKey)
    {
        this.textComponent.text = cloneKey.textComponent.text;
        this.primaryValue = cloneKey.primaryValue;
        this.secondaryValue = cloneKey.secondaryValue;
        this.indexInRefLayout = cloneKey.indexInRefLayout;
    }
    public void MakeEmpty()
    {
        this.textComponent.text = string.Empty;
        this.primaryValue = string.Empty;
        this.secondaryValue = string.Empty;
    }
}
