using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : singleton<platformManager>
{
    public enum StandardPlatform {fight,health,armor};

    public List<GameObject> platformList;
    protected override void Awake() 
    {
        base.Awake();
    }
}
