using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningStage : MonoBehaviour
{
    public MiningData[] miningStageData;
    [SerializeField] private int stageChoice;

    private void Awake()
    {
        stageChoice = PlayerPrefs.GetInt("ChoiceStage");
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = gameObject.transform.position;
        spawnPosition.y = -0.5f; // Mengubah nilai Y

        GameObject obj = Instantiate(miningStageData[stageChoice].MiningPrefabs, spawnPosition, Quaternion.identity);
        obj.transform.SetParent(gameObject.transform); // Membuat objek yang di-instantiate menjadi child dari game object ini
    }
}
