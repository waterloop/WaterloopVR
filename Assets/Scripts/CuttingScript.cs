using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class CuttingScript : MonoBehaviour{

    public GameObject plane;
    public Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Renderer rend;
    Renderer[] pod;
    double i = 10;
    // Use this for initialization
    void Start() {
        Debug.Log("Starting fun script");
        rend = GetComponent<Renderer>();
        normal = plane.transform.TransformVector(new Vector3(0, 0, -5));
        position = plane.transform.position;
        pod = GameObject.FindGameObjectWithTag("uniqueTag").GetComponentsInChildren<Renderer>();
        foreach (Renderer x in pod) {
            x.material = mat;
        }
        UpdateShaderProperties();
    }
    void Update() {

        UpdateShaderProperties();
    }

    private void UpdateShaderProperties() {
        // normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        // position = plane.transform.position;
        normal = new Vector3(0, 0, -1);
        position = new Vector3(0, 0, (float)i);


        if (Input.GetKey("up")) {
            Debug.Log("i: " + i);
            i += 0.05;
        } else if (Input.GetKey("down")) {
            Debug.Log("i: " + i);
            i -= 0.05;
        }
        foreach (Renderer r in pod) {
            r.material.SetVector("_PlanePosition", position);
            r.material.SetVector("_PlaneNormal", normal);
        }
    }
}