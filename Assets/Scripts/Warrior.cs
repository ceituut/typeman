using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    // Fields
    private Profile ownerProfile;
    public List<Pointer> PointerList;
    private float health;
    private float armor;
    private float damage;
    private int platformLocation = 0;

    // Properties
    public Profile OwnerProfile { get => ownerProfile; set => ownerProfile = value; }
    public float Health { get => health; set => health = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Damage { get => damage; set => damage = value; }
    public int PlatformLocation 
    {
        get {return platformLocation;}
        set 
        {
            int numberOfPlatforms = platformManager.instance.platformList.Count;
            if (value < numberOfPlatforms)
                platformLocation = value;
            else
                platformLocation = value % numberOfPlatforms;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        Armor = 1;
        damage = 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            ChangePlatform();
    }
    public void PerformOperation(platformManager.StandardPlatform currentPlatform)
    {
        switch(currentPlatform)
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
    private void ChangePlatform()
    {
        GameObject nextPlatform;
        platformLocation ++;
        nextPlatform = platformManager.instance.platformList[platformLocation];
        ChangeWarriorPosition(nextPlatform);
    }
    void ChangeWarriorPosition(GameObject targetPlatform)
    {

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
}
