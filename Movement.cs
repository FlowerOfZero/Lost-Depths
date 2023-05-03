using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float playerSpeed;

    Controller controls;

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Awake()
    {
        controls = new Controller();

        controls.Gameplay.LR.performed += ctx => moveHorizonal();
        controls.Gameplay.FB.performed += ctx => moveForward();
        controls.Gameplay.UD.performed += ctx => moveVertial();

        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float xInput = controls.Gameplay.LR.ReadValue<float>();

        float zInput = controls.Gameplay.FB.ReadValue<float>();
        float yInput = controls.Gameplay.UD.ReadValue<float>();

        float accelerate = controls.Gameplay.Accelerate.ReadValue<float>();


        if(yInput < 0)
        {
            this.transform.Rotate(new Vector3(0,0,1));
        }
        else if(yInput > 0)
        {
            this.transform.Rotate(new Vector3(0, 0, -1));
        }

        if (zInput < 0)
        {
            this.transform.Rotate(new Vector3(1, 0, 0));
        }
        else if (zInput > 0)
        {
            this.transform.Rotate(new Vector3(-1, 0, 0));
        }

        if (xInput > 0)
        {
            this.transform.Rotate(new Vector3(0, 1, 0));
        }
        else if (xInput < 0)
        {
            this.transform.Rotate(new Vector3(0, -1, 0));
        }

        //this.transform.Translate(cameraRelativeMovement * playerSpeed, Space.World);
        if (accelerate > 0)
        {
            rb.AddForce(gameObject.transform.forward * playerSpeed);
        }
        else if(accelerate < 0)
        {
            rb.AddForce(-gameObject.transform.forward * playerSpeed);
        }
        
        // rb.velocity = new Vector3(xInput * playerSpeed , yInput * playerSpeed, zInput * playerSpeed);
    }

    public void moveHorizonal()
    {
        Debug.Log("Horizontal movement");
    }

    public void moveForward()
    {
        Debug.Log("Accelerate movement");
    }

    public void moveVertial()
    {
        Debug.Log("Vertical movement");
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
