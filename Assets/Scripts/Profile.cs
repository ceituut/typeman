using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Profile", menuName = "TypeMan/Profile", order = 0)]
public class Profile : ScriptableObject {
    // Fields
    private string profileName;
    private int typeScore;
    private Level typeLevel;
    private List<Medal> medalList;
    private List<Challenge> challengeList;

    // Properties
    public string ProfileName { get => profileName; set => profileName = value; }
    public int TypeScore { get => typeScore; set => typeScore = value; }
    public Level TypeLevel { get => typeLevel; set => typeLevel = value; }
    public List<Medal> MedalList { get => medalList; set => medalList = value; }
    public List<Challenge> ChallengeList { get => challengeList; set => challengeList = value; }
}
