using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    // Trigger marking the end of the level
    public class EndOfLevel : GlacierTrigger
    {

		protected override void EnterPayload() {
			Events.KillPlayer();
		}
    }
    
}
