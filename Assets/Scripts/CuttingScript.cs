using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class CuttingScript : MonoBehaviour {

    public GameObject plane;
    public Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Slider slider;
    Renderer[] pod;
    // Use this for initialization
    void Start() {
        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;

        pod = GameObject.FindGameObjectWithTag("uniqueTag").GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in pod) {
            foreach (Material material in renderer.materials) {
                material.shader = Shader.Find("CrossSection/OnePlaneBSP");
                material.SetColor("_CrossColor", material.color);
                material.SetVector("_PlanePosition", position);
                material.SetVector("_PlaneNormal", normal);
            }
        }

        slider.onValueChanged.AddListener(delegate {
            position.z = slider.value;
            plane.transform.position = position;
            UpdatePlane(position, normal);
        });
    }

    void Update() {
    }

    private void UpdatePlane(Vector3 position, Vector3 normal) {
        foreach (Renderer renderer in pod) {
            foreach (Material material in renderer.materials) {
                material.SetVector("_PlanePosition", position);
                material.SetVector("_PlaneNormal", normal);
            }
        }
    }
}
