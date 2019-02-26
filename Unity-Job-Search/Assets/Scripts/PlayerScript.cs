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

    public Canvas myCanvas; // This is MAIN MENU WHEN YOU HIT LAPTOP

    public GameObject laptop;
    public GameObject videoPlayer;
    public StreamVideo handshakePlay;
    public StreamVideo resumePlay;
    public GameObject menu_exit;
    public GameObject handshake_btn;
    public GameObject resume_btn;
    public GameObject play_resumevid;
    public GameObject example1;
    public GameObject example2;

    public Image img1, img2; // Images for the Examples


    void Start()
    {
        myCanvas.enabled = false;
        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
        myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
        img1.enabled = false;
        img2.enabled = false;
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
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
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
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
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

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
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
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //Play.PlayPause();
                    myCanvas.enabled = true;
                    myCanvas.GetComponent<LaptopMenu>().openLaptopMenu();
                    
                }
            }
            if(hit.collider.gameObject.name == "handshake_btn")
            {
                handshakePlay.PlayPause();
                handshake_btn.GetComponent<VRButtonBehavior>().changeColor();
                resume_btn.GetComponent<VRButtonBehavior>().resetColor();
                
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                { 
                    if (handshakePlay.isReady() == true)
                    {
                        
                        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                        handshakePlay.playVideo();
                    }
                }

                
                
            }
            if (hit.collider.gameObject.name == "resume_btn")
            {

                
                resume_btn.GetComponent<VRButtonBehavior>().changeColor();
                handshake_btn.GetComponent<VRButtonBehavior>().resetColor();

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                    myCanvas.GetComponent<LaptopMenu>().openResumeMenu();
                   
                }
               
            }

            if(hit.collider.gameObject.name == "play_resumevid")
            {
                resumePlay.PlayPause();
                play_resumevid.GetComponent<VRButtonBehavior>().changeColor();
                example1.GetComponent<VRButtonBehavior>().resetColor();
                example2.GetComponent<VRButtonBehavior>().resetColor();
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    
                    if (resumePlay.isReady() == true)
                    {
                        myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
                        resumePlay.playVideo();
                    }
                }
            }
            if (hit.collider.gameObject.name == "example1")
            {
                example1.GetComponent<VRButtonBehavior>().changeColor();
                play_resumevid.GetComponent<VRButtonBehavior>().resetColor();
                example2.GetComponent<VRButtonBehavior>().resetColor();
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
                    img1.enabled = true;
                }
            }
            if (hit.collider.gameObject.name == "example2")
            {
                example2.GetComponent<VRButtonBehavior>().changeColor();
                play_resumevid.GetComponent<VRButtonBehavior>().resetColor();
                example1.GetComponent<VRButtonBehavior>().resetColor();
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
                    img2.enabled = true;
                }
            }

            if ((hit.collider.gameObject.name == "menu_exit" && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true) || OVRInput.Get(OVRInput.Button.Back) == true)
            {
                
                myCanvas.enabled = false;
                handshakePlay.video.Stop();
                resumePlay.video.Stop();
                img1.enabled = false;
                img2.enabled = false;
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