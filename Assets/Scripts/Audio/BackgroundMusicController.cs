using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>
		/// BackgroundMusicController.cs
		/// Handles background music for the game
		/// </summary>
		public class BackgroundMusicController : SoundController
		{
		
				void OnEnable()
				{
						AudioEvents.OnPlayMusic += PlayMusic;
						AudioEvents.OnPause += Pause;
						AudioEvents.OnUnPause += UnPause;
				}
		
				void OnDisable()
				{
						AudioEvents.OnPlayMusic -= PlayMusic;
						AudioEvents.OnPause -= Pause;
						AudioEvents.OnUnPause -= UnPause;
				}

				/// <summary>
				/// Plays a new music clip
				/// </summary>
				public void PlayMusic(string clipName)
				{
						if (!IsPlaying(clipName))
						{
								PlayClip(GetClipByName(clipName));
						}
				}

				/// <summary>
				/// Pauses the current background track
				/// </summary>
				public void Pause()
				{
						audioSource.Pause();
				}

				/// <summary>
				/// Unpauses the background music
				/// </summary>
				public void UnPause()
				{
						audioSource.UnPause();
				}
}

}


