using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Definition;

public class HandManager : singleton<HandManager>
{
    [SerializeField] private GameObject keyboard;
    [SerializeField] private Dictionary<string,FingerTypes> primaryKeyFingerMap;
    [SerializeField] private Dictionary<string,FingerTypes> secondaryKeyFingerMap;
    [SerializeField] private Dictionary<string,Key> primaryKeyMap;
    [SerializeField] private Dictionary<string,Key> secondaryKeyMap;
    [SerializeField] private List<GameObject> rightHandFingers;
    [SerializeField] private List<GameObject> leftHandFingers;

    protected override void Awake() 
    {
        base.Awake();
        // SetDic();
    }

    public void SetDic()
    {
        //// avoid repititive keys !!!
        primaryKeyFingerMap = new Dictionary<string, FingerTypes>();
        secondaryKeyFingerMap = new Dictionary<string, FingerTypes>();
        primaryKeyMap = new Dictionary<string, Key>();
        secondaryKeyMap = new Dictionary<string, Key>();
        bool isThisKeyExists = true;
        FingerTypes thisFinger;
        Key thisKey;
        foreach (Key key in keyboard.GetComponentsInChildren<Key>())
        {
            isThisKeyExists = true;
            isThisKeyExists = primaryKeyFingerMap.TryGetValue(key.PrimaryValue , out thisFinger);
            if (!isThisKeyExists)
                primaryKeyFingerMap.Add(key.PrimaryValue , key.GetFingerType);

            isThisKeyExists = true;
            isThisKeyExists = secondaryKeyFingerMap.TryGetValue(key.SecondaryValue , out thisFinger);
            if (!isThisKeyExists)
                secondaryKeyFingerMap.Add(key.SecondaryValue , key.GetFingerType);

            isThisKeyExists = true;
            isThisKeyExists = primaryKeyMap.TryGetValue(key.PrimaryValue , out thisKey);
            if (!isThisKeyExists)
                primaryKeyMap.Add(key.PrimaryValue , key);
            
            isThisKeyExists = true;
            isThisKeyExists = secondaryKeyMap.TryGetValue(key.SecondaryValue , out thisKey);
            if (!isThisKeyExists)
                secondaryKeyMap.Add(key.SecondaryValue , key);
        }
    }
    public void MoveRelatedFinger(char currentChar)
    {
        string currentKey = currentChar.ToString();
        bool foundInPrimaries = false;
        bool foundInRightHands = false;
        bool foundInLeftHands = false;

        FingerTypes targetFingerType;
        GameObject targetFingerObject = rightHandFingers[0];
        Key targetKey;

        foundInPrimaries = primaryKeyFingerMap.TryGetValue(currentKey , out targetFingerType);
        if(!foundInPrimaries)
            secondaryKeyFingerMap.TryGetValue(currentKey , out targetFingerType);

        for(int index = 0; index < 5; index++)
        {
            if(rightHandFingers[index].GetComponent<Finger>().GetFingerType == targetFingerType)
            {
                targetFingerObject = rightHandFingers[index];
                foundInRightHands = true;
                break;
            }
            if(leftHandFingers[index].GetComponent<Finger>().GetFingerType == targetFingerType)
            {
                targetFingerObject = leftHandFingers[index];
                foundInLeftHands = true;
                break;
            }
        }

        if(foundInPrimaries)
            primaryKeyMap.TryGetValue(currentKey , out targetKey);
        else
            secondaryKeyMap.TryGetValue(currentKey , out targetKey);
    
        
        Vector3 deltaVector = new Vector3();
        deltaVector = targetKey.GetActualPosition() - targetFingerObject.GetComponent<Finger>().GetActualPosition();

        targetFingerObject.GetComponent<Finger>().ActivateColor();

        if(foundInRightHands)
            foreach(GameObject finger in rightHandFingers)
                finger.gameObject.GetComponent<Finger>().SetActualPosition(deltaVector);
        if(foundInLeftHands)
            foreach(GameObject finger in leftHandFingers)
                finger.gameObject.GetComponent<Finger>().SetActualPosition(deltaVector);
    }
    public void ResetAllFingers()
    {
        foreach(GameObject finger in rightHandFingers)
        {
            finger.GetComponent<Finger>().ResetColor();
            finger.gameObject.GetComponent<Finger>().SetActualPosition(finger.GetComponent<Finger>().GetInitialLPosition);
        }
    }
}