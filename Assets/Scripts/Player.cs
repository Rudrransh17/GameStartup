using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    private bool jumpKeyWasPressed;
    private bool leftKeyWasPressed;
    private bool rightKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space key is pressed
        //if (Input.GetKeyDown(KeyCode.Space) == true)
        //{
        //  jumpKeyWasPressed = true;
        //}

        //horizontalInput = Input.GetAxis("Horizontal");

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void JumpButtonPressed() 
    {
        jumpKeyWasPressed = true;
    }

    public void LeftButtonPressed()
    {
        leftKeyWasPressed = true;
        FixedUpdate();
    }

    public void LeftButtonReleased()
    {
        leftKeyWasPressed = false;
    }

    public void RightButtonPressed()
    {
        rightKeyWasPressed = true;
    }

    public void RightButtonReleased()
    {
        rightKeyWasPressed = false;
    }

    // FixedUpdate is called once every phyiscs update
    private void FixedUpdate()
    {
        //rigidBodyComponent.velocity = new Vector3(horizontalInput*1.5f, rigidBodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f).Length == 1)
        {
            return;
        }
        

        if (leftKeyWasPressed)
        {
            rigidBodyComponent.velocity = new Vector3(-2,rigidBodyComponent.velocity.y,0);
        }
        else
        {
            rigidBodyComponent.velocity = new Vector3(0, rigidBodyComponent.velocity.y, 0);
        }


        if (rightKeyWasPressed)
        {
            rigidBodyComponent.velocity = new Vector3(2, rigidBodyComponent.velocity.y, 0);
        }
        else
        {
            rigidBodyComponent.velocity = new Vector3(0, rigidBodyComponent.velocity.y, 0);
        }


        if (jumpKeyWasPressed) 
        {
            rigidBodyComponent.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }


}
