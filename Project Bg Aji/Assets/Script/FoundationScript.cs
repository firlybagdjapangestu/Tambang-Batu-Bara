using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationScript : MonoBehaviour
{
    public FoundationData[] foundationData;
    private int foundationChoice;

    // Start is called before the first frame update
    void Start()
    {
        foundationChoice = PlayerPrefs.GetInt("ChoiceFoundation");
        GameObject obj = Instantiate(foundationData[foundationChoice].foundationPrefab, gameObject.transform.position, Quaternion.identity);
        obj.transform.SetParent(gameObject.transform); // Membuat objek yang di-instantiate menjadi child dari game object ini
    }
}
