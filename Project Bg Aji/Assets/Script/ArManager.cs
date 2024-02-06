using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArManager : MonoBehaviour
{
    [SerializeField] private FoundationData[] Foundations;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private AudioSource audioSource;
    private AudioClip audioClip;
    private int choiceFoundation;
    public int lenguageID;

    // Start is called before the first frame update
    void Start()
    {
        choiceFoundation = PlayerPrefs.GetInt("ChoiceFoundation");
        lenguageID = PlayerPrefs.GetInt("LocaleKey"); 
        if (lenguageID == 0)
        {
            DisplayDescriptionFoundationEN();
        }
        else
        {
            DisplayDescriptionFoundationID();
        }
        
    }

    void DisplayDescriptionFoundationID()
    {
        titleText.text = Foundations[choiceFoundation].namaPondasi;
        descriptionText.text = Foundations[choiceFoundation].deskripsiPondasi;
        audioClip = Foundations[choiceFoundation].suaraPenjelasan;
    }

    void DisplayDescriptionFoundationEN()
    {
        titleText.text = Foundations[choiceFoundation].foundationName;
        descriptionText.text = Foundations[choiceFoundation].foundationDescription;
        audioClip = Foundations[choiceFoundation].soundDescription;
    }

    public void PlaySoundDescription()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
