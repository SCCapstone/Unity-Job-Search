using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorBehavior : MonoBehaviour
{
    public GameObject DoorMenu;
    public Text doorText;
    public AudioSource openAduio;

    public void displayText()
    {
        doorText.text = "Open Door";
    }

    public void hideText()
    {
        doorText.text = "";

    }


    public void openDoorMenu()
    {
        DoorMenu.SetActive(true);
        openAduio.Play(0);
    }
    public void closeDoorMenu()
    {
        DoorMenu.SetActive(false);
    }
}
