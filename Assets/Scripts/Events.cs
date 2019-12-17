using System;
using UnityEngine;
using Cyborg.Audio;

namespace ArcticBlast {
    
    // Class to handle all events for the game
    public class Events
    {
		
		// Event handler for completing a level
		public static event Action OnCompleteLevel;
		
		// Event handler for killing the player
		public static event Action OnKillPlayer;
		
		// Event handler for consuming a power-up
		public static event Action OnConsumeBeanCan;
		public static event Action OnConsumeBeanBarrel;
		
		// Event handler for firing (fart, flamethrower)
		public static event Action OnFart;
		public static event Action OnMegaFart;

		public static event Action OnPause;
		public static event Action OnUnPause;

		public static void Pause() {
			AudioEvents.Pause();
            if (OnPause != null) {
                 OnPause();  
            }			
		}

		public static void UnPause() {
			AudioEvents.UnPause();
            if (OnUnPause != null) {
                OnUnPause();    
            }
			
		}
		
		public static void CompleteLevel() {
			if (OnCompleteLevel != null) {
				OnCompleteLevel();
			}
		}
		
		public static void KillPlayer() {
			if (OnKillPlayer != null) {
				OnKillPlayer();
			}
		}
		
		public static void ConsumeBeanCan() {
			if (OnConsumeBeanCan != null) {
				OnConsumeBeanCan();
			}
		}

		public static void ConsumeBeanBarrel() {
			if (OnConsumeBeanBarrel != null) {
				OnConsumeBeanBarrel();
			}
		}
		
		public static void Fart() {
			if (OnFart != null) {
				OnFart();
			}
		}

		public static void MegaFart() {
			if (OnMegaFart != null) {
				OnMegaFart();
			}
		}
    }
    
}

