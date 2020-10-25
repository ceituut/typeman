using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    // Fields
    private float health;
    private float armor;
    private float damage;
    private Profile ownerProfile;
    private int platformLocation;
    private List<Progress> progressList;
    [SerializeField] private Animator warriorAmimator;

    // Properties
    public float Health { get => health; set => health = value; }
    public float Armor { get => armor; set => armor = value; }
    public float Damage { get => damage; set => damage = value; }
    public Profile OwnerProfile { get => ownerProfile; set => ownerProfile = value; }
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
    public List<Progress> ProgressList { get => progressList; set => progressList = value; }


    // Methods
    void Awake()
    {
        Armor = 1;
        damage = 10;
        platformLocation = 0;
        progressList = new List<Progress>();
        warriorAmimator = gameObject.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
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
        PlatformLocation ++;
        nextPlatform = platformManager.instance.platformList[PlatformLocation];
        ChangeWarriorPosition(nextPlatform);
    }
    void ChangeWarriorPosition(GameObject targetPlatform)
    {
        GameObject spawnObject = targetPlatform.GetComponent<Platform>().spawnObject;
        Transform spawnTransform = spawnObject.GetComponent<Transform>();
        Vector3 spawnLocation = spawnTransform.localPosition + spawnTransform.parent.position;
        gameObject.GetComponent<Transform>().position = spawnLocation;
    }
    public void Attack()
    {
        warriorAmimator.SetTrigger("OnSimpleAttack");
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
