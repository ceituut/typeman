using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    [SerializeField] private Warrior warrior;
    private GameObject targetPlatform;
    private GameObject targetText;
    private TMPro.TMP_InputField playerInputField;
    private char lastInputChar;
    [SerializeField] private string neededString;
    [SerializeField] private char neededChar;
    [SerializeField] private int pointerLocation;
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
    public GameObject TargetPlatform { get => targetPlatform; set => targetPlatform = value; }

    // Start is called before the first frame update
    void Start()
    {
        warrior = gameObject.GetComponentInParent<Warrior>();
    }

    // Update is called once per frame
    void Update()
    {
        KeepActiveInputField();
    }
    public void InitializePointer(GameObject newPlatform)
    {
        warrior.PointerList.Add(this);
        InitializeStatus();
        InitializeNeededString(newPlatform);
        InitializeInputField();
    }
    void InitializeStatus() 
    {
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
        isTypedCorrectList = new List<bool>();
    }
    void InitializeNeededString(GameObject targetPlatform)
    {
        PointerLocation = 0;
        targetText = targetPlatform.GetComponent<Platform>().textChild;
        neededString = targetText.GetComponent<TextMesh>().text.ToString();
    }
    void InitializeInputField()
    {
        playerInputField = gameObject.GetComponent<TMPro.TMP_InputField>();
        playerInputField.textComponent = gameObject.GetComponent<TMPro.TextMeshPro>();
        ActivateInputField();
        // Removes previous lisntners
        if(warrior.PointerList.Count != 0)
            playerInputField.onValueChanged.RemoveAllListeners();
        // Adds listner to the playerInutField and invokes CheckInput() when the value changes
        playerInputField.onValueChanged.AddListener( delegate
        {
            GetLastInputChar();
            GetNeededChar();
            CheckInput();
            BonusCorrectsCheck(); 
        });
    }
    void ActivateInputField()
    {
        playerInputField.ActivateInputField();
        playerInputField.Select();
    }
    void KeepActiveInputField()
    {
        if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) 
        || Input.GetKey(KeyCode.Mouse2) || Input.GetKey(KeyCode.Mouse3) 
        || Input.GetKey(KeyCode.Mouse4) || Input.GetKey(KeyCode.Mouse5)
        || Input.GetKey(KeyCode.Mouse6))
            ActivateInputField();
    }
    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (isTypedCorrectList.Count != 0)
            {
                CheckBackspaceMistakes();
                targetText.GetComponent<TextChain>().OneStepBack(pointerLocation); ///// performance
                PointerLocation --;
            }
            continuousCorrects = 0;
        }
        else ///if (!IsTextEnd())
            CheckChar();
        // else
        // {
        //     pointerLocation = 0;
        //     // Text is ended. new text needed.
        // }
    }
    void CheckChar()
    {
        targetText.GetComponent<TextChain>().WasTyped(pointerLocation); ///// performance
        if (lastInputChar == neededChar)
            AddCorrect();
        else
            AddMistake();
    }
    void AddCorrect()
    {
        isTypedCorrectList.Add(true);
        PointerLocation ++;
        continuousCorrects ++;
        // Warrior function according to target platform
        warrior.Attack();
    }
    void AddMistake()
    {
        isTypedCorrectList.Add(false);
        mistakes ++;
        PointerLocation ++;
        continuousCorrects = 0;
        // warrior becomes vulnerable to enemy damage
        warrior.Armor --;
    }
    public void GetLastInputChar()
    {
        string playerInputString = playerInputField.text.ToString();
        if (playerInputString.Length != 0)
            lastInputChar = playerInputString[playerInputString.Length - 1];
    }
    public void GetNeededChar()
    {
        // if (!IsTextEnd()) /////////////////////////////////////////////////
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
    public void BonusCorrectsCheck()
    {
        if (continuousCorrects >= 5)
            warrior.BonusAttack(continuousCorrects);
    }
    bool IsTextEnd()
    {
        if (pointerLocation > (neededString.Length -1))
            return true;
        else
            return false;
    }
}
