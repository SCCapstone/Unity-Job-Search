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
        // Currently can't add VR Support to test as there is no Oculus Go Testing Kit on Unity as well as Oculus not providing
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

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
