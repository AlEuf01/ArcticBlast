using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArcticBlast {
    
    public class SpeechView : MonoBehaviour
    {
	
	void OnEnable() {
	    UIEvents.OnShowSpeech += Show;
	}

	void OnDisable() {
	    UIEvents.OnShowSpeech -= Show;
	}

	
	void Show(string text) {
	    GetComponent<CanvasGroup>().alpha = 1.0f;
	    
	    GetComponent<Text>().text = text;

	    StartCoroutine(FadeOut());
	}

	// Transition the text offscreen
	IEnumerator FadeOut(float duration = 2.0f) {
	    yield return new WaitForSeconds(duration);    

	    for (float fade = 0.0f; fade < 1.0f; fade += Time.deltaTime / duration) {
		GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1.0f, 0.0f, fade);
		yield return null;
	    }
	}
    }
}
