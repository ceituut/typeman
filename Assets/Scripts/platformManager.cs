using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : singleton<platformManager>
{
    public int maxPlatformNumbers=3;
    public enum StandardPlatform
    {
        fight,//red
        health,//green
        armor//black
    };


}
