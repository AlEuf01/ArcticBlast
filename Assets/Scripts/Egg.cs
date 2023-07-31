using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>    
    /// EndOfLevel.cs
		/// Attach to trigger marking the end of the level. When the glacier enters this point, trigger end of game
		/// </summary>
    public class Egg : GlacierTrigger
    {

				public Animator animator;

				void OnEnable()
				{
						Events.OnCompleteLevel += Hatch;
				}

				void OnDisable()
				{
						Events.OnCompleteLevel -= Hatch;
				}
				
				protected override void EnterPayload()
				{
						Events.KillPlayer();
				}

				void Hatch()
				{
						animator.SetBool("Hatching", true);
				
				}
    }
    
}
