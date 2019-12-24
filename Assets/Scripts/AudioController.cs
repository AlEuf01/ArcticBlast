using UnityEngine;

using Cyborg.Audio;

namespace ArcticBlast {

	// Handle audio events for Arctic Blast
	public class AudioController : MonoBehaviour
	{
		
		void OnEnable() {
			Events.OnFart += PlayFart;
			Events.OnMegaFart += PlayMegaFart;
			
			Events.OnConsumeBeanBarrel += PlayCollect;
			Events.OnConsumeBeanCan += PlayCollect;
			
			Events.OnPause += Pause;
		}
		
		void OnDisable() {
			Events.OnFart -= PlayFart;
			Events.OnMegaFart -= PlayMegaFart;

			Events.OnConsumeBeanBarrel -= PlayCollect;
			Events.OnConsumeBeanCan -= PlayCollect;

			Events.OnPause -= Pause;
		}

		// Play a smaller fire event
		void PlayFart() {
			AudioEvents.PlaySound("fire_small");
		}

		// Play a louder fire event
		void PlayMegaFart() {
			AudioEvents.PlaySound("fire");
		}

		// Play a collection (ie, collect powerup) sound effect
		void PlayCollect() {
			AudioEvents.PlaySound("consume");
		}
		
		// Play a pause sound effect
		void Pause() {		   
			AudioEvents.PlaySound("smb_pause");
		}

		// Play a kick sound effect
		public static void PlayKick() {
			AudioEvents.PlaySound("smb_kick");
		}

		public static void PlayWin() {
			AudioEvents.PlayMusic("win");
		}

		public static void PlayLose() {
			AudioEvents.PlayMusic("lose");					  	  	   }

		public static void PlayLoop() {
			AudioEvents.PlayMusic("loop");
		}
	}
	
}
