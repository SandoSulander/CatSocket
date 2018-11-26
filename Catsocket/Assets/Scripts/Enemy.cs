using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Animator anim;
    private BoxCollider2D bc2d;
    public int health = 100;

    // public GameObject deathEffect; 

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        bc2d = GetComponent<BoxCollider2D>();
    }


    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
	
	void Die ()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);

    
        anim.SetTrigger("DogeDead");
        FindObjectOfType<AudioManager>().Play("DogeDead");
        bc2d.enabled = false;
        Destroy(gameObject, 1);

        GameControl.instance.BirdScored2();
    }
}
