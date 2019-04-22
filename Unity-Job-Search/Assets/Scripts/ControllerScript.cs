using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    public GameObject go;
    public GameObject empty;

	void Start () {
        empty = new GameObject();
        go = empty;
	}
	
	void Update () {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                if(go != hit.collider.gameObject)
                {
                    go.transform.SendMessage("OnVRExit");
                    go = hit.transform.gameObject;
                    go.transform.SendMessage("OnVREnter");
                    Debug.Log("On VR Raycast Enter");
                }
            }
        }
        else
        {
            if(go != null)
            {
                go.transform.SendMessage("OnVRExit");
                go = empty;
            }
        }
	}
}
