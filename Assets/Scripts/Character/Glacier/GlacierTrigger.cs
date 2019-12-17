using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Environment {
    
    public abstract class GlacierTrigger : MonoBehaviour
    {
	
		// Returns true if the collider is named "Glacier"
		protected static bool IsColliderGlacier(Collider2D other) {
			return other.gameObject.tag == "Glacier";
		}
    }
    
}
