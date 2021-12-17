using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private float speed = 5.0f;
    [SerializeField] private float horsePower = .0f;
    [SerializeField] private int speed;
    [SerializeField] private float rpm;
    private const float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedmeterText;
    [SerializeField] private TextMeshProUGUI rpmText;

    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        if (IsOnGround())
        {
            // Input
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // Moves the car forward based on vertical input
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedmeterText.SetText("Speed: " + speed + "kph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) wheelsOnGround++;
        }

        return (wheelsOnGround == allWheels.Count);
    }
}
