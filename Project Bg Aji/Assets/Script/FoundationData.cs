using UnityEngine;

[CreateAssetMenu(fileName = "FoundationData", menuName = "Foundation Data", order = 1)]
public class FoundationData : ScriptableObject
{
    public Sprite foundationImage;
    public string foundationName;
    [TextArea(3, 5)]
    public string foundationDescription;
    public AudioClip soundDescription;

    public string namaPondasi;
    [TextArea(3, 5)]
    public string deskripsiPondasi;
    public AudioClip suaraPenjelasan;

    public GameObject foundationPrefab;
}
