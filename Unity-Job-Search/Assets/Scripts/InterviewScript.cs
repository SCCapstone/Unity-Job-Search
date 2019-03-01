using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewScript : MonoBehaviour {

    /* Y POSITIONS TO SET THE INTERVIEW WORLD CANVAS TO SO THAT THE RIGHT OPTIONS ARE VISABLE TO THE PLAYER AT THE RIGHT TIME
     * Y = 45 (before they start the interview, default, out of view)
     * Y = 10 (once they start the interview, displays the options for the first dialogue)
     * Y = -40 (change to this after they click the good option for the previous question, displays options for the second dialogue)
     * Y = -90 (change to this after they click the good option for the previous question, displays options for the third dialogue)
     * Y = -140 (Change canvas to this if they click the good option, displays the options for the last dialogue)
     * 
     *  if they at any time click the bad option, set the interview canvas Y to 45 again and play the MissionFailed.mp3 in the audio folder.
     *  
     *  When they click the good option, play the audio that corresponding audio file listed in the flow chart in discord, then slide the canvas down.
     */

    ///Might not even have to include these exactly. probably only need the Canvas itself, 
    ///and then when the laser is pointing at a collider, get it's object's name, something like [hit.collider.gameObject.name == "HardWorkerOption"]
    ///gonna include them just incase we need them later on.

    public GameObject InterviewCanvas;

    //Do you have time for an interview? Q1
    //public GameObject acceptInterview;
    //public GameObject declineInterview; // jump to missionFailed.mp3
    public GameObject q1Options;


    //How would you describe yourself? Q2
    //public GameObject partyAnimal; // jump to missionFailed.mp3
    //public GameObject hardWorker;
    public GameObject q2Options;


    //Whats your work ethic like? Q3
    //public GameObject dedicated;
    //public GameObject procrastinate; // jump to missionFailed.mp3
    public GameObject q3Options;

    //Would you be open to going through training first?
    //public GameObject yesToTraining;
    //public GameObject noToTraining; // jump to missionFailed.mp3
    public GameObject q4Options;

    // audio not included yet, can probably include/play them here or somewhere else

    // Use this for initialization
    void Start () {
		//should probably set the canvas Y to 45 here
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
