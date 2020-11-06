using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="HealthCore",
menuName="TypeMan/PlatformCore/HealthCore")]
public class HealthCore : PlatformCore
{
    public override void DoCorrectOperationForWarrior(Warrior warrior)
    {
        warrior.Health ++;
    }
    public override void DoMistakeOperationForWarrior(Warrior warrior)
    {
        warrior.Armor --;
    }
}