using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformCore : ScriptableObject
{
    // Fields 
    public int increaseAmount;
    public int decreaseAmount;

    // Methods
    public abstract void DoCorrectOperationForWarrior(Warrior warrior); 
    public abstract void DoMistakeOperationForWarrior(Warrior warrior); 
}