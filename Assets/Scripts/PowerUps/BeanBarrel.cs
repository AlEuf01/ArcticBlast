using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// BeanBarrel.cs
		/// </summary>
		public class BeanBarrel : PowerUp
		{
		
				// Handle special effects
				protected override void PowerUpEffects()
				{
			
						base.PowerUpEffects();
			
						// TODO: Visual Effects
				}
		
				// Handle in-game actions
				protected override void PowerUpPayload()
				{
						base.PowerUpPayload();
			
						Events.ConsumeBeanBarrel();
				}
		}
	
}
