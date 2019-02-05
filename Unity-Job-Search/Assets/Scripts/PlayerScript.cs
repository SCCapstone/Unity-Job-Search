using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Vector2 joystick;
    public float speed;
    public GameObject centerEyeAnchor;
    public GameObject cameraRig;
    public GameObject oculusGoRemote;
    public Text DisplayText;
    public GameObject Door;

    public GameObject CareerCenterButton;

    public GameObject InterviewButton;

    public GameObject FairButton;

    //public GameObject ResumeButton;


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

            if (hit.collider.gameObject.name == "door")
            {
                Door.GetComponent<DoorBehavior>().displayText();
                CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();
                FairButton.GetComponent<VRButtonBehavior>().resetColor();
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    Door.GetComponent<DoorBehavior>().openDoorMenu();
                }
            }
            // Career Center
            else if (hit.collider.gameObject.name == "CareerCenter_Button")
            {
                FairButton.GetComponent<VRButtonBehavior>().resetColor();
                CareerCenterButton.GetComponent<VRButtonBehavior>().changeColor();
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    DisplayText.text = "Button Touched";
                    SceneManager.LoadScene("Outside_Front");
                }
            }

            // Career Fair
            else if (hit.collider.gameObject.name == "JobFair_Button")
            {
                CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();
                FairButton.GetComponent<VRButtonBehavior>().changeColor();

                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    DisplayText.text = "Button Touched";
                    SceneManager.LoadScene("emptyScene");
                }
            }
            else
            {
                Door.GetComponent<DoorBehavior>().closeDoorMenu();
                Door.GetComponent<DoorBehavior>().hideText();
                
            }
           


            //Debug.DrawLine(oculusGoRemote.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
            //Debug.Log("Did Hit");
        }
    }

    void Update()
    {
        HandlePlayerMovement();
        HandleGyroController();

    }
}