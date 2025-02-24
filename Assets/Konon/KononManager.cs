using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KononManager : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float jumpForce = 5f;
    public LayerMask groundMask;
    public float groundCheckDistance = 0.4f;

    private float turnSmoothVelocity;
    

    [SerializeField] private GameObject inventoryUI;
    private bool isOpen = false;



    private void Awake()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleInventory();
        }
        
        

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDirection.normalized * speed * Time.deltaTime);
        }

        
       
    }
    private void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryUI.SetActive(isOpen);

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

    }
}
