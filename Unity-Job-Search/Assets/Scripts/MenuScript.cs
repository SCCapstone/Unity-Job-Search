using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject oculusGoRemote;
    public GameObject centerEyeAnchor;
    public Vector2 joystick;
    public float speed;
    public GameObject cameraRig;

    public GameObject StartCard;
    public GameObject ExitCard;

    void HandlePlayerMovement()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        transform.eulerAngles = new Vector3(0, centerEyeAnchor.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);

        cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, transform.position, 10f * Time.deltaTime);
    }

    void HandleGyroController()
    {
        oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "StartCard")
            {
                StartCard.GetComponent<VRButtonBehavior>().changeColor();
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            else if (hit.collider.gameObject.name == "ExitCard")
            {
                ExitCard.GetComponent<VRButtonBehavior>().changeColor();
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1)
                {
                    Application.Quit();
                }
            }
        }
    }

    void Update()
    {
        HandleGyroController();
        HandlePlayerMovement();
    }
}
