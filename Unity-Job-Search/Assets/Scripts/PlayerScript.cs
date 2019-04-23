using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    public bool visited_jobfair;

    public GameObject gotMail;
    public GameObject callBack;
    public GameObject marker;
    public GameObject InterviewCanvas;

    public Vector2 joystick;
    public float speed;
    public GameObject centerEyeAnchor;
    public GameObject cameraRig;
    public GameObject oculusGoRemote;
    public Text DisplayText;
    public GameObject Door;

    public GameObject CareerCenterButton;

    public GameObject Swearingen;

    public GameObject FairButton;

    //public GameObject ResumeButton;

    public Canvas myCanvas; // This is MAIN MENU WHEN YOU HIT LAPTOP
    public GameObject tutorial;
    public GameObject devPhoto;
    public GameObject youwin;
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
    public GameObject rawImage;
    // interview questions
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;
    public AudioClip sound;
    public GameObject interviewGoodEnding;
    public GameObject interviewBadEnding;

    private bool isHandshakePlaying;
    private bool isResumeVidPlaying;

    public Image img1, img2; // Images for the Examples

    public GameObject musicPlayer;


    void Start()
    {
        
        Debug.Log(PlayerPrefs.HasKey("Tutorial"));
        if (PlayerPrefs.HasKey("Tutorial") == false)
        {
            tutorial.SetActive(true);
            speed = 0.0f;
        }
        else
        {
            speed = 18.0f;
        }
        myCanvas.enabled = false;
        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
        myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
        img1.enabled = false;
        img2.enabled = false;

        devPhoto.SetActive(false);
        youwin.SetActive(false); 

        q1.active = false;
        q2.active = false;
        q3.active = false;
        q4.active = false;

        musicPlayer.active = false;
    
        visited_jobfair = PlayerPrefs.GetInt("visited_jobfair") == 1 ? true : false;
        if (visited_jobfair == true)
        {
            marker.active = true;
            gotMail.active = true;
            speed = 0.0f;
        }
    }

    void HandlePlayerMovement()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        transform.eulerAngles = new Vector3(0, centerEyeAnchor.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);
        //cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, transform.position, 10f * Time.deltaTime);
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
                Swearingen.GetComponent<VRButtonBehavior>().resetColor();

                
                
                
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
                Swearingen.GetComponent<VRButtonBehavior>().resetColor();
                CareerCenterButton.GetComponent<VRButtonBehavior>().changeColor();
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Button Touched";
                    SceneManager.LoadScene("Outside_Front");
                }
            }

            // Career Fair
            else if (hit.collider.gameObject.name == "JobFair_Button")
            {
                CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();
                FairButton.GetComponent<VRButtonBehavior>().changeColor();
                Swearingen.GetComponent<VRButtonBehavior>().resetColor();
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Button Touched";
                    visited_jobfair = true;  //***This should trigger the laptop to get an email from an employer***
                    PlayerPrefs.SetInt("visited_jobfair", visited_jobfair ? 1 : 0);
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }
            else if (hit.collider.gameObject.name == "Swearingen")
            {
                CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();
                FairButton.GetComponent<VRButtonBehavior>().resetColor();
                Swearingen.GetComponent<VRButtonBehavior>().changeColor();

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                   // DisplayText.text = "Button Touched";
                    SceneManager.LoadScene("CECOutsideFar");
                }
            }
            else
            {
                Door.GetComponent<DoorBehavior>().closeDoorMenu();
                Door.GetComponent<DoorBehavior>().hideText();
                
            }
            if(hit.collider.gameObject.name == "Computer")
            {
         
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    if (visited_jobfair)
                    {
                        //start the interview process
                        marker.active = false;
                        gotMail.active = false;                       
                        q1.active = true;
                        PlayerPrefs.DeleteKey("visited_jobfair");
                    }
                    else
                    {
                        myCanvas.enabled = true;
                        myCanvas.GetComponent<LaptopMenu>().openLaptopMenu(); // handshake
                        laptop.GetComponent<BoxCollider>().enabled = false; // Laptop is computer now btw
                    }
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
                        isHandshakePlaying = handshakePlay.playVideo();
                    }
                }
            }
            if (isHandshakePlaying)
            {
                if (handshakePlay.isDone())
                {
                    Debug.Log("VIDEO DONE!");
                    handshakePlay.video.Stop();
                    myCanvas.enabled = false; // Resetting it
                    myCanvas.enabled = true; // Then enabling it
                    
                    myCanvas.GetComponent<LaptopMenu>().openLaptopMenu();

                }
                else
                {
                    Debug.Log("ERROR?");
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
                        isResumeVidPlaying = resumePlay.playVideo();
                    }
                }
            }
            if (isResumeVidPlaying)
            {
                if (resumePlay.isDone())
                {
                    Debug.Log("VIDEO DONE!");
                    resumePlay.video.Stop();
                    myCanvas.enabled = false; // Resetting it
                    myCanvas.enabled = true; // Then enabling it

                    myCanvas.GetComponent<LaptopMenu>().openResumeMenu();

                }
                else
                {
                    Debug.Log("ERROR?");
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
                    rawImage.GetComponent<RawImage>().color = Color.black;
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
                    rawImage.GetComponent<RawImage>().color = Color.black;
                }
            }

            
                if ((hit.collider.gameObject.name == "menu_exit" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true) || OVRInput.Get(OVRInput.Button.Back) == true)
                {
                    if (img1.enabled || img2.enabled)
                    {
                        img1.enabled = false;
                        img2.enabled = false;
                        rawImage.GetComponent<RawImage>().color = Color.white;
                        myCanvas.enabled = false;
                        myCanvas.enabled = true;
                        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                        myCanvas.GetComponent<LaptopMenu>().openResumeMenu();
                        isHandshakePlaying = false;
                        isResumeVidPlaying = false;
                    }
                    else
                    {
                        myCanvas.enabled = false;
                        myCanvas.GetComponent<LaptopMenu>().closeResumeMenu();
                        myCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                        handshakePlay.video.Stop();
                        resumePlay.video.Stop();
                        isHandshakePlaying = false;
                        isResumeVidPlaying = false;
                        laptop.GetComponent<BoxCollider>().enabled = true;
                        rawImage.GetComponent<RawImage>().color = Color.white;
                        tutorial.SetActive(false);
                        PlayerPrefs.SetInt("Tutorial", 1);
                        speed = 18.0f;
                    }

            }
            if (hit.collider.gameObject.name == "Radio")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    if (musicPlayer.active)
                        musicPlayer.active = false;
                    else if (!musicPlayer.active)
                        musicPlayer.active = true;
                }
            }

            // interview stuff /********************************************************************/
            /***************************************************************************************/

            // Question 1
            if (hit.collider.gameObject.name == "YesOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    q1.active = false;
                    q2.active = true;
                }
            }
            if (hit.collider.gameObject.name == "NoOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {

                    q1.active = false;
                    callBack.active = true;
                    visited_jobfair = false;  //***This should trigger the laptop to get an email from an employer***
                    PlayerPrefs.DeleteKey("visited_jobfair");
                    speed = 18.0f;
                }
            }

            // Question 2

            if (hit.collider.gameObject.name == "HardWorkerOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    q2.active = false;
                    q3.active = true;
                }
            }
            if (hit.collider.gameObject.name == "PartyAnimalOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    q2.active = false;
                    interviewBadEnding.active = true;
                    visited_jobfair = false;
                    PlayerPrefs.DeleteKey("visited_jobfair");
                    speed = 18.0f;
                }
            }

            // Question 3

            if (hit.collider.gameObject.name == "DedicatedOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    q3.active = false;
                    q4.active = true;
                }
            }
            if (hit.collider.gameObject.name == "procrastinateOption")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {

                    q3.active = false;
                    interviewBadEnding.active = true;
                    visited_jobfair = false;
                    PlayerPrefs.DeleteKey("visited_jobfair");
                    speed = 18.0f;
                }
            }

            // Question 4

            if (hit.collider.gameObject.name == "YesToTraining")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    interviewGoodEnding.active = true;
                    visited_jobfair = false;
                    PlayerPrefs.DeleteKey("visited_jobfair");
                    q4.active = false;
                    speed = 18.0f;
                    StartCoroutine(Waiting(10.0f));

                    
                }
            }
            if (hit.collider.gameObject.name == "NoToTraining")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    interviewBadEnding.active = true;
                    q4.active = false;
                    visited_jobfair = false;
                    PlayerPrefs.DeleteKey("visited_jobfair");
                    speed = 18.0f;
                }
            }
        }
    }

    void Update()
    {
        HandlePlayerMovement();
        HandleGyroController();
        
    }

    IEnumerator Waiting(float t)
    {
        yield return new WaitForSeconds(t);
        devPhoto.SetActive(true);
        youwin.SetActive(true);
    }
}