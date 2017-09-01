﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool walled;

    private bool notatEdge;
    public Transform edgeCheck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        walled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notatEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (walled || !notatEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
            
    }
}
