using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaptopMenu : MonoBehaviour
{
    public GameObject Menu; // This it the Main Laptop Menu
    public GameObject Menu2; // This is the Resume Menu
    public Text menuText;
    //public AudioSource openAduio;

    public void displayText()
    {
        menuText.text = "Use Laptop";
    }

    public void hideText()
    {
        menuText.text = "";

    }

    public void openInterview()
    {

    }

    public void closeInterview()
    {

    }

    public void openLaptopMenu()
    {
        Menu.SetActive(true);
        //openAduio.Play(0);
    }
    public void openResumeMenu()
    {
        Menu2.SetActive(true);
        //openAduio.Play(0);
    }
    public void closeLaptopMenu()
    {
        Menu.SetActive(false);
    }
    public void closeResumeMenu()
    {
        Menu2.SetActive(false);
    }
}