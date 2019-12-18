using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Ammo {

	// Manages the player's available ammo
    public class AmmoManager : MonoBehaviour, IAmmoManager
    {

		// Starting amount of ammo
		public static int Amount = 0;		

		// Maximum amounnt of ammo
		private const int maxAmmo = 4;
		
		// Add ammo
		public void Add() {
			if (Amount < maxAmmo) {
				Amount++;
			}
		}

		// Remove ammo
		public void Remove() {
			if (Amount > 0) {
				Amount--;
			}
		}

		// Fill the ammo to max after consuming a bean barrel
		public void Fill() {
			Amount = maxAmmo;
		}

		
		// Gets rid of all of the player's ammo
		public void RemoveAllAmmo() {
			Amount = 0;
		}

		// Returns true if player has ammo; false otherwise
		public bool HasAmmo() {
			return Amount > 0;
		}

		// Returns true if player has enough ammo for a mega-fart
		public bool HasMegaFartAmmo() {
			return Amount == maxAmmo;
		}

	}
}
