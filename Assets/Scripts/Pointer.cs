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
    private Report currentReport;
    private TMPro.TMP_InputField playerInputField;
    [SerializeField] private string neededString;
    [SerializeField] private char neededChar;
    private char lastInputChar;
    [SerializeField] private int pointerLocation;

    // Properties
    public int PointerLocation
    {
        get {return pointerLocation;}
        set {            
                if (value >= 0)
                    pointerLocation = value;
            }
    }
    public GameObject TargetPlatform { get => targetPlatform; set => targetPlatform = value; }

    // Start is called before the first frame update
    void Start()
    {
        warrior = gameObject.GetComponentInParent<Warrior>();
        currentReport = new Report();
    }

    // Update is called once per frame
    void Update()
    {
        KeepActiveInputField();
    }
    public void InitializePointer(GameObject newPlatform)
    {
        warrior.PointerList.Add(this);
        currentReport = new Report();
        InitializeNeededString(newPlatform);
        InitializeInputField();
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
            if (currentReport.CanBackespace())
            {
                currentReport.CheckBackspaceMistakes();
                targetText.GetComponent<TextChain>().OneStepBack(pointerLocation); ///// performance
                PointerLocation --;
            }
            currentReport.ContinuousCorrects = 0;
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
            PerformCorrectAction();
        else
            PerformMistakeAction();
    }
    void PerformCorrectAction()
    {
        currentReport.AddCorrect();
        PointerLocation ++;
        // Warrior function according to target platform
        // warrior.PerformOperation(TargetPlatform.GetComponent<Platform>().platformType);
    }
    void PerformMistakeAction()
    {
        currentReport.AddMistake();
        PointerLocation ++;
        // warrior becomes vulnerable to enemy damage
        // warrior.Armor --;
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
    public void BonusCorrectsCheck()
    {
        if (currentReport.ContinuousCorrects >= 5)
            warrior.BonusAttack(currentReport.ContinuousCorrects);
    }
    bool IsTextEnd()
    {
        if (pointerLocation > (neededString.Length -1))
            return true;
        else
            return false;
    }
}
