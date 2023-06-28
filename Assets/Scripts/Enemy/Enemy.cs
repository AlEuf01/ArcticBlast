using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

    /// <summary>
		/// Enemy.cs
		/// Attach to human enemies
		/// </summary>
    public class Enemy : Character, IEnemy
    {

				// Distance to check for collisions with the player
				const float HIT_DISTANCE = 0.8f;

				// True if it's possible to stun this enemy, false otherwise
        public bool CanBeStunned = true;

				// The LayerMask to check collisions on
				public LayerMask layerMask;

				// True if the enemy is currently stunned
				public bool isStunned = false;

				// True if the enemy is currently attacking the player
				public bool isAttacking;
	
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

						yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
	    
						isAttacking = false;
				}
	
				void Stun() {
						if (CanBeStunned) {
								// Debug.Log("Stunning enemy.");
								StartCoroutine(StunForDurationOfClip());				
						}
				}

				void Die() {
						// Play sound effects
						Events.EnemyKilled();

						// TODO: Play death animation, then destroy object
						Destroy(gameObject);
				}
	

				/// <summary>
				/// Stun the enemy for the duration of the animatoin clip
				/// </summary>
				IEnumerator StunForDurationOfClip() {
						isStunned = true;

						animator.SetTrigger("Stun");

						// rb.simulated = false;

						float duration = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
						Debug.Log($"Duration of stun: {duration}");
						yield return new WaitForSeconds(duration);
						// rb.simulated = true;

						isStunned = false;
				}
	
				void CheckCollisions() {
	    
						// Check to see if the player jumped on me
						if (CheckCollisionWithPlayer()) {
								HandleJumpCollision();
						}
	    
						// Debug.Log("Checking collisions to left and right.");
				}
	
				// Check collision in a certain direction
				bool CheckCollisionWithPlayer() {
						RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, HIT_DISTANCE, layerMask);
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


