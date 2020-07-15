using UnityEngine;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public bool clicked = false;
    public void OnPointerDown(PointerEventData eventData) {
        clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        clicked = false;
    }
}
