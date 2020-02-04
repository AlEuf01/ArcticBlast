using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class PlayerSound : MonoBehaviour
    {

	AudioSource audio;

	public AudioClip[] fartClips;
	public AudioClip[] megaFartClips;
	public AudioClip[] poofClips;
	
	void Start() {
	    audio = GetComponent<AudioSource>();
	}

	public void MegaFart() {

	    audio.clip = GetRandomClip(megaFartClips);
	    audio.Play();
	}

	public void Fart() {
	    
	    audio.clip = GetRandomClip(fartClips);
	    audio.Play();
	}

	public void Poof() {
	    
	    audio.clip = GetRandomClip(poofClips);
	    audio.Play();
	}

	AudioClip GetRandomClip(AudioClip[] clips) {
	    if (clips.Length == 0) {
		Debug.LogError("No clips initialized.");
		return null;
	    } else {
		return clips[Random.Range(0, clips.Length - 1)];
	    }
	}
    }
}
