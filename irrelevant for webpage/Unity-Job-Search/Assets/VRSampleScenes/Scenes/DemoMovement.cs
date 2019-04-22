using UnityEngine;

// Tilt the cube using the arrow keys.  When the arrow keys are released
// the cube will be rotated back to the center using Slerp.

public class DemoMovement : MonoBehaviour
{


    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }
    }

}