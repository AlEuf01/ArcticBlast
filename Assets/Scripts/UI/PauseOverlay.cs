using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.UI {

		/// <summary>
		/// An overlay view that appears when the game is paused
		/// </summary>
		public class PauseOverlay : MonoBehaviour
		{
		
				void Start() {
						Hide();
				}

				void OnEnable()
				{
						Events.OnPause += Show;
						Events.OnUnPause += Hide;
				}

				void OnDisable()
				{
						Events.OnPause -= Show;
						Events.OnUnPause -= Hide;
				}
		
				void Show()
				{
						GetComponent<CanvasGroup>().alpha = 1f;
						GetComponent<CanvasGroup>().blocksRaycasts = true;
				}
		
				void Hide()
				{		
						GetComponent<CanvasGroup>().alpha = 0f;
						GetComponent<CanvasGroup>().blocksRaycasts = false;
				}
		}
	
}
