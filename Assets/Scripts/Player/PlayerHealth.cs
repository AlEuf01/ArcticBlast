using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Platformer;

namespace ArcticBlast {

    public class PlayerHealth : Character
    {
	
	public bool isDead = false;
	
	// Flag to make player immune to damage
	bool invincible = false;
	
	void OnEnable() {
	    Events.OnKillPlayer += Die;
	    Events.OnCompleteLevel += Freeze;
	}
	
	void OnDisable() {
	    Events.OnKillPlayer -= Die;
	    Events.OnCompleteLevel -= Freeze;
	}
	
	public void Die() {
	    // Debug.Log("Player should die.");
	    if (invincible) {
		// Do nothing		  
	    } else {
		invincible = true;
		isDead = true;
		StartCoroutine(PlayerDeath());
	    }
	}

	void Freeze() {
	    GetComponent<PlayerMovement>().enabled = false;
	    rb.isKinematic = true;
	    rb.velocity  = Vector2.zero;
	    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
	    transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isWalking", false);
	    collider.enabled = false;
	}

	void StopMovement() {
	    GetComponent<PlayerMovement>().enabled = false;
	    rb.velocity = Vector2.zero;
	    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
	    collider.isTrigger = true;
	}
	
	IEnumerator PlayerDeath() {		   			
	    // Debug.Log("Handling player death");
	    AudioController.PlayLose();
			
	    StopMovement();	    
	    
	    animator.SetTrigger("Death");
	    
	    yield return new WaitForSeconds(0.2f);
	    
	    Events.GameOver();
	    
	    animator.ResetTrigger("Death");
	    
	}
    }
}
