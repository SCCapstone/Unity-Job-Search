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
    public GameObject showText;
    public GameObject Textbg;

    public GameObject TEST;
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

    void HandleGyroController()
    {
        //oculusGoRemote.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "outsideToInside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideToInside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Entrance");
                }
            }
            if (hit.collider.gameObject.name == "outsideToDorm")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                outsideToDorm.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "insideToFrontDesk")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideToFrontDesk.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Desk");
                }
            }
            if (hit.collider.gameObject.name == "insideToOutside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideToOutside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Outside_Front");
                }
            }
            if (hit.collider.gameObject.name == "frontDeskToInside")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDeskToInside.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Inside_Front_Entrance");
                }
            }
            //**************************************************************

            if (hit.collider.gameObject.name == "CCFrontToBack")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccFrontToBack.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CareerCenterBack");
                }
            }
            if (hit.collider.gameObject.name == "CCFrontToDorm")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccFrontToDorm.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("Dorm");
                }
            }
            if (hit.collider.gameObject.name == "CCBackToFront")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                ccBackToFront.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CareerCenterFront");
                }
            }


            if (hit.collider.gameObject.name == "frontDeskGO")
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

            // THIS IS THE HOVERABLE TIPS IN EACH SCENE DOWN HERE AND ITS FOR ALL THE SCENES
            /*if (hit.collider.gameObject.name == "Tips")
            {
                showText.SetActive(true);
                Textbg.SetActive(true);
                Debug.Log("WTF");
            }
            else if(!(hit.collider.gameObject.name == "Tips"))
            {
                Debug.Log("FK");
            }*/

        }
    }

    void HoverTips()
    {
        RaycastHit hit;
        //If the pointer hovers over the Tip icons, it will display text, and remove it when they point away
        if (Physics.Raycast(oculusGoRemote.transform.position, oculusGoRemote.transform.forward, out hit))
        {
            if (hit.collider.gameObject.name == "Tips")
            {
                showText.SetActive(true);
                Textbg.SetActive(true);

            }
            
            showText.SetActive(false);
            Textbg.SetActive(false);
            Debug.Log("PRINTING HERE");
                

        }
    }

    void Update()
    {
        //HandlePlayerMovement();
        HandleGyroController();
        HoverTips();
        
    }
}
