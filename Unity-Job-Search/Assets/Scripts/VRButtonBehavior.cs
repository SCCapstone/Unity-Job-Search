using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonBehavior : MonoBehaviour {

    public void changeColor()
    {
        GetComponent<Image>().color = Color.cyan;
    }

    public void resetColor()
    {
        GetComponent<Image>().color = Color.white;

    }

}
