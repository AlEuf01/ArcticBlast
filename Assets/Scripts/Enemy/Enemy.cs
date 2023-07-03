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

				public GameObject Puke;

				// The amount of time to stun the player
				public float stunDuration, pukeDuration, recoverDuration;

				public void FartOn()
				{
						Stun();
				}
	
				public void MegaFartOn()
				{
						// Stun();
						Die();
				}

				protected override void Start()
				{
						base.Start();
						Puke.gameObject.SetActive(false);
				}
					
	
				void FixedUpdate()
				{
						CheckCollisions();
				}
	
				void OnCollisionEnter2D(Collision2D col)
				{
						if (!isStunned && col.gameObject.tag == "Player")
						{
								StartCoroutine(Attack());
						}
				}

				/// <summary>
				/// Play an attack animation
				/// </summary>
				IEnumerator Attack()
				{
						isAttacking = true;
	    
						animator.SetTrigger("Attack");

						// TODO: Play Sound Effect

						// TODO: Stun, don't kill, the player
						Events.KillPlayer();

						yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
	    
						isAttacking = false;
				}

				
				/// <summary>
				/// Stun the enemy
				/// </summary>
				void Stun()
				{
						if (CanBeStunned)
						{
								// Debug.Log("Stunning enemy.");
								StartCoroutine(StunForDurationOfClip());				
						}
				}

				/// <summary>
				/// Kill the enemy
				/// </summary>
				void Die()
				{
						// Play sound effects
						Events.EnemyKilled();

						animator.SetTrigger("Die");						

						// TODO: Play death animation, then destroy object
						// Destroy(gameObject);
				}
	

				/// <summary>
				/// Stun the enemy for the duration of the animation clip
				/// </summary>
				IEnumerator StunForDurationOfClip()
				{
						isStunned = true;

						animator.SetTrigger("Stun");

						// rb.simulated = false;

						yield return new WaitForSeconds(stunDuration);

						Puke.SetActive(true);

						yield return new WaitForSeconds(pukeDuration);

						animator.SetTrigger("Recover");

						yield return new WaitForSeconds(recoverDuration);

						Puke.SetActive(false);
						
						// rb.simulated = true;

						isStunned = false;
				}

				/// <summary>
				/// Check to see if the player jumped on the enemy
				/// </summary>
				void CheckCollisions()
				{	    
						if (CheckCollisionWithPlayer()) {
								HandleJumpCollision();
						}	    				
				}

				/// <summary>
				/// Check collision in a certain direction
				/// </summary>
				bool CheckCollisionWithPlayer()
				{
						RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, HIT_DISTANCE, layerMask);
						return hit.collider != null && hit.collider.gameObject.tag == "Player";
				}

				/// <summary>
				/// Handle the player jumping on this enemy
				/// </summary>
				void HandleJumpCollision()
				{
						if (isStunned)
						{
								Die();
						}
						else
						{
								Events.KillPlayer();
						}
				}
	

    }
}


