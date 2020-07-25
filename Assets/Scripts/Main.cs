using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SubMeshes {
    public MeshRenderer meshRenderer;
    public Vector3 originalPosition;
    public Vector3 explodedPosition;
}

public class Main : MonoBehaviour {

    #region Variables
    public List<SubMeshes> childMeshRenderers;
    bool isInExplodedView = false;
    public float explosionSpeed = 0.1f;
    bool isMoving = false;
    double waitingTime = 0.0f;
    // public Button testBtn;
    public GameObject parent; //Parent of all gameobjects for the pod
    public Transform[] children;
    public GameObject Diago;
    public GameObject wiring;
    public Slider slider;
    public GameObject plane;
    
    int temp = 0;
    #endregion

    #region UnityFunctions

    private void Start() {
        childMeshRenderers = new List<SubMeshes>();
        Diago.GetComponentInChildren<Renderer>().enabled = false;
        // testBtn = testBtn.GetComponent<Button>();
        // testBtn.onClick.AddListener(sendOutput);
       //
        foreach (var item in GetComponentsInChildren<MeshRenderer>()) {
            SubMeshes mesh = new SubMeshes();
            mesh.meshRenderer = item;
            mesh.originalPosition = item.transform.position;
            mesh.explodedPosition = item.bounds.center * 1.7f;
            childMeshRenderers.Add(mesh);
        }
    }
    // public void sendOutput() {
    //     // Debug.Log("Button has been pressed");
    //     // testBtn.GetComponent<Button>().gameObject.SetActive(false);
    //     foreach (Transform Obj in children) {
    //         Obj.gameObject.SetActive(false);
    //     }
    // }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("up")) {
            waitingTime += Time.deltaTime;
            Debug.Log("Up arrow key pressed for: " + waitingTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            if (Diago.GetComponentInChildren<Renderer>().enabled) {
                Diago.GetComponentInChildren<Renderer>().enabled = false;
            } else {
                Diago.GetComponentInChildren<Renderer>().enabled = true;
            }
        }

        if (waitingTime > 0.1) {
            ToggleExplodedView();
            // testBtn.GetComponent<Button>().gameObject.SetActive(true);
            waitingTime = 0.0f;
        }
        if (isMoving) {
            if (isInExplodedView) {
                wiring.SetActive(false);
                foreach (var item in childMeshRenderers) {
                    item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.explodedPosition, explosionSpeed);
                    if (Vector3.Distance(item.meshRenderer.transform.position, item.explodedPosition) < 0.001f) {
                        isMoving = false;
                    }
                }
                plane.transform.localScale = Vector3.Lerp(plane.transform.localScale, new Vector3(13f, 15f, 1f), explosionSpeed);
            } else {
                foreach (var item in childMeshRenderers) {
                    item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.originalPosition, explosionSpeed);
                    if (Vector3.Distance(item.meshRenderer.transform.position, item.originalPosition) < 0.001f) {
                        isMoving = false;
                        wiring.SetActive(true);
                    }
                }
                plane.transform.localScale = Vector3.Lerp(plane.transform.localScale, new Vector3(6f, 6f, 1f), explosionSpeed);
            }
        }
    }
    #endregion

    #region CustomFunctions

    public void ToggleExplodedView() {
        if (isInExplodedView) {
            isInExplodedView = false;
            isMoving = true;
            slider.value = 10;
            slider.maxValue = 37;
        } else {
            isInExplodedView = true;
            isMoving = true;
            slider.value = 10;
            slider.maxValue = 71;
        }
    }
    #endregion
}
