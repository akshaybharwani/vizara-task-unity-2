using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    #region Public Variables

    // Reference to the GameObject to be placed on the AR Plane
    public GameObject gameObjectToInstantiate;

    #endregion

    #region Private Variables

    // Reference to the GameObject Placed
    private GameObject _spawnedObject;

    private ARRaycastManager _arRaycastManager;

    // Position where the Screen is tapped
    private Vector2 _touchPosition;
    
    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    // Reference to store UI Manager Component
    private UIManager _UIManagerComponent;

    #endregion

    private void Awake()
    {
        // Assign the Component
        _arRaycastManager = GetComponent<ARRaycastManager>();
        
        // Assign UI Manager Component
        _UIManagerComponent = FindObjectOfType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If there are no Touches, return
        if (!GetTouchPosition(out Vector2 touchposition))
            return;

        // If there is a Touch Position inside the Plane detected by
        // ARCore/ARKit
        if (_arRaycastManager.Raycast(touchposition, _hits,
            TrackableType.PlaneWithinPolygon))
        {
            // Assign the first hit
            var hitPose = _hits[0].pose;

            // If there are no Objects spawned
            if (_spawnedObject == null)
            {
                // Instantiate the Object at the hitPose
                _spawnedObject = Instantiate(gameObjectToInstantiate,
                    hitPose.position, hitPose.rotation);
                
                // If the object is spawned, disable Animation
                _UIManagerComponent.PlacedObject();
            }
            else
            {
                // If an Object already exists, change its position
                // to the Touch Positon
                _spawnedObject.transform.position = hitPose.position;
            }
            
        }
    }

    /// <summary>
    /// Returns true and assigns TouchPosition if the screen is Tapped
    /// Returns false otherwise 
    /// </summary>
    /// <returns></returns>
    private bool GetTouchPosition(out Vector2 touchPosition)
    {
        // If the Screen is touched
        if (Input.touchCount > 0)
        {
            // Assign the touchPosition
            touchPosition = Input.GetTouch(0).position;
            
            // And return true
            return true;
        }

        // If not, return false
        touchPosition = default;
        return false;
    }
}
