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
		

				// Play when music state changes
				public static event Action OnPlayWin;
				public static event Action OnPlayLose;
				public static event Action OnPlayLoop;


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
