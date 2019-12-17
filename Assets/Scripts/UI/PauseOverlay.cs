using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcticBlast.Utils;

namespace ArcticBlast {
	
	public class PauseOverlay : Singleton<PauseOverlay>
	{
		
		void Start() {
			Hide();
		}

		void OnEnable() {
			Events.OnPause += Show;
			Events.OnUnPause += Hide;
		}

		void OnDisable() {
			Events.OnPause -= Show;
			Events.OnUnPause -= Hide;
		}
		
		public static void Show() {
			Instance.GetComponent<CanvasGroup>().alpha = 1f;
			Instance.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		
		public static void Hide() {		
			Instance.GetComponent<CanvasGroup>().alpha = 0f;
			Instance.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
	
}
