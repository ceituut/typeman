using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    private Warrior warrior;
    [SerializeField] private GameObject targetPlatform;
    [SerializeField] private GameObject targetText;
    private InputField playerInputField;
    private char lastInputChar;
    private string neededString;
    private char neededChar;
    private int pointerLocation;
    [SerializeField] private int mistakes;
    [SerializeField] private int backspaceMistakes;
    [SerializeField] private int continuousCorrects;
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
        warrior = gameObject.GetComponent<Warrior>();
        PointerLocation = 0;
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
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
        playerInputField.onValueChanged.AddListener( delegate 
        {
            GetLastInputChar(); 
            CheckChar();
            BonusCorrectsCheck(); 
            GetNeededChar(); 
        });
    }
    public void CheckChar()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            CheckBackspaceMistakes();
            PointerLocation --;
            // continuous corrects ??
        }
        else
        {
            if (lastInputChar == neededChar)
            {
                isTypedCorrectList.Add(true);
                PointerLocation ++;
                continuousCorrects ++;
                // Warrior function according to target platform
                warrior.Attack();
            }
            else
            {
                isTypedCorrectList.Add(false);
                mistakes ++;
                PointerLocation ++;
                continuousCorrects = 0;
                // warrior becomes vulnerable to enemy damage
                warrior.Armor --;
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
    void ClearInputString()
    {
        playerInputField.text = String.Empty;
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
    void BonusCorrectsCheck()
    {
        if (continuousCorrects >=5)
        {
            Debug.Log("Bonus Attack !");
        }
            warrior.BonusAttack(continuousCorrects);
    }
}
