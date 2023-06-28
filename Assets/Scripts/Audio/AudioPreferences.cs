using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// Enumerates keys stored in PlayerPrefs
		/// </summary>
		public enum PlayerPrefKeys
		{
					Volume
		}
		
		/// <summary>		
		/// Manages user-defined audio controls
		/// </summary>
		public static class AudioPreferences 
		{
				
				// Audio controls don't start out maxed
				const float DEFAULT_VOLUME = 0.75f;

				/// <summary>
				/// Getter and setter for the overall volume of the game (sound effects and music)
				/// </summary>
				public static float Volume				
				{
						get
						{
								return PlayerPrefs.GetFloat(PlayerPrefKeys.Volume.ToString(), DEFAULT_VOLUME);
						}
						set
						{
								PlayerPrefs.SetFloat(PlayerPrefKeys.Volume.ToString(), value);
						}
				}
		
		}
	
}

