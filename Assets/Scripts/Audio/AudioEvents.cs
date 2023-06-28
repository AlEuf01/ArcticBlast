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

				// Play when music state changes
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

				/// <summary>
				/// Plays the victory music
				/// </summary>
				public static void PlayWin()
				{
						if (OnPlayWin != null)
						{
								OnPlayWin();
						}
				}


				/// <summary>
				/// Plays the lose music
				/// </summary>				
				public static void PlayLose()
				{
						if (OnPlayLose != null)
						{
								OnPlayLose();
						}
				}


				/// <summary>
				/// Plays the main game loop
				/// </summary>
				public static void PlayLoop()
				{
						if (OnPlayLoop != null)
						{
								OnPlayLoop();
						}
				}
		}
	
}
