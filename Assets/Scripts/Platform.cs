using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Fields
    private int platformType;
    private int numberOfActivePointers;
    private bool safePlatform;

    // Properties
    public int PlatformType { get => platformType; set => platformType = value; }
    public int NumberOfActivePointers { get => numberOfActivePointers; set => numberOfActivePointers = value; }
    public bool SafePlatform { get => safePlatform; set => safePlatform = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlatformFunction()
    {

    }

    public void OnPointerEnter()
    {

    }

    public void OnPointerLeave()
    {
        
    }
}
