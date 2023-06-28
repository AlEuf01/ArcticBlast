using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// AudioController.cs
		/// Handle audio events for Arctic Blast
		/// </summary>
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
				
				/// <summary>
				/// Play a pause sound effect
				/// </summary>
				void Pause()
				{		   
						AudioEvents.PlaySound("smb_pause");
				}

				/// <summary>
				/// Play a collection (ie, collect powerup) sound effect
				/// </summary>
				void PlayCollect()
				{
						AudioEvents.PlaySound("consume");
				}

				/// <summary>
				/// Play a kick sound effect
				/// </summary>
				public static void PlayKick()
				{
						AudioEvents.PlaySound("smb_kick");
				}

				/// <summary>
				/// Play a music clip after winning
				/// </summary>
				public static void PlayWin()
				{
						AudioEvents.PlayMusic("win");
				}
				
				/// <summary>
				/// Play looping background music
				/// </summary>
				public static void PlayLoop()
				{
						AudioEvents.PlayMusic("loop");
				}
				
				/// <summary>
				/// Play a music clip after losing
				/// </summary>
				public static void PlayLose()
				{
						AudioEvents.PlayMusic("lose");
				}

		}
	
}
