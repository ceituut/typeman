using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    // Fields
    private Profile ownerProfile;
    public List<Pointer> pointerList;
    public Pointer currentpointer;
    private float health;
    private float armor;
    private float damage;
    public int platformNumber=1;
    public platformManager.StandardPlatform myPlatform;

    // Properties
    public Profile OwnerProfile { get => ownerProfile; set => ownerProfile = value; }
    public List<Pointer> PointerList { get => pointerList; set => pointerList = value; }
    public float Health { get => health; set => health = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Damage { get => damage; set => damage = value; }
  

    // Start is called before the first frame update
    void Awake()
    {
        Armor = 1;
        damage = 10;
    }
    // Update is called once per frame
    void Update()
    {
        setPlatformNumber();
        WarriorsActionBasedOnPlatformType();
    }
     private void setPlatformNumber()
 {
    if(Input.GetKeyDown(KeyCode.Tab))
    {
        platformNumber++;
        if(platformNumber>platformManager.instance.maxPlatformNumbers)
            platformNumber=1;

        myPlatform=(platformNumber==1 ? platformManager.StandardPlatform.fight : platformNumber==2 ? platformManager.StandardPlatform.health : platformManager.StandardPlatform.armor);
        foreach(Pointer p in pointerList)
        {
            if(p.myPlatform==myPlatform)
            {
                currentpointer=p;
                break;
            }
        }
    }
 }
    private void WarriorsActionBasedOnPlatformType()
    {
        switch(myPlatform)
        {
            case platformManager.StandardPlatform.fight :
                Attack();
                break;
                case platformManager.StandardPlatform.health :
                IncreaseHealth();
                break;
                case platformManager.StandardPlatform.armor :
                increaseArmor();
                break;
        }
    }
    public void Attack()
    {

    }

    public void BonusAttack(int continuousCorrects)
    {

    }

    public void IncreaseHealth()
    {

    }

    public void increaseArmor()
    {

    }

    public void CreatePointer()
    {
        
    }
}
