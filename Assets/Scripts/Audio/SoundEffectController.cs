using UnityEngine;

namespace ArcticBlast
{
		
		/// <summary>
		/// SoundEffectController.cs
		/// Controller to manage playing sound effects
		/// </summary>
		public class SoundEffectController : SoundController
		{
				
				void OnEnable()
				{
						AudioEvents.OnPlaySound += PlayClip;
				}
		
				void OnDisable()
				{
						AudioEvents.OnPlaySound -= PlayClip;
				}

				/// <summary>
				/// Plays a sound clip with a given name as a oneshot
				/// </summary>
				public void PlayClip(string clipName)
				{
						AudioClip clip = GetClipByName(clipName);
			
						if (clip != null)
						{
								audioSource.PlayOneShot(clip, AudioPreferences.Volume);
						}
				}

		}
	
}

