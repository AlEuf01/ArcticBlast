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
		}
		
		void OnDisable() {
			Events.OnFart -= PlayFart;
			Events.OnMegaFart -= PlayMegaFart;

			Events.OnConsumeBeanBarrel -= PlayCollect;
			Events.OnConsumeBeanCan -= PlayCollect;
		}
		
		void PlayFart() {
			AudioEvents.PlaySound("fire_small");
		}
		
		void PlayMegaFart() {
			AudioEvents.PlaySound("fire");
		}
		
		void PlayCollect() {
			AudioEvents.PlaySound("consume");
		}

		
		public static void PlayKick() {
			AudioEvents.PlaySound("smb_kick");
		}
		
		public static void Pause() {		   
			AudioEvents.PlaySound("smb_pause");
			AudioEvents.Pause();
		}


		public static void PlayWin() {
			AudioEvents.PlayMusic("win");
		}

		public static void PlayLose() {
			AudioEvents.PlayMusic("lose");								  
		}

		public static void PlayLoop() {
			AudioEvents.PlayMusic("loop");
		}
	}
	
}
