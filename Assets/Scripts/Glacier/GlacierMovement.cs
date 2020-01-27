using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

    // A fatal collider that chases the player
    public class GlacierMovement : MonoBehaviour
    {
	
	// The movement speed of the glacier
	public float Speed = 1f;
	    
	void FixedUpdate() {
	    
	    // Slide in to the right
	    Slide();
	}
	
	void Slide() {
	    Vector2 amount = new Vector2(Speed * Time.deltaTime, 0f);
	    transform.Translate(amount);
	}
    }
    
}
