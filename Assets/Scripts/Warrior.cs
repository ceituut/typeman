using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    // Fields
    private Profile ownerProfile;
    private List<GameObject> pointerList;
    private float health;
    private float armor;
    private float damage;

    // Properties
    public Profile OwnerProfile { get => ownerProfile; set => ownerProfile = value; }
    public List<GameObject> PointerList { get => pointerList; set => pointerList = value; }
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
