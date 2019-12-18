using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Environment {

    // Cleans up extra powerups if unused
    public class GarbageCollector : MonoBehaviour
    {

		float delayLength = 1.0f;
		
		void OnTriggerEnter2D(Collider2D other) {
			
			if (other.gameObject.tag == "PowerUp") {
				// Debug.Log("Destroying powerup.");
				Destroy(other.gameObject, delayLength);

			}
		}

    }
    
}
