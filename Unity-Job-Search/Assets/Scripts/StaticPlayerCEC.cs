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
            if (hit.collider.gameObject.name == "frontDoorToInside1")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                frontDoorToInside1.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside1");
                }
            }
            if (hit.collider.gameObject.name == "inside1ToFrontDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside1ToFrontDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECFrontDoor");
                }
            }
            //**************************************************************

            if (hit.collider.gameObject.name == "inside1ToInside2")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside1ToInside2.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside2");
                }
            }
            if (hit.collider.gameObject.name == "inside2ToInside1")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside2ToInside1.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside1");
                }
            }
            if (hit.collider.gameObject.name == "inside2ToInside3")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside2ToInside3.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside");
                }
            }
            if (hit.collider.gameObject.name == "inside3ToInside2")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside3ToInside2.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside2");
                }
            }
            if (hit.collider.gameObject.name == "inside3ToInsideDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                inside3ToInsideDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInsideDoor");
                }
            }
            if (hit.collider.gameObject.name == "insideDoorToInside3")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideDoorToInside3.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInside3");
                }
            }
            if (hit.collider.gameObject.name == "insideDoorToOffice")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                insideDoorToOffice.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECOffice");
                }
            }
            if (hit.collider.gameObject.name == "officeToInsideDoor")
            {
                //Door.GetComponent<DoorBehavior>().displayText();
                officeToInsideDoor.GetComponent<MeshRenderer>().enabled = true; // should turn on mesh color when raycasted
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) == true)
                {
                    //DisplayText.text = "Opened Door";
                    SceneManager.LoadScene("CECInsideDoor");
                }
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
        }
    }

    void Update()
    {
        //HandlePlayerMovement();
        HandleGyroController();

    }
}
