using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    private char neededChar;
    private char lastInputChar;
    [SerializeField] private GameObject targetPlatform;
    private InputField playerInputField;
    [SerializeField] private GameObject targetText;
    private string neededString;
    private int pointerLocation;
    [SerializeField] private int mistakes;
    [SerializeField] private int backspaceMistakes;
    private List<bool> isTypedCorrectList;
    private bool pointerActiveness;

    // Properties
    public int PointerLocation
    {
        get {return pointerLocation;}
        set {            
                if (value >= 0)
                    pointerLocation = value;
            }
    }
    public bool PointerActiveness { get => pointerActiveness; set => pointerActiveness = value; }

    // Start is called before the first frame update
    void Start()
    {
        PointerLocation = 0;
        mistakes = 0;
        backspaceMistakes = 0;
        lastInputChar = '\0';
        isTypedCorrectList = new List<bool>();
        neededString = targetText.GetComponent<Text>().text.ToString();
        GetNeededChar();
        ActivatePlayerInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivatePlayerInput()
    {
        playerInputField = gameObject.GetComponent<InputField>();
        playerInputField.textComponent = gameObject.GetComponent<Text>();
        playerInputField.ActivateInputField();
        playerInputField.Select();
        // Adds listner to the playerInutField and invokes CheckChar() when the value changes
        playerInputField.onValueChanged.AddListener(delegate {GetLastInputChar(); CheckChar(); GetNeededChar(); });
    }
    public void CheckChar()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CheckBackspaceMistakes();
            PointerLocation --;
        }
        else
        {
            if (lastInputChar == neededChar)
            {
                // Warrior function according to target platform
                isTypedCorrectList.Add(true);
                PointerLocation ++;
            }
            else
            {
                isTypedCorrectList.Add(false);
                // warrior becomes vulnerable to enemy high damage
                this.mistakes ++;
                PointerLocation ++;
            }
        }
    }
    void GetLastInputChar()
    {
        string playerInputString = playerInputField.text.ToString();
        if (playerInputString.Length != 0)
            lastInputChar = playerInputString[playerInputString.Length - 1];
    }
    void GetNeededChar()
    {
        neededChar = neededString[PointerLocation];
    }
    void ClearString()
    {
        playerInputField.textComponent.text = String.Empty;
    }
    void CheckBackspaceMistakes()
    {
        bool currentCharIsCorrect;
        int length = isTypedCorrectList.Count;
        if (length > 0)
        {
            currentCharIsCorrect = isTypedCorrectList[length-1];
            if (currentCharIsCorrect)
                this.backspaceMistakes ++;
            isTypedCorrectList.RemoveAt(length-1);
        }
    }
}
