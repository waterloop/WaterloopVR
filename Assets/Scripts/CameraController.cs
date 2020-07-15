using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject slider;
    float speed = 1f;
    Rigidbody rigidbody;
    SliderController sliderController;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        sliderController = slider.GetComponent<SliderController>();
    }

    void OnGUI() {
        Event e = Event.current;
        if (!sliderController.clicked && e.isMouse) {
            rigidbody.AddTorque(0, speed * e.delta.x, 0);
        }
    }
}
