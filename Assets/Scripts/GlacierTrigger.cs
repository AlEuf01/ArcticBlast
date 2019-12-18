using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public abstract class GlacierTrigger : MonoBehaviour
    {

		void OnTriggerEnter2D(Collider2D other) {
			if (IsColliderGlacier(other)) {
				TriggerEntered();
			}
		}
		
		// Returns true if the collider is named "Glacier"
		bool IsColliderGlacier(Collider2D other) {
			return other.gameObject.tag == "Glacier";
		}

		void TriggerEntered() {
			// TODO
			EnterPayload();
		}

		protected virtual void EnterPayload() {
			// Effect when glacier enters trigger
		}

    }
    
}
