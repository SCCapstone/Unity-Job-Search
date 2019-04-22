using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTest : MonoBehaviour
{

    public Button sceneChange;

    // Use this for initialization
    void Start()
    {
        Button btn = sceneChange.GetComponent<Button>();
        btn.onClick.AddListener(buttonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonClick()
    {
        Debug.Log("Button Clicked! Changing scenes...");
        Scene newScene = SceneManager.CreateScene("MainMenu");
        SceneManager.SetActiveScene(newScene);
        Debug.Log("New Scene: " + SceneManager.GetActiveScene().name);
    }
}