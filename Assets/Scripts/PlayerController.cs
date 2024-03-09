using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float MouseSensivity;
    public Camera PlayerCamera;
    private float xRotation;
    private float yRotation;
    public bool isJumping;
    private Rigidbody rb;
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
// ------------------------------------
        float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensivity * Time.deltaTime;
// ------------------------------------
        if(Input.GetKey(KeyCode.LeftControl))
        {
            MoveSpeed = 10f;
            isJumping = true;
            Vector3 movement = PlayerCamera.transform.forward * v + PlayerCamera.transform.right * h;
            transform.position += movement;
        }
        else
        {
            MoveSpeed = 7f;
            Vector3 movement = PlayerCamera.transform.forward * v + PlayerCamera.transform.right * h;
            transform.position += movement;
        }

// ------------------------------------
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector3(0, 5, 0);
            isJumping = true;
        }

        
// ------------------------------------
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
// ------------------------------------
        PlayerCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void OnCollisionEnter()
        {
            isJumping = false;
        }

}