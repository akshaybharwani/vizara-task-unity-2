using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    #region Public Variables

    [Header("Types of Spaces")] 
    public GameObject spaceAR;
    public GameObject space360;

    [Header("Toggle Space Button")] 
    public TextMeshProUGUI toggleSpaceButtonText;

    [Header("Information Panel")] 
    public TextMeshProUGUI spaceName;
    public TextMeshProUGUI informationText;

    #endregion
    
    #region Private Variables

    private bool _isAROn;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // Set SpaceAR as Active in the beginning
        _isAROn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Toggles the Environment between AR and 360
    /// </summary>
    public void ToggleSpaceBasedOnActiveSpace()
    {
        // If SpaceAR is active
        if (_isAROn)
        {
            // Change the Space
            ToggleSpace(false);
            
            // Change the Button Text
            toggleSpaceButtonText.text = "Switch To AR";
            
            // Change Information Text
            informationText.text = "Move Your Device around to Enjoy the 360 Video";
            
            // Change Space Name
            spaceName.text = "360 Video Experience";
        }
        // If SpaceAR is InActive
        else
        {
            // Change the Space
            ToggleSpace(true);
            
            // Change the Button Text
            toggleSpaceButtonText.text = "Switch To 360";
            
            // Change Information Text
            informationText.text = "Tap to Place the Object. Tap & Hold to Move. Use 2 Fingers to Scale Object.";

            // Change Space Name
            spaceName.text = "AR Experience";
        }
    }

    private void ToggleSpace(bool toggleValue)
    {
        _isAROn = toggleValue;
        spaceAR.SetActive(toggleValue);
        space360.SetActive(!toggleValue);
    }
}
