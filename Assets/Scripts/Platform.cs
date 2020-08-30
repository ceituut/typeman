using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Fields
    private int numberOfActiveness;
    public bool IsSafePlatform;
    public platformManager.StandardPlatform platformType;
    public GameObject textChild;
    public List<Warrior> warriorsWithin;//all the warriors inside this platform

    // Properties
    public int NumberOfActiveness
    {
        get {return numberOfActiveness;}
        set
        {
            if (value == 0)
                IsSafePlatform = true;
            else
                IsSafePlatform = false;
            numberOfActiveness = value;
        }
    }

    private void InitializePlatform()
    {
        numberOfActiveness  = 0;
    }
    private void Awake()
    {
        InitializePlatform();
    }
    private void OnTriggerEnter(Collider _collider)
    {
        Warrior enteredWarrior = _collider.gameObject.GetComponent<Warrior>();
        if (enteredWarrior == null)
            return;

        bool needsNewPointer = true;
        Pointer pointerOfWarrior = _collider.gameObject.GetComponentInChildren<Pointer>();
        warriorsWithin.Add(enteredWarrior);
        numberOfActiveness ++;
        foreach(Pointer thisPointer in enteredWarrior.PointerList)
            if (thisPointer.TargetPlatform == this.gameObject)
                {
                    pointerOfWarrior = thisPointer;
                    needsNewPointer = false;
                    break;
                }
        if(needsNewPointer)
            pointerOfWarrior.InitializePointer(this.gameObject);
    }
    private void OnTriggerExit(Collider _collider)
    {
        Warrior exitedWarrior = _collider.gameObject.GetComponent<Warrior>();
        if(exitedWarrior != null)
            return;
        numberOfActiveness --;
        warriorsWithin.Remove(exitedWarrior);
    }
}
