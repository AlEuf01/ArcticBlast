﻿using System;
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
				/// Return true if there's a clip queued matching this clip name
				/// <param name="clip">The clip name to check</param>
				/// </summary>
				protected bool IsPlaying(string clipName)
				{
						return audioSource.clip && audioSource.clip.name.ToLower() == clipName.ToLower();
				}
				
				/// <summary>
				/// Return true if there's a clip queued matching this clip
				/// <param name="clip">The clip to check</param>
				/// </summary>
				protected bool IsPlaying(AudioClip clip)
				{
						return IsPlaying(clip.name);
				}

		}
	
}


