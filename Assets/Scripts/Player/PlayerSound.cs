using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class PlayerSound : MonoBehaviour
    {

	AudioSource audio;

	public AudioClip fartClip;
	public AudioClip megaFartClip;
	public AudioClip poofClip;
	
	void Start() {
	    audio = GetComponent<AudioSource>();
	}

	public void MegaFart() {

	    audio.clip = megaFartClip;
	    audio.Play();
	}

	public void Fart() {
	    
	    audio.clip = fartClip;
	    audio.Play();
	}

	public void Poof() {
	    
	    audio.clip = poofClip;
	    audio.Play();
	}
    }
}
