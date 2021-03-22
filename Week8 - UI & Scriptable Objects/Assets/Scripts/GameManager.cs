using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LocationScriptableObject currentLocation;

    public Text locationNameText;
    public Text locationDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateLocation();
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.locationNorth;
                break;
            case 1:
                currentLocation = currentLocation.locationSouth;
                break;
        }
        
        UpdateLocation();
    }

    void UpdateLocation()
    {
        locationNameText.text = currentLocation.locationName;
        locationDescription.text = currentLocation.description;
    }

}
