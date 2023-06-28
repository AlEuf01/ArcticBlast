using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
	
		public class SceneFader : MonoBehaviour
		{

				// True if the scene is currently fading
				public bool isFading;

				// The duration of the fade
				public float duration = 1f;
		
				private CanvasGroup fadeCanvas;

				void Start()
				{
						fadeCanvas = GetComponent<CanvasGroup>();

						// fade canvas is fully visible at start
						fadeCanvas.alpha = 1f;
				}

				/// <summary>
				/// Fade in
				/// </summary>
				public IEnumerator FadeOut()
				{
						yield return Fade(1.0f);
				}
				
				/// <summary>
				/// Fade out
				/// </summary>
				public IEnumerator FadeIn()
				{
						yield return Fade(0.0f);
				}

				/// <summary>
				/// Fade in or out
				/// <param name="finalAlpha">the target alpha to fade to</param>
				/// </summary>
				IEnumerator Fade(float finalAlpha)
				{
		
						isFading = true;
						fadeCanvas.blocksRaycasts = true;
			
						float fadeSpeed = Mathf.Abs(fadeCanvas.alpha - finalAlpha) / duration;

						// Update alpha
						while (!Mathf.Approximately(fadeCanvas.alpha, finalAlpha))
						{
								fadeCanvas.alpha = Mathf.MoveTowards(fadeCanvas.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
								yield return null;
						}

						fadeCanvas.blocksRaycasts = false;
						isFading = false;
				}	
		}
	
}
