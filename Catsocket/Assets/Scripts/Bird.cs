using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;            //Upward force
    public float downForce = -200f;         //Downward force
    public bool isDead = false;            //Has the player collided with a wall?
    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Don't allow control if the charahter has died.
        if (isDead == false && PauseMenu.GameIsPaused == false)
        {
            //Look for input to trigger Up
            if (Input.GetMouseButtonDown(0))
            {
                //...zero out the characters current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the characters some upward force.
                rb2d.AddForce(new Vector2(0, upForce));

                //...tell the animator about it and then...
                anim.SetTrigger("CatFireFinal");
            }

            //Look for input to trigger Down
            else if (Input.GetMouseButtonDown(1))
            {
                //...zero out the characters current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the character some downward force.
                rb2d.AddForce(new Vector2(0, downForce));

                //...tell the animator about it and then...
                anim.SetTrigger("CatFireFinal");
            }


        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        FindObjectOfType<AudioManager>().Play("CatSmash");
        // Zero out the character's velocity
        rb2d.velocity = Vector2.zero;
        // If the bird collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger("CatDieNew");
        //...and tell the game control about it.
        GameControl.instance.BirdDied();
    }

}
