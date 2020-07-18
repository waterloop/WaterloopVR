using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject slider;
    public GameObject camera;
    Transform cameraTransform;
    float speed = 1f;
    Rigidbody rigidbody;
    SliderController sliderController;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        sliderController = slider.GetComponent<SliderController>();
        cameraTransform = camera.GetComponent<Transform>();
    }

    void OnGUI() {
        Event e = Event.current;
        if (!sliderController.clicked && e.isMouse) {
            rigidbody.AddTorque(0, speed * e.delta.x, 0);
        }
    }

    void Update() {
        var d = Input.GetAxis("Mouse ScrollWheel");
        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, transform.position, d * speed);
    }
}
