using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArManager : MonoBehaviour
{
    [SerializeField] private MiningData[] miningStage;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject panelDescription;
    private bool panelDescriptionStatus;
    private AudioClip audioClip;
    private int choiceStageMining;
    public int lenguageID;

    // Start is called before the first frame update
    void Start()
    {
        panelDescriptionStatus = false;
        choiceStageMining = PlayerPrefs.GetInt("ChoiceStage");
        print(choiceStageMining);
        lenguageID = PlayerPrefs.GetInt("LocaleKey");
        DisplayDescriptionFoundationID();
        
    }

    void DisplayDescriptionFoundationID()
    {
        titleText.text = miningStage[choiceStageMining].miningName;
        descriptionText.text = miningStage[choiceStageMining].miningDescription;
        audioClip = miningStage[choiceStageMining].miningSoundDescription;
    }


    public void OnButtonDescriptionClick()
    {
        if (!panelDescriptionStatus)
        {
            panelDescriptionStatus = true;
            panelDescription.SetActive(true);
        }
        else
        {
            panelDescriptionStatus = false;
            panelDescription.SetActive(false);
        }
    }
    public void PlaySoundDescription()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
}
