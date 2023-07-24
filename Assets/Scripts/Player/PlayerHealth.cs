using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// PlayerHealth.cs
		/// Keeps track of the player's health (hit points, alive or dead)
		/// </summary>
    public class PlayerHealth : Character
    {
	
				public bool isDead = false;

				public int MaxHP = 3;
				public int CurrentHP = 3;

				PlayerMovement movement;
	
				// Flag to make player immune to damage
				public bool invincible = false;
	
				void OnEnable()
				{
						Events.OnKillPlayer += Die;
						Events.OnHitPlayer += Hit;
						// Events.OnCompleteLevel += Freeze;
				}
	
				void OnDisable()
				{
						Events.OnKillPlayer -= Die;
						Events.OnHitPlayer -= Hit;
						// Events.OnCompleteLevel -= Freeze;
						
				}

				protected override void Start()
				{
						base.Start();
						animator = GetComponent<Animator>();
						movement = GetComponent<PlayerMovement>();
				}
				
				public void Die()
				{
						// Debug.Log("Player should die.");
						if (invincible)
						{
								// Do nothing		  
						}
						else
						{
								invincible = true;
								isDead = true;
								StartCoroutine(PlayerDeath());
						}
				}

				void Hit()
				{
						CurrentHP--;
						if (CurrentHP <= 0)
						{
								Die();
						}
				}

				void Freeze()
				{
						movement.enabled = false;
						rb.isKinematic = true;
						rb.velocity  = Vector2.zero;
						gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
						animator.SetFloat("Speed", 0f);
						collider.enabled = false;
				}

				void StopMovement()
				{
						movement.enabled = false;
						rb.velocity = Vector2.zero;
						gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
						collider.isTrigger = true;
				}
	
				IEnumerator PlayerDeath()
				{		   			

						AudioEvents.PlayLose();
			
						StopMovement();	    

						Debug.Log("Killing player");
						
						animator.SetTrigger("Death");
	    
						yield return new WaitForSeconds(1.0f);
	    
						Events.GameOver();
	    
						// animator.ResetTrigger("Death");
	    
				}
    }
}
