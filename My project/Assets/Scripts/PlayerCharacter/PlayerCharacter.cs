using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // determines how fast the player moves
    public float movementSpeed = 3;

    // determines how far the player's shots travel
    public float range = 7;

    // determines how fast the camera is rotated with q and e
    public float rotateSpeed = 2;

    private Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        // initialize player's position to middle of start room
        transform.position = new Vector3(0, 0, 0);

        playerBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //reads the x and y input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float rotateInput = Input.GetAxis("Rotation");

        Vector3 currentVelocity = (transform.up * y) + (transform.right * x);


            playerBody.velocity = ((new Vector2(currentVelocity.x, currentVelocity.y)).normalized * movementSpeed);
            transform.eulerAngles += new Vector3(0, 0, rotateSpeed * rotateInput);
        

        
        
    }
}
