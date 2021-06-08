using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickDeplacement : MonoBehaviour, IPointerDownHandler
{
    public GameObject joystick;
    
    void Start()
    {
        joystick.SetActive(false);
    }

    void Update()
    {
       // joystick.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        joystick.transform.position = eventData.position;
        joystick.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.SetActive(false);
    }
}