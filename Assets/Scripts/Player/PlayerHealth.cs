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
	}
	
	void OnDisable() {
	    Events.OnKillPlayer -= Die;
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
	
	IEnumerator PlayerDeath() {		   			
	    // Debug.Log("Handling player death");
	    AudioController.PlayLose();
			
	    // Debug.Log("The player is dead!");
	    
	    GetComponent<PlayerMovement>().enabled = false;
	    rb.velocity = Vector2.zero;
	    
	    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
	    collider.isTrigger = true;
	    
	    animator.SetTrigger("Death");
	    
	    yield return new WaitForSeconds(0.2f);
	    
	    Events.GameOver();
	    
	    animator.ResetTrigger("Death");
	    
	}
    }
}
