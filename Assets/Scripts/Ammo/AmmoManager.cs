using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Ammo {
    
    public static class AmmoManager
    {
		const int maxAmmo = 4;
		
		public static int Amount = 0;		
		
		public static void Add() {
			if (Amount < maxAmmo) {
				Amount++;
			}
		}
	
		public static void Remove() {
			if (Amount > 0) {
				Amount--;
			}
		}
		
		public static bool HasAmmo() {
			return Amount > 0;
		}

		public static bool HasMegaFartAmmo() {
			return Amount == maxAmmo;
		}
		
		public static void RemoveAllAmmo() {
			Amount = 0;
		}

		// Fill the ammo to max after consuming a bean barrel
		public static void Fill() {
			Amount = maxAmmo;
		}

	}
}
