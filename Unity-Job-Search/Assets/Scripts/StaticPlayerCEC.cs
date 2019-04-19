using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StaticPlayerCEC : MonoBehaviour
{
    public Vector2 joystick;
    public float speed;
    public GameObject centerEyeAnchor;
    public GameObject cameraRig;
    public GameObject oculusGoRemote;
    public GameObject outsideToDorm;
    public GameObject outsideFarToFrontDoor;
    public GameObject frontDoorToOutsideFar;
    public GameObject frontDoorToInside1;
    public GameObject inside1ToFrontDoor;
    public GameObject inside1ToInside2;
    public GameObject inside2ToInside1;
    public GameObject inside2ToInside3;
    public GameObject inside3ToInside2;
    public GameObject inside3ToInsideDoor;
    public GameObject insideDoorToInside3;
    public GameObject insideDoorToOffice;
    public GameObject officeToInsideDoor;
    public GameObject showText;
    public GameObject Textbg;
    RaycastHit hit;



    public GameObject returnCanvas;
    public GameObject map;
    public RawImage rawImage;
    public GameObject fairtxt;
    public GameObject dormtxt;
    public GameObject darlatxt;
    public GameObject cectxt;

    public GameObject Fair;
    public GameObject Dorm;
    public GameObject Darla;
    public GameObject CEC;
    public GameObject Tips;
    public GameObject tutorial;

    private bool canvasOn;
    //public Text DisplayText;
    //public GameObject Door;

    //public GameObject CareerCenterButton;

    //public GameObject InterviewButton;

    //GameObject FairButton;



    //public GameObject ResumeButton;

    /*
    void HandlePlayerMovement()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        transform.eulerAngles = new Vector3(0, centerEyeAnchor.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);

        cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, transform.position, 10f * Time.deltaTime);
    }
    */
    void Start()
    {
        canvasOn = false;
        if (PlayerPrefs.HasKey("Swearingen") == false)
        {

            tutorial.SetActive(true);
            frontDoorToInside1.SetActive(false);
            outsideToDorm.SetActive(false);
            if (Tips != null) { Tips.SetActive(false); }
        }
    }
    void HandleGyroController()
    {
        //oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
        if (OVRInput.GetDown(OVRInput.Button.Back) == true && canvasOn == false)
        {
            canvasOn = true;
            var sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == "CECOutsideFar")
            {
                tutorial.SetActive(false);
                outsideToDorm.SetActive(false);
                frontDoorToInside1.SetActive(false);
            }
            else if(sceneName == "CECOffice")
            {
                officeToInsideDoor.SetActive(false);
            }
            else if(sceneName == "CECInsideDoor")
            {
                insideDoorToOffice.SetActive(false);
                insideDoorToInside3.SetActive(false);
            }
            else if (sceneName == "CECInside3")
            {
                inside3ToInside2.SetActive(false);
                inside3ToInsideDoor.SetActive(false);
            }
            else if (sceneName == "CECInside2")
            {
                inside2ToInside1.SetActive(false);
                inside2ToInside3.SetActive(false);
                Debug.Log("Success!");
            }
            else if (sceneName == "CECInside1")
            {
                inside1ToFrontDoor.SetActive(false);
                inside1ToInside2.SetActive(false);
            }
            else
            {
                Debug.Log("WTF!");
            }
            if(Tips != null)
            {
                Tips.SetActive(false);
            }
            returnCanvas.SetActive(true);
            returnCanvas.GetComponent<LaptopMenu>().openLaptopMenu();

        }
        else if (canvasOn == true && OVRInput.GetDown(OVRInput.Button.Back) == true)
        {
            canvasOn = false;
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "CECOutsideFar")
            {
                outsideToDorm.SetActive(true);
                frontDoorToInside1.SetActive(true);
            }
            else if (sceneName == "CECOffice")
            {
                officeToInsideDoor.SetActive(true);
            }
            else if (sceneName == "CECInsideDoor")
            {
                insideDoorToOffice.SetActive(true);
                insideDoorToInside3.SetActive(true);
            }
            else if (sceneName == "CECInside3")
            {
                inside3ToInside2.SetActive(true);
                inside3ToInsideDoor.SetActive(true);
            }
            else if (sceneName == "CECInside2")
            {
                inside2ToInside1.SetActive(true);
                inside2ToInside3.SetActive(true);
            }
            else if (sceneName == "CECInside1")
            {
                inside1ToFrontDoor.SetActive(true);
                inside1ToInside2.SetActive(true);
            }
            if (Tips != null)
            {
                Tips.SetActive(true);
            }
            returnCanvas.SetActive(false);
            rawImage.GetComponent<RawImage>().color = Color.white;
            returnCanvas.GetComponent<LaptopMenu>().closeLaptopMenu(); // Although its not really LaptopMenu.. Just using the functionality of it.. just opens menu linked
            map.SetActive(false);
            Fair.SetActive(false);
            Dorm.SetActive(false);
            Darla.SetActive(false);
            CEC.SetActive(false);
            fairtxt.SetActive(false);
            dormtxt.SetActive(false);
            cectxt.SetActive(false);
            darlatxt.SetActive(false);

            
        }

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);
            

            if (hit.collider.gameObject.name == "OutsideToDorm")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideToDorm.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }

            if (hit.collider.gameObject.name == "outsideFarToFrontDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideFarToFrontDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECFrontDoor");
                }
            }
            if (hit.collider.gameObject.name == "frontDoorToOutsideFar")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDoorToOutsideFar.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECOutsideFar");
                }
            }
            if (hit.collider.gameObject.name == "FrontToInside1")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDoorToInside1.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside1");
                }
            }
            if (hit.collider.gameObject.name == "Inside1ToOutside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside1ToFrontDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECOutsideFar");
                }
            }
            //**************************************************************

            if (hit.collider.gameObject.name == "Inside1ToInside2")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside1ToInside2.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside2");
                }
            }
            if (hit.collider.gameObject.name == "Inside2ToInside1")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside2ToInside1.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside1");
                }
            }
            if (hit.collider.gameObject.name == "Inside2ToInside3")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside2ToInside3.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside3");
                }
            }
            if (hit.collider.gameObject.name == "Inside3ToInside2")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside3ToInside2.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside2");
                }
            }
            if (hit.collider.gameObject.name == "Inside3ToInsideDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside3ToInsideDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInsideDoor");
                }
            }
            if (hit.collider.gameObject.name == "InsideDoorToInside3")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideDoorToInside3.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside3");
                }
            }
            if (hit.collider.gameObject.name == "InsideDoorToOffice")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideDoorToOffice.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECOffice");
                }
            }
            if (hit.collider.gameObject.name == "OfficeToInsideDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                officeToInsideDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInsideDoor");
                }
            }

            if ((hit.collider.gameObject.name == "menu_exit" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                PlayerPrefs.SetInt("Swearingen", 1);
                tutorial.SetActive(false);
                frontDoorToInside1.SetActive(true);
                outsideToDorm.SetActive(true);
                if (Tips != null) { Tips.SetActive(true); }
            }
                /*if (hit.collider.gameObject.name == "frontDeskGO")
                {
                    //Door.GetComponent<DoorBehavior>().displayText();
                    frontDeskGO.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                    {
                        //DisplayText.text = "Opened Door";
                        // TODO: add something when interacted with
                    }
                }
                /*
                else if (hit.collider.gameObject.name == "CareerCenter_Button")
                {

                    CareerCenterButton.GetComponent<VRButtonBehavior>().changeColor();
                    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1)
                    {
                        DisplayText.text = "Button Touched";
                        SceneManager.LoadScene("Outside_Front");
                    }
                }
                else
                {
                    Door.GetComponent<DoorBehavior>().hideText();
                    Door.GetComponent<DoorBehavior>().closeDoorMenu();
                    CareerCenterButton.GetComponent<VRButtonBehavior>().resetColor();

                }


                //Debug.DrawLine(oculusGoRemote.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
                //Debug.Log("Did Hit");
                */



                // Below is PauseMenu/Campus Map


                if ((hit.collider.gameObject.name == "Quit_Btn" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                SceneManager.LoadScene("MainMenu");
            }
            if ((hit.collider.gameObject.name == "Map_Btn" && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true))
            {
                returnCanvas.GetComponent<LaptopMenu>().closeLaptopMenu();
                map.SetActive(true);
                rawImage.GetComponent<RawImage>().color = Color.black;
                Fair.SetActive(true);
                Dorm.SetActive(true);
                Darla.SetActive(true);
                //CEC.SetActive(true);
            }
            if(hit.collider.gameObject.name == "Dorm")
            {
                fairtxt.SetActive(false);
                darlatxt.SetActive(false);
                dormtxt.SetActive(true);
                
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "Fair")
            {
                dormtxt.SetActive(false);
                darlatxt.SetActive(false);
                fairtxt.SetActive(true);
                
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    var visited_jobfair = true;  //***This should trigger the laptop to get an email from an employer***
                    PlayerPrefs.SetInt("visited_jobfair", visited_jobfair ? 1 : 0);
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }
            if (hit.collider.gameObject.name == "Darla")
            {
                dormtxt.SetActive(false);
                fairtxt.SetActive(false);
                darlatxt.SetActive(true);

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    SceneManager.LoadScene("Outside_Front");
                }
            }
        }
    }
    void HoverTips()
    {
        //If the pointer hovers over the Tip icons, it will display text, and remove it when they point away

        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "Tips")
            {
                showText.SetActive(true);
                Textbg.SetActive(true);

            }
            else
            {
                showText.SetActive(false);
                Textbg.SetActive(false);
            }


        }

    }
    void Update()
    {
        //HandlePlayerMovement();
        HandleGyroController();
        HoverTips();
        
    }
}
