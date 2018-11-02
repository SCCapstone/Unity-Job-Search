using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vr_rotation_simulation : MonoBehaviour {

	// Use this for initialization
    //Comment for expample
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(5, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(-5, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 5, 0);
        }
		
		if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -5, 0);
        }
	}
}
