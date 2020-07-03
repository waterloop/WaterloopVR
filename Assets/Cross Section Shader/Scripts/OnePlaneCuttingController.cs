using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingController : MonoBehaviour {

    public GameObject plane;
    public Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Renderer rend;
    double i = 0;
    Component[] frame;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        normal = plane.transform.TransformVector(new Vector3(0,0,-1));
        position = plane.transform.position;
        frame = GameObject.FindGameObjectWithTag("Frame").GetComponentsInChildren<Renderer>();
        foreach(Renderer x in frame){
            x.material = mat;

        }
        UpdateShaderProperties();
    }
    void Update ()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties(){
        //mat.SetVector("PlanePosition", new Vector4(0, 1, 0, 0));
        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;
        rend.material.SetVector("_PlaneNormal", normal);
        if (Input.GetKey("up")){
            
            i += 0.05;
        }
        else if (Input.GetKey("down"))
        {
           
            i -= 0.05;
        }
        rend.material.SetVector("_PlanePosition", new Vector4(0, (float)i, 0, 0));
    }
}
