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
		

				// Event when pausing the backgorund music
				public static event Action OnPause;

				// Event when unpausing the background music
				public static event Action OnUnPause;

				public static event Action OnPlayWin;
				public static event Action OnPlayLose;
				public static event Action OnPlayLoop;

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

				public static void PlayWin()
				{
						OnPlayWin();
				}

				
				public static void PlayLose()
				{
						OnPlayLose();
				}

				
				public static void PlayLoop()
				{
						OnPlayLoop();
				}
		}
	
}
