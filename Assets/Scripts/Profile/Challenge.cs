using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "TypeMan/Challenge", order = 0)]
public class Challenge : ScriptableObject {
    // Fields
    private string challengeName;
    private string challengeDescription;
    private int awardScore;
    private Sprite challengeSprite;

    // Properties
    public string ChallengeName { get => challengeName; set => challengeName = value; }
    public string ChallengeDescription { get => challengeDescription; set => challengeDescription = value; }
    public int AwardScore { get => awardScore; set => awardScore = value; }
    public Sprite ChallengeSprite { get => challengeSprite; set => challengeSprite = value; }
}
