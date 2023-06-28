using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>    
    /// EndOfLevel.cs
		/// Attach to trigger marking the end of the level. When the glacier enters this point, trigger end of game
		/// </summary>
    public class EndOfLevel : GlacierTrigger
    {

				protected override void EnterPayload()
				{
						Events.KillPlayer();
				}
    }
    
}
