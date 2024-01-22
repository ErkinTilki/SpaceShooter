using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;

    void Start()
    {
        
    }

    void OnEnable() {

    movement.Enable();    

    }
    void Disable() {

    movement.Disable();    

    }

    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        
        float  rawXPos = transform.localPosition.x + xOffset;
        float  clampedXPos = Mathf.Clamp(rawXPos, -xRange,xRange);

        float  rawYPos = transform.localPosition.y + yOffset;
        float  clampedYPos = Mathf.Clamp(rawYPos, -yRange,yRange);

        transform.localPosition = new Vector3 (clampedXPos,clampedYPos,transform.localPosition.z);
    }
}
