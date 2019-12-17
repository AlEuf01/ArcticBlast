using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcticBlast.Utils;

public class PauseOverlay : Singleton<PauseOverlay>
{

	void Start() {
		Hide();
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
