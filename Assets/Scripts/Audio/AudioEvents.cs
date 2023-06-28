using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// AudioEvents.cs
		/// Manages events related to the audio system
		/// </summary>
		public class AudioEvents
		{
		
				// Play a sound effect clip
				public delegate void PlaySoundHandler(string soundClipName);
				public static event PlaySoundHandler OnPlaySound;
				public static event PlaySoundHandler OnPlayMusic;
		
				// Event when pausing the backgorund music
				public static event Action OnPause;

				// Event when unpausing the background music
				public static event Action OnUnPause;

				/// <summary>
				/// Handles playing a sound
				/// <param name="clipName">the name of the clip to playe</param>
				/// </summary>
				public static void PlaySound(string clipName)
				{
						if (OnPlaySound != null) {
								OnPlaySound(clipName);
						}	
				}

				/// <summary>
				/// Handles changing the background music track
				/// <param name="clipName">the name of the clip to playe</param>
				/// </summary>
				public static void PlayMusic(string clipName)
				{
						if (OnPlayMusic != null)
						{
								OnPlayMusic(clipName);
						}
				}

				/// <summary>
				/// Pauses the current music track
				/// </summary>
				public static void Pause()
				{
						if (OnPause != null)
						{
								OnPause();
						}
				}

				
				/// <summary>
				/// Unpauses the current music track
				/// </summary>
				public static void UnPause()
				{
						if (OnUnPause != null)
						{
								OnUnPause();
						}
				}
		
		}
	
}
