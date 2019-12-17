using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcticBlast;

namespace ArcticBlast.Environment {
    
    // Trigger marking the end of the level
    public class EndOfLevel : GlacierTrigger
    {
	
	void OnTriggerEnter2D(Collider2D other) {
	    if (IsColliderGlacier(other)) {
		
		Debug.Log("Glacier reached the end of the level.");
		Events.KillPlayer();
	    }
	}
    }
    
}
