using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Medal", menuName = "TypeMan/Medal", order = 0)]
public class Medal : ScriptableObject {
    // Fields
    private string medalName;
    private string medalDescription;
    private Sprite medalSprite;

    // Properties
    public string MedalName { get => medalName; set => medalName = value; }
    public string MedalDescription { get => medalDescription; set => medalDescription = value; }
    public Sprite MedalSprite { get => medalSprite; set => medalSprite = value; }
}
