using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorTest : MonoBehaviour
{
    public GameObject DoorMenu;
    public bool doorOpened = false;

    


    public void openDoorMenu()
    {
        //DoorMenu.SetActive(true);
        doorOpened = true;
    }
    public void closeDoorMenu()
    {
        doorOpened = false;
        //DoorMenu.SetActive(false);
    }
    public void reset()
    {
        doorOpened = false;
    }
}
