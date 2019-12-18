using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

namespace ArcticBlast {

	// Player Goal; once the glacier goes past this point, the player wins
    public class Goal : GlacierTrigger
    {

		protected override void EnterPayload() {
			Debug.Log("Entered goal!");
			Events.CompleteLevel();			   
			GameController.Instance.Win();
		}
    }
    
}
