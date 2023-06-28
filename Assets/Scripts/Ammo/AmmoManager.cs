using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// AmmoManager.cs
    /// Manages the player's available ammo
		/// </summary>
    public class AmmoManager : IAmmoManager
    {
	
				// Starting amount of ammo
				public static int Amount = 0;		
	
				// Maximum amounnt of ammo
				const int MAX = 4;

				// Constructor
				public AmmoManager() {}

				/// <summary>
				/// Add ammo
				/// </summary>
				public void Add()
				{
						if (Amount < MAX)
						{
								Amount++;
						}
				}

				/// <summary>
				/// Remove ammo
				/// </summary>
				public void Remove()
				{
						if (Amount > 0)
						{
								Amount--;
						}
				}
				/// <summary>
				/// Fill the ammo to max after consuming a bean barrel
				/// </summary>
				public void Fill()
				{
						Amount = MAX;
				}

				/// <summary>
				/// Gets rid of all of the player's ammo
				/// </summary>
				public void RemoveAllAmmo()
				{
						Amount = 0;
				}

				/// <summary>
				/// Returns true if player has ammo; false otherwise
				/// </summary>
				public bool HasAmmo()
				{
						return Amount > 0;
				}

				/// <summary>
				/// Returns true if player has enough ammo for a mega-fart
				/// </summary>
				public bool HasMegaFartAmmo()
				{
						return Amount == MAX;
				}
	
    }
}
