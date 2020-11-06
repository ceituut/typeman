using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="FightCore",
menuName="TypeMan/PlatformCore/FightCore")]
public class FightCore : PlatformCore
{
    public override void DoCorrectOperationForWarrior(Warrior warrior)
    {
        warrior.Attack();
    }
    public override void DoMistakeOperationForWarrior(Warrior warrior)
    {
        warrior.Armor --;
    }
}