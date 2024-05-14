using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public int howMuchButtonClick;
    public int limitButtonClick;
    private int thisFirstTime;
    public int lenguageID;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        DateTime currentTime = DateTime.Now;
        Debug.Log("Waktu saat ini: " + currentTime);
        lenguageID = PlayerPrefs.GetInt("LocaleKey");
        ChangeLocale(lenguageID);
    }

    public void LoadScene(string sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void SelectStage(int choice)
    {
        PlayerPrefs.SetInt("ChoiceStage", choice);
    }

    public void ChangeLocale(int _localeId)
    {
        firstTimeInstall();
        PlayerPrefs.SetInt("LocaleKey", _localeId);
        StartCoroutine(SetLocale(_localeId));
    }

    private void firstTimeInstall()
    {
        thisFirstTime = 1;
        PlayerPrefs.SetInt("FirstTime", thisFirstTime);
    }

    IEnumerator SetLocale(int _localeId)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeId];
    }

    
    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID
            // Untuk Android, menggunakan perintah berikut untuk keluar dari aplikasi
            Application.Quit();
#endif
    }
}
