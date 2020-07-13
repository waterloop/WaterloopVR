using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    Toggle toggle;
    GameObject[] gameObjects;
    public string tagName;

    void Start()
    {
        //Fetch the Toggle GameObject
        toggle = GetComponent<Toggle>();
        //tagName = toggle.text; 
        gameObjects = GameObject.FindGameObjectsWithTag(tagName);
        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle toggle)
    {
        foreach (GameObject gameObject in gameObjects) {
            gameObject.SetActive(toggle.isOn);
        }
    }
}
