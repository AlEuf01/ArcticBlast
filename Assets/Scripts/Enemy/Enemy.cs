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


				/// <summary> True if it's possible to stun this enemy, false otherwise </summary>
        public bool CanBeStunned = true;

				/// <summary> True if it's possible to kill this enemy, false otherwise </summary>
				public bool CanBeKilled = true;

				// The LayerMask to check collisions on
				public LayerMask layerMask;

				// True if the enemy is currently stunned
				public bool isStunned = false;

				// True if the enemy is currently attacking the player
				public bool isAttacking = false;

				/// <summary>
				/// True if the enemy is dead
				/// </summary>
				public bool isDead = false;

				/// <summary>
				/// Spawned Puke
				/// </summary>
				public GameObject Puke;

				public float attackDuration = 1.0f;

				// The amount of time to stun the player
				public float stunDuration, longPukeDuration, pukeDuration, recoverDuration, deathDelay;

				void OnEnable()
				{
						Events.OnCompleteLevel += Disable;
				}

				void OnDisable()
				{
						Events.OnCompleteLevel -= Disable;
				}

				void Disable()
				{
						gameObject.SetActive(false);
				}
				
				public void FartOn()
				{
						Stun(pukeDuration);
				}
	
				public void MegaFartOn()
				{
						if (CanBeKilled)
						{
								Die();
						}
						else
						{
								Stun(longPukeDuration);
						}
				}

				protected override void Start()
				{
						base.Start();
						Puke.gameObject.SetActive(false);
				}
				
	
				void OnCollisionEnter2D(Collision2D col)
				{
						if (!isStunned && !isDead && col.gameObject.tag == "Player")
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

						Events.HitPlayer();

						gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

						yield return new WaitForSeconds(attackDuration);
	    
						isAttacking = false;
				}
				
				/// <summary>
				/// Stun the enemy
				/// </summary>
				void Stun(float duration)
				{
						if (CanBeStunned && !isDead)
						{
								// Debug.Log("Stunning enemy.");
								StartCoroutine(StunForDurationOfClip(duration));				
						}
				}

				/// <summary>
				/// Kill the enemy
				/// </summary>
				void Die()
				{
						// Play sound effects
						Events.EnemyKilled();

						isDead = true;
						
						animator.SetTrigger("Die");						

						Destroy(gameObject, deathDelay);

				}

				/// <summary>
				/// Stun the enemy for the duration of the animation clip
				/// </summary>
				IEnumerator StunForDurationOfClip(float duration)
				{
						isStunned = true;

						animator.SetTrigger("Stun");

						// rb.simulated = false;

						yield return new WaitForSeconds(stunDuration);

						Puke.SetActive(true);

						yield return new WaitForSeconds(duration);

						animator.SetTrigger("Recover");

						yield return new WaitForSeconds(recoverDuration);

						Puke.SetActive(false);
						
						// rb.simulated = true;

						isStunned = false;
				}
	

    }
}


