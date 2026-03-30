using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    // float xInput;
    // float zInput;
    // float hInput, vInput;
    float moveX;
    float moveZ;
    Rigidbody rb;
    int coinCollected;
    public GameObject winText;
    public FixedJoystick joystick;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // xInput = Input.GetAxis("Horizontal");
        // zInput = Input .GetAxis("Vertical");

        if (transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }

    }

    private void FixedUpdate()
    {
        // 🎮 Keyboard Input
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        // 📱 Joystick Input
        float joystickX = joystick != null ? joystick.Horizontal : 0f;
        float joystickZ = joystick != null ? joystick.Vertical : 0f;

        // Combine input
        float moveX = Mathf.Clamp(keyboardX + joystickX, -1f, 1f);
        float moveZ = Mathf.Clamp(keyboardZ + joystickZ, -1f, 1f);

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);

        // Apply smooth force
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);

        // Get joystick input (ONLY X and Z)
        // moveX = joystick.Horizontal;
        // moveZ = joystick.Vertical;

        // Apply movement using Rigidbody
        // Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;

        // rb.AddForce(movement, ForceMode.Force);


//                  ***====    ====***
        // rb.AddForce(xInput * moveSpeed, 0, zInput * moveSpeed);

        // hInput = joystick.Horizontal * moveSpeed;
        // vInput = joystick.Vertical * moveSpeed;

        // transform.Translate(hInput, vInput, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCollected++;
            other.gameObject.SetActive(false);
        }
        if (coinCollected >= 8)
        {
            //win game
            winText.SetActive(true);
        }
    }
}
