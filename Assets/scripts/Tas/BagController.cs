using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    private float maxWidth;
    public Renderer ren;
    private bool startControl;

    // Start is called before the first frame update
    void Start()
    {
       if(cam == null)
        {
            cam = Camera.main;
        }
        startControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targerWidth = cam.ScreenToWorldPoint(upperCorner);
        float bagWidth = ren.bounds.extents.x;
        maxWidth = targerWidth.x - bagWidth;
    }

    // Update is called once per physics timestep
    void FixedUpdate()
    {
        if (startControl)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
            rb.MovePosition(targetPosition);
        }
           
    }
    public void turnOnControl(bool turnOn)
    {
        startControl = turnOn;
    }
}
