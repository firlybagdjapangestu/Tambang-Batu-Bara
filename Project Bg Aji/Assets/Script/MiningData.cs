using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiningData", menuName = "Mining Data", order = 1)]
public class MiningData : ScriptableObject
{
    public Sprite miningImage;
    public string miningName;
    [TextArea(3, 5)]
    public string miningDescription;
    public AudioClip miningSoundDescription;

    public GameObject MiningPrefabs;
}
