using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public int numberOfActiveness,pointerLocation;
    public List<Warrior> warriorsWithin;//all the warriors inside this platform
    public Warrior[] allWarriorsInMyPlatform;
    public bool IsSafePlatform;

    public platformManager.StandardPlatform myPlatform;
    private void Initializings()
    {
        numberOfActiveness = pointerLocation = 0;//first time we start the game
        myPlatform = platformManager.StandardPlatform.fight;
    }
    private void Awake()
    {
        Initializings();
    }


    private void OnTriggerEnter(Collider _collider)
    {
        bool equalFound=false;
        if(_collider.gameObject.GetComponent<Warrior>()!=null)//if warrior enters a specific platform(current platform)
        {
            _collider.gameObject.GetComponent<Warrior>().myPlatform = myPlatform;
            warriorsWithin.Add( _collider.gameObject.GetComponent<Warrior>());
            foreach(Pointer p in _collider.gameObject.GetComponent<Warrior>().PointerList)
            {
                if(p.myPlatform==myPlatform)
                {
                    equalFound=true;
                    break;
                }
            }
            if(equalFound==false)
            {
                Pointer tempPointer=new Pointer();
                tempPointer.myPlatform=myPlatform;
                _collider.gameObject.GetComponent<Warrior>().PointerList.Add(tempPointer);
            }
        
        }
    }
     private void OnTriggerExit(Collider _collider)
    {
        if(_collider.gameObject.GetComponent<Warrior>()!=null)//if warrior enters a specific platform(current platform)
        {
            warriorsWithin.Remove( _collider.gameObject.GetComponent<Warrior>());
        }
    }
}
