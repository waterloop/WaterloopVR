using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {
    public bool toggleIsOn;
    List<Toggle> groupToggles;

    // Start is called before the first frame update
    void Start() {
        groupToggles = new List<Toggle>();
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("GroupToggle")) {
            groupToggles.Add(gameObject.GetComponent<Toggle>());
        }
        GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick() {
        foreach (Toggle toggle in groupToggles) {
            toggle.isOn = toggleIsOn;
        }
    }
}
