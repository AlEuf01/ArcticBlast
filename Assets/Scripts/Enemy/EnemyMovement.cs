using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {


    public enum Direction {
	Left,
	Right
    }
    
    public class EnemyMovement : Character
    {
	
	// The movement speed
	public float Speed = 1f;
	
	private GameObject player;
	
	private bool isStunned {
	    get {
		return GetComponent<Enemy>().isStunned;
	    }
	}
		
	protected override void Start() {
	    base.Start();
	    
	    // Get the player
	    player = GameObject.FindWithTag("Player");
	}
	
	void FixedUpdate() {
	    // Chase the player;
	    
	    if (player != null && sr != null && player.GetComponent<PlayerHealth>().isDead == false) {
		if (!isStunned) {
		    Chase();
		}
		
		UpdateAnimator();	    						
	    } else {
		// Player is dead; be still
		animator.SetBool("IsWalking", false);
	    }
	    
	}
	
	void Chase() {
	    
	    Vector2 amount = new Vector2(Speed * Time.deltaTime, 0f);
		
	    if (!IsPlayerAhead()) {
		sr.flipX = true;
		amount = -amount;
	    } else {
		sr.flipX = false;
	    }
		
	    transform.Translate(amount);
	}
	
	// Returns true if the player is ahead of the enemy; false if behind
	bool IsPlayerAhead() {
		
	    return player.transform.position.x > transform.position.x;
	}
	
	void UpdateAnimator() {
	    // TODO: Idle if player is out of range
	    if (isStunned) {
		animator.SetBool("IsWalking", false);
	    } else {
		animator.SetBool("IsWalking", true);
	    }
		
	}
	
	
    }
	
}
