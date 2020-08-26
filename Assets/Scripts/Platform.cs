using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int numberOfActiveness;
    public bool IsSafePlatform;
    public platformManager.StandardPlatform platformType;
    public GameObject textChild;
    public List<Warrior> warriorsWithin;//all the warriors inside this platform


    private void InitializePlatform()
    {
        numberOfActiveness  = 0;//first time we start the game
    }
    private void Awake()
    {
        InitializePlatform();
    }
    private void CheckNumberOfActiveWarriorsWithin()
    {
        numberOfActiveness = warriorsWithin.Count;
        IsSafePlatform = (warriorsWithin.Count == 0 ? true : false);
    }
    private void OnTriggerEnter(Collider _collider)
    {
        Warrior enteredWarrior = _collider.gameObject.GetComponent<Warrior>();
        Debug.Log("justCalled");
        if (enteredWarrior == null)
            Debug.Log("not Entered");
        if (enteredWarrior == null)
            return;
        Debug.Log("Enterd");

        bool needsNewPointer = true;
        Pointer pointerOfWarrior = _collider.gameObject.GetComponentInChildren<Pointer>();
        warriorsWithin.Add(enteredWarrior);
        CheckNumberOfActiveWarriorsWithin();
        foreach(Pointer thisPointer in enteredWarrior.PointerList)
        {
            if (thisPointer.TargetPlatform == this.gameObject)
                {
                    pointerOfWarrior = thisPointer; ////////// deep copy need/////////////
                    pointerOfWarrior.TargetPlatform = this.gameObject;   
                    needsNewPointer = false;
                    break;
                }
        }
        if(needsNewPointer)
        {
            pointerOfWarrior.InitializePointer();
            pointerOfWarrior.TargetPlatform = this.gameObject;
            enteredWarrior.PointerList.Add(pointerOfWarrior);
        }
    }
    private void OnTriggerExit(Collider _collider)
    {
        Warrior exitedWarrior = _collider.gameObject.GetComponent<Warrior>();
        if(exitedWarrior != null)
        {
            CheckNumberOfActiveWarriorsWithin();
            warriorsWithin.Remove(exitedWarrior);
        }
    }
}
