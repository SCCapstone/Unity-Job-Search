using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject oculusGoRemote;
    public GameObject centerEyeAnchor;

    void HandleGyroController()
    {
        oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position,oculusGoRemote.transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "StartCard")
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)==1)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            else if (hit.collider.gameObject.nmae == "ExitCard")
            {
                f (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)==1)
                {
                    Application.Quit();
                }
            }
        }
    }

    void Udate()
    {
        HandleGyroController();
    }
}