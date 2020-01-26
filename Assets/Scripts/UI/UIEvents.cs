using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class UIEvents
    {

	public delegate void SpeechEvent(string text);
	public static event SpeechEvent OnShowSpeech;

	public static void ShowSpeech(string text) {
	    if (OnShowSpeech != null) {
		OnShowSpeech(text);
	    }
	}
    }
}
