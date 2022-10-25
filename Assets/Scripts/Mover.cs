using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
// Transforms to act as start and end markers for the journey.
public Transform startMarker;
public Transform endMarker;

// Movement speed in units/sec.
public float speed = 1.0F;

// Time when the movement started.
private float startTime;

private Rigidbody2D rd2d;

// Total distance between the markers.
private float journeyLength;

void Start()
     {
     // Keep a note of the time the movement started.
          startTime = Time.time;
            rd2d = GetComponent<Rigidbody2D>();

     // Calculate the journey length.
          journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
     }

// Follows the target position like with a spring
void Update()
     {
     // Distance moved = time * speed.
          float distCovered = (Time.time - startTime) * speed;

     // Fraction of journey completed = current distance divided by total distance.
          float fracJourney = distCovered / journeyLength;

     // Set our position as a fraction of the distance between the markers and pingpong the movement.
          transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));
     }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }

    }
}
