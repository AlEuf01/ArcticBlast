using System;
using UnityEngine;

namespace ArcticBlast
{
		
		/// <summary>
		/// SoundController.cs
		/// System sound controller
		/// </summary>		
		[RequireComponent(typeof(AudioSource))]
		public abstract class SoundController : MonoBehaviour
		{
				// Store a list of clips in this controller
				public AudioClip[] clips;
		
				// The attached audio source that plays this clip
				protected AudioSource audioSource;
		
				void Start()
				{
						audioSource = GetComponent<AudioSource>();
				}

				/// <summary>
				/// Queue the provided clip in the attached audio source and plays it
				/// </summary>
				protected void PlayClip(AudioClip clip)
				{		 
						if (clip != null)
						{		   
								audioSource.clip = clip;
								Play();  
						}
				}
				/// <summary>
				/// Play the audio source
				/// </summary>
				void Play()
				{
						audioSource.Play();
				}
				
				/// <summary>
				/// Get the audio clip from the array of clips by name
				/// </summary>
				protected AudioClip GetClipByName(string clipName)
				{
						return Array.Find(clips, element => element.name.ToLower() == clipName.ToLower());
				}

				/// <summary>
				/// Return true if there's a clip queued matching this clip name
				/// </summary>
				protected bool IsPlaying(string clipName)
				{
						return audioSource.clip && audioSource.clip.name.ToLower() == clipName.ToLower();
				}

		}
	
}


