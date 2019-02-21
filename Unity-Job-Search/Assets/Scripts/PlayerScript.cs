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

    public Canvas myCanvas;
    public GameObject laptop;
    public GameObject videoPlayer;
    public StreamVideo Play;
    public GameObject menu_exit;
    public GameObject handshake_btn;

    void Start()
    {
        myCanvas.enabled = false;
        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
    }

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
        //oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {

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
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }
            else
            {
                Door.GetComponent<DoorBehavior>().closeDoorMenu();
                Door.GetComponent<DoorBehavior>().hideText();
                
            }

            if(hit.collider.gameObject.name == "laptop")
            {
                if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //Play.PlayPause();
                    myCanvas.enabled = true;
                    myCanvas.GetComponent<LaptopMenu>().openLaptopMenu();
                    
                }
            }
            if(hit.collider.gameObject.name == "handshake_btn")
            {
                Play.PlayPause();
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
                { 
                    if (Play.isReady() == true)
                    {
                        handshake_btn.GetComponent<VRButtonBehavior>().changeColor();
                        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                        Play.playVideo();
                    }
                }
                else
                {
                    handshake_btn.GetComponent<VRButtonBehavior>().resetColor();
                }
                
            }
            if ((hit.collider.gameObject.name == "menu_exit" && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true) || OVRInput.Get(OVRInput.Button.Back) == true)
            {
                
                myCanvas.enabled = false;
                Play.video.Stop();
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