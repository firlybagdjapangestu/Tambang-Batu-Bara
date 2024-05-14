using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject panelProfileMenu;
    [SerializeField] private GameObject panelPanduanMenu;


    [SerializeField] private bool descriptionStatus;

    [SerializeField] private Transform selectedMenu;
    [SerializeField] private Transform profileIcon;
    [SerializeField] private Transform panduanIcon;
    [SerializeField] private Transform arIcon;

    [SerializeField] private float moveSpeed = 2.0f; // Kecepatan pergerakan UI

    private bool isMoving;
    public void ActiveProfileMenu()
    {
        panelProfileMenu.SetActive(true);
        panelPanduanMenu.SetActive(false); 
        MoveSelectedMenu(profileIcon.position);
    }

    public void ActivePanduanMenu()
    {
        panelPanduanMenu.SetActive(true);
        panelProfileMenu.SetActive(false); 
        MoveSelectedMenu(panduanIcon.position);
    }

    public void ActiveArMenu()
    {
        panelPanduanMenu.SetActive(false);
        panelProfileMenu.SetActive(false);
        MoveSelectedMenu(arIcon.position);
    }


    public void MoveSelectedMenu(Vector3 targetPosition)
    {
        StartCoroutine(MoveToTarget(targetPosition));
    }

    public void TurnDescriptionStatus()
    {
        if(descriptionStatus == false)
        {
            descriptionStatus = true;
        }
        else
        {
            descriptionStatus = false;
        }
    }

    public void TurnGambar(GameObject gambar)
    {
        if(descriptionStatus == true)
        {
            gambar.SetActive(false);
        }
        else
        {
            gambar.SetActive(true);
        }
    }

    public void TurnDescription(GameObject description)
    {
        if (descriptionStatus == true)
        {
            description.SetActive(true);
        }
        else
        {
            description.SetActive(false);
        }
        
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        isMoving = true;
        Vector3 currentPos = selectedMenu.position;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;
            selectedMenu.position = Vector3.Lerp(currentPos, targetPosition, t);
            yield return null;
        }

        isMoving = false;
    }
}
