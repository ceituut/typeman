using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="ArmorCore",
menuName="TypeMan/PlatformCore/ArmorCore")]
public class ArmorCore : PlatformCore
{
    public override void DoCorrectOperationForWarrior(Warrior warrior)
    {
        warrior.Armor ++;
    }
    public override void DoMistakeOperationForWarrior(Warrior warrior)
    {
        warrior.Health --;
    }
}