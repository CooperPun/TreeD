﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;

	/* Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        PlayerRaycast();
	}

    void PlayerMove ()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer ();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump ()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        

    }

    void PlayerRaycast ()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            //Destroy(hit.collider.gameObject);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
            //hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1000);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyMove>().enabled = false;            
        }
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
}
