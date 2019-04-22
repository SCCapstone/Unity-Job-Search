using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Tests {
    [UnityTest]
    public IEnumerator SwitchingScenesTest() {
        // Currently can't add VR Support to test as there is no Oculus Go Testing Kit on Unity as well as Oculus not providing SDKs. 
        //There are no documentations at the moment on how to link cameras and transforms
        // This test is a simple test that changes scenes as a button is clicked on. Most of our buttons/colliders will change scenes so what this test does is as soon as the button is clicked, it will display the current scene and new scene after button is clicked.

        var currScene = SceneManager.GetActiveScene().name;
        Debug.Log("Current Scene: " + currScene);


        var newSceneButton = new GameObject().AddComponent<Button>();
        var buttonListener = new GameObject().AddComponent<ButtonTest>();

        buttonListener.sceneChange = newSceneButton;
        newSceneButton.onClick.Invoke();
        buttonListener.buttonClick();
        yield return null;
    }

    // Simple Unit Test to tests the Door Behaviour Menu. Currently using these functions to check whether the door is hit when the controller touches the collider. When the controller touches, these funtions are called.
    [UnityTest]
    public IEnumerator DoorBehaviourTest() {
        var newDoor = new GameObject().AddComponent<DoorTest>();
        newDoor.openDoorMenu();
        Assert.AreEqual(true, newDoor.doorOpened);

        newDoor.closeDoorMenu();
        //or
        newDoor.reset();

        Assert.AreNotEqual(true, newDoor.doorOpened);
        
        yield return null;
    }
}
