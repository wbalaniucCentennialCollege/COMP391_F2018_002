using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Variable Declaration
    public float speed = 5.0f;
    public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    // Fixed update increments. Used for physics!
    void FixedUpdate()
    {
        // Read input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Debug.Log("x: " + horiz + ", y: " + vert);

        Vector2 movement = new Vector2(horiz, vert);

        // Move the player
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

        // Restrict the player from leaving the play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, xMin, xMax),  // Restrict the x position to xMin and xMax
            Mathf.Clamp(rBody.position.y, yMin, yMax)); // Restrict the y position to yMin and yMax
    }
}
