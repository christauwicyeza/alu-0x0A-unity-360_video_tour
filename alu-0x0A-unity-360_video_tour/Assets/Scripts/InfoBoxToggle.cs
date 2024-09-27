using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInfoBox : MonoBehaviour
{
    public GameObject infoBox;  
    private bool isInfoBoxActive = false;

    void Start()
    {
        infoBox.SetActive(false);
    }

    public void ToggleBox()
    {
        isInfoBoxActive = !isInfoBoxActive;
        infoBox.SetActive(isInfoBoxActive);
    }
}
