using UnityEngine;

using Cyborg.Audio;

namespace ArcticBlast {

	// Handle audio events for Arctic Blast
	public class AudioController : MonoBehaviour
	{
		
		void OnEnable() {			
			Events.OnConsumeBeanBarrel += PlayCollect;
			Events.OnConsumeBeanCan += PlayCollect;
			
			Events.OnPause += Pause;
		}
		
		void OnDisable() {
			Events.OnConsumeBeanBarrel -= PlayCollect;
			Events.OnConsumeBeanCan -= PlayCollect;

			Events.OnPause -= Pause;
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
