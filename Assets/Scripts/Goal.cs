using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

namespace ArcticBlast.Environment {

	// Player Goal; once the glacier goes past this point, the player wins
    public class Goal : GlacierTrigger
    {

		// Returns true if the glacier is "behind" the goal
		bool IsGlacierBehindGoal(Collider2D other) {
			return other.transform.position.x < transform.position.x;
		}
		
		void OnTriggerExit2D(Collider2D other) {
			// Debug.Log("Collider entered.");
			if (IsColliderGlacier(other) && IsGlacierBehindGoal(other)) {
		
				Debug.Log("Glacier pushed past the goal point.");
				Debug.Log("You win!");
				
				Events.CompleteLevel();

				GameController.Instance.Win();
			}
		}
    }
    
}
