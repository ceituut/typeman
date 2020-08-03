using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "TypeMan/Level", order = 0)]
public class Level : ScriptableObject {
    // Fields
    private string levelName;
    private string levelDescription;
    private Sprite levelSprite;

    // Properties
    public string LevelName { get => levelName; set => levelName = value; }
    public string LevelDescription { get => levelDescription; set => levelDescription = value; }
    public Sprite LevelSprite { get => levelSprite; set => levelSprite = value; }
}
