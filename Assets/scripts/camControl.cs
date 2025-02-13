using System.Security.Principal;
using UnityEngine;

public class camControl : MonoBehaviour
{
    private float rotationSpeed = 500.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse1))
        {
            camOrbit();
        }
    }

    private void camOrbit()
    {
        if(Input.GetAxis("Mouse Y") !=0 || Input.GetAxis("Mouse X") !=0)
        {
            float verticalInput = Input.GetAxis("Mouse Y")*rotationSpeed *Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, verticalInput);
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }
}
