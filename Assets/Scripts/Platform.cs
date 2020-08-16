using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int numberOfActiveness;
    public List<Warrior> warriorsWithin;//all the warriors inside this platform
    public bool IsSafePlatform;
    public platformManager.StandardPlatform myPlatform;
    private void Initializings()
    {
            numberOfActiveness  = 0;//first time we start the game
            myPlatform = platformManager.StandardPlatform.fight;
    }
    private void Awake()
    {
        Initializings();
    }
    private void Update()
    {
        CheckNumberOfActiveWarriorsWithin();
    }
    private void CheckNumberOfActiveWarriorsWithin()
    {
        numberOfActiveness=warriorsWithin.Count;
        IsSafePlatform=(warriorsWithin.Count==0? true:false);
    }


    private void OnTriggerEnter(Collider _collider)
    {
        bool equalFound=false;
        if(_collider.gameObject.GetComponent<Warrior>()!=null)//if warrior enters a specific platform(current platform)
        {
            Pointer tempPointer=new Pointer();
            tempPointer.myPlatform=myPlatform;
            _collider.gameObject.GetComponent<Warrior>().PointerList.Add(tempPointer);
        }
        //wtite script to set warriors pointer
    }
     private void OnTriggerExit(Collider _collider)
    {
        if(_collider.gameObject.GetComponent<Warrior>()!=null)//if warrior enters a specific platform(current platform)
        {
            warriorsWithin.Remove( _collider.gameObject.GetComponent<Warrior>());
        }
    }
}
