using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    // Fields
    private Profile ownerProfile;
    private List<Pointer> pointerList;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setPlatformNumber();
    }
     private void setPlatformNumber()
 {
    if(Input.GetKeyDown(KeyCode.Tab))
    {
        platformNumber++;
        if(platformNumber>platformManager.instance.maxPlatformNumbers)
        platformNumber=1;

        myPlatform=(platformNumber==1 ? platformManager.StandardPlatform.fight : platformNumber==2 ? platformManager.StandardPlatform.health : platformManager.StandardPlatform.armor);
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

    public void IncreaseDamage()
    {

    }

    public void CreatePointer()
    {

    }
}
