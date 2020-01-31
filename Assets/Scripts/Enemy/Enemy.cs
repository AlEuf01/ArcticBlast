﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

    
    public class Enemy : Character, IEnemy
    {
	
	const float HIT_DISTANCE = 0.2f;
	const float JUMP_HIT_DISTANCE = 0.8f;
	
        public bool CanBeStunned = true;
	
	public LayerMask layerMask;
	
	public bool isStunned = false;
	public bool isAttacking;
	
	public float stunDuration = 3.0f;		
	
	public void FartOn() {
	    Stun();
	}
	
	public void MegaFartOn() {
	    // Stun();
	    Die();
	}
	
	void FixedUpdate() {
	    CheckCollisions();
	}
	
	void OnCollisionEnter2D(Collision2D col) {
	    if (!isStunned && col.gameObject.tag == "Player") {
		StartCoroutine(Attack());
	    }
	}

	IEnumerator Attack() {
	    isAttacking = true;
	    
	    animator.SetTrigger("Attack");

	    // TODO: Play Sound Effect

	    // TODO: Stun, don't kill, the player
	    Events.KillPlayer();

	    yield return new WaitForSeconds(0.2f);
	    
	    isAttacking = false;
	}
	
	void Stun() {
	    if (CanBeStunned) {
		// Debug.Log("Stunning enemy.");
		StartCoroutine(StunForDuration(stunDuration));				
	    }
	}

	void Die() {
	    // TODO: Play sound effects
	    AudioController.PlayKick();
	    
	    // TODO: Play animation
	    
	    // Dead
	    Destroy(gameObject);
	}
	
	
	IEnumerator StunForDuration(float duration) {
	    isStunned = true;

	    animator.SetTrigger("Stun");

	    // rb.simulated = false;
	    
	    yield return new WaitForSeconds(duration);
	    // rb.simulated = true;

	    isStunned = false;
	}
	
	void CheckCollisions() {
	    
	    // Check to see if the player jumped on me
	    if (CheckCollisionWithPlayer(Vector2.up, JUMP_HIT_DISTANCE)) {
		HandleJumpCollision();
	    }
	    
	    // Debug.Log("Checking collisions to left and right.");
	}
	
	// Check collision in a certain direction
	bool CheckCollisionWithPlayer(Vector2 dir, float distance) {
	    RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance, layerMask);
	    return hit.collider != null && hit.collider.gameObject.tag == "Player";
	}
	
	// Handle the player jumping on this enemy
	void HandleJumpCollision() {
	    if (isStunned) {
		Die();
	    } else {
		Events.KillPlayer();
	    }
	}
	

    }
}


