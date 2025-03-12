using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text debugText; // Debug text object
    [SerializeField] private GameObject ballPrefab; // prefab to spawn
    private ARRaycastManager arrcm; // Referencese the AR ray Cast manager

    // List to stora ARRaycashHits
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); 

    // Determine what kind of trackable we want our raycast to detect

    TrackableType trackableType = TrackableType.PlaneWithinPolygon;

    private void Start()
    {
        arrcm = GetComponent<ARRaycastManager>(); //Find the raycast manager components
    }

    public void SingleTap(InputAction.CallbackContext context)
    {
        // Check if input was completed
        if(context.phase == InputActionPhase.Performed)
        {
            var touchPos = context.ReadValue<Vector2>();    
            debugText.text = touchPos.ToString();

            if(arrcm.Raycast(touchPos, hits, trackableType))
            {


                var ball = Instantiate(ballPrefab, hits[0].pose.position, new Quaternion());
            }
        }
    }

}
