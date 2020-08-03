using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Fields
    private TextChain targetTextChain;
    private Platform targetPlatform;
    private int pointerLocation;
    private bool pointerActiveness;

    // Properties
    public TextChain TargetTextChain { get => targetTextChain; set => targetTextChain = value; }
    public Platform TargetPlatform { get => targetPlatform; set => targetPlatform = value; }
    public int PointerLocation { get => pointerLocation; set => pointerLocation = value; }
    public bool PointerActiveness { get => pointerActiveness; set => pointerActiveness = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckChar()
    {

    }

    public void NextChar()
    {

    }

    public void PreviousChar()
    {

    }

}
