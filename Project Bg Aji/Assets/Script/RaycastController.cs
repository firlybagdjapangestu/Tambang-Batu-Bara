using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhanceTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class RaycastController : MonoBehaviour
{
    public FoundationData[] foundationData;

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private int foundationChoice;
    private bool objectInstantiated = false;
    private void Awake()
    {
        foundationChoice = PlayerPrefs.GetInt("ChoiceFoundation");
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhanceTouch.TouchSimulation.Enable();
        EnhanceTouch.EnhancedTouchSupport.Enable();
        EnhanceTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        EnhanceTouch.TouchSimulation.Disable();
        EnhanceTouch.EnhancedTouchSupport.Disable();
        EnhanceTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhanceTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (!objectInstantiated && arRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
                Quaternion rotationFromExistingObject = foundationData[0].foundationPrefab.transform.rotation;
                GameObject obj = Instantiate(foundationData[foundationChoice].foundationPrefab, pose.position, pose.rotation);
                objectInstantiated = true; // Set the flag to true after instantiation
            }
        }
    }
}
