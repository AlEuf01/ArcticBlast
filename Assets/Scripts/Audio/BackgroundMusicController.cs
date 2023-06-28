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

				public AudioClip winClip;
				public AudioClip loseClip;
				public AudioClip loopClip;
				
				void OnEnable()
				{
						AudioEvents.OnPlayWin += PlayWin;
						AudioEvents.OnPlayLose += PlayLose;
						AudioEvents.OnPlayLoop += PlayLoop;
						Events.OnPause += Pause;
						Events.OnUnPause += UnPause;
				}
		
				void OnDisable()
				{
						
						AudioEvents.OnPlayWin -= PlayWin;
						AudioEvents.OnPlayLose -= PlayLose;
						AudioEvents.OnPlayLoop -= PlayLoop;
						Events.OnPause -= Pause;
						Events.OnUnPause -= UnPause;
				}

				/// <summary>
				/// Plays a new music clip
				/// </summary>
				public void PlayMusic(AudioClip clip)
				{
						if (!IsPlaying(clip))
						{
								PlayClip(clip);
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

				/// <summary>
				/// Play a music clip after winning
				/// </summary>
				void PlayWin()
				{
						PlayMusic(winClip);
				}
				
				/// <summary>
				/// Play looping background music
				/// </summary>
				void PlayLoop()
				{
						PlayMusic(loopClip);
				}
				
				/// <summary>
				/// Play a music clip after losing
				/// </summary>
				void PlayLose()
				{
						PlayMusic(loseClip);
				}
				
		}
		
}


