using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// The part of the glacier that the player can fire on
		/// </summary>
    public class GlacierTarget : MonoBehaviour, IEnemy
    {
				
				// Handles farting on this glacier by the player
				public void FartOn()
				{							
						Melt();
	    
				}

				// Handles mega-farting on this glacier
				public void MegaFartOn()
				{
						Melt(2f);
				}

				// Melt the glacier by the given amount
				void Melt(float scalar = 1f)
				{
						Events.MeltGlacier(scalar);
				}
	
    }
    
}
