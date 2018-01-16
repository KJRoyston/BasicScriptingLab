using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float maxSpeed = 5f;

    [HideInInspector] //This means even though the variable is publice it will not show up in the inspector
    public Vector2 estimatedVelocity; // Used by SniperMovement.cs 
	void Update () // If your movement is dealing with forces/rigidbodies you should do it in fixedUpdate. all physics calculations happen there
    {
        float deltaX = Input.GetAxis("Horizontal"); //To rebind axes and buttons go to Edit>Project Settings>Input
        float deltaY = Input.GetAxis("Vertical"); //Look at the unity script reference for Input to see what else can be done
        Vector2 delta = new Vector2(deltaX, deltaY);

        if (delta.magnitude > 1) // We only want to normalize it if we need to. This means if the player is using a controller with a joystick they can move at slower speeds if they want
        {
            delta.Normalize(); //This prevents the character from moving faster when both directions are pressed. Comment out this line and see for yourself!
        }
        delta = delta * maxSpeed * Time.deltaTime; // Time.deltaTime is how much time has elapsed since the last frame and allows us to convert distance/frame to distance/time (or speed)
        transform.Translate(new Vector3(delta.x, delta.y, 0));  // Use this function instead of setting transform.position directly

        estimatedVelocity = delta/Time.deltaTime;   // We need this for the sniper enemy type. 
        // ^ In a bigger game you wan't to keep all the relevant code as modular and separated as possible. In your game try to find ways around lines like this
    }
}

