using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>
		/// Goal.cs
		///
		/// Player Goal; once the glacier goes past this point, the player wins
		/// </summary>
    public class Goal : GlacierTrigger
    {

				protected override void ExitPayload()
				{
						// Debug.Log("Entered goal!");
						Events.CompleteLevel();
				}
    }
    
}
