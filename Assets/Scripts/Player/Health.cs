using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// Non-programmers only need to look between >>>> and <<<<

    // Most scripts will have a bunch of "Variables" at the top. A variable just like in math is 
    // just a name associated with a value. In this case "startingHealth" is set to 1. Following
    // the variable is a comment that explains what it is used for. These public varaiables will
    // show up in the inspector when you attach this script. If you are ever unsure how a variable
    // is being used just ask! If opening scripts is daunting fear not, you will not be required 
    // to ever look at a script ever again in this class, but we encourage you to experiment!

    public int startingHealth = 1; // This is how much health you have before you die

    // Variables below here are not public and therefore you should not need to worry about them
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< Non-programmers need read no furthur

    int currentHealth; 

    // The Start function is always called once when the game starts or the object is first created
	void Start () {
        currentHealth = startingHealth;
	}

    // This function is public so that other scripts can call it
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {   // In a real game you would probably have a game over screen, instead we disable a handful of things
            gameObject.GetComponent<SpriteRenderer>().enabled = false;  // This turns the player invisible
            gameObject.GetComponent<PlayerMovement>().enabled = false;  // This prevents the player from moving 
            gameObject.GetComponent<BoxCollider2D>().enabled = false;   // This prevents enemies from dying to the player after the game ends

            // "gameObject" is a keyword like "this" in java. It refers to the GameObject that this script is attached to
            // GetComponent<Type>() has a bit of a weird syntax. Inside the <>'s write the class name of the component you want to get 

            // Alternatively for a game over you can just use:
            //Destroy(gameObject);
            // The downside with this line is that many other scripts will have null pointers and throw errors once the player is destroyed (which is technically fine)
        }
    }
}
