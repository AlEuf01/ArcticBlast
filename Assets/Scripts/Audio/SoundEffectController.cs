using UnityEngine;

namespace ArcticBlast
{
		
		/// <summary>
		/// SoundEffectController.cs
		/// Controller to manage playing sound effects
		/// </summary>
		public class SoundEffectController : SoundController
		{
				
				public AudioClip consumeClip;
				public AudioClip kickClip;
				public AudioClip pauseClip;
								
				void OnEnable()
				{
						Events.OnConsumeBeanBarrel += PlayCollect;
						Events.OnConsumeBeanCan += PlayCollect;			
						Events.OnPause += Pause;
						Events.OnEnemyKilled += PlayKick;
				}
		
				void OnDisable()
				{
						Events.OnConsumeBeanBarrel -= PlayCollect;
						Events.OnConsumeBeanCan -= PlayCollect;
						Events.OnPause -= Pause;
						Events.OnEnemyKilled -= PlayKick;
				}				
				
				/// <summary>
				/// Play a pause sound effect
				/// </summary>
				void Pause()
				{
						PlayClip(pauseClip);
				}

				/// <summary>
				/// Play a collection (ie, collect powerup) sound effect
				/// </summary>
				void PlayCollect()
				{
						PlayClip(consumeClip);
				}

				/// <summary>
				/// Play a kick sound effect
				/// </summary>
				void PlayKick()
				{
						PlayClip(kickClip);
				}			 

		}
	
}

