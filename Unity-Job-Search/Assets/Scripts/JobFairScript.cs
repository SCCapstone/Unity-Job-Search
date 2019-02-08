using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaticPlayerScript : MonoBehaviour
{
    public Vector2 joystick;
    public float speed;
    public GameObject centerEyeAnchor;
    public GameObject cameraRig;
    public GameObject oculusGoRemote;
    public GameObject outsideToInside;
    public GameObject outsideToDorm;
    public GameObject insideToOutside;
    public GameObject insideToFrontDesk;
    public GameObject frontDeskToInside;
    public GameObject frontDeskGO;
    public GameObject ccFrontToBack;
    public GameObject ccFrontToDorm;
    public GameObject ccBackToFront;
  

    void HandleGyroController()
    {
        oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "CCFrontToBack")
            {       
                frontDeskToInside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("CareerCenterBack");
                }
            }
            if (hit.collider.gameObject.name == "CCFrontToDorm")
            {
                frontDeskToInside.GetComponent<MeshRenderer>().enabled = true; 
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "CCBackToFront")
            {
                frontDeskToInside.GetComponent<MeshRenderer>().enabled = true; 
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }
        }
    }

    void Update()
    {
        HandleGyroController();

    }
}
