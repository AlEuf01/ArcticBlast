using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;
using Cyborg.Scenes;

using ArcticBlast.Ammo;
using ArcticBlast.Utils;

namespace ArcticBlast {

	public class GameController : Singleton<GameController>
	{
		
		// Pause the game
		public void Pause() {
			Time.timeScale = 0.0f;
			Events.Pause();
		}

		// Unpause the game
		public void Unpause() {			
			Time.timeScale = 1.0f;
			Events.UnPause();
		}

		public void Restart() {		   
			// Debug.Log("Restarting the game.");
			
			SceneEvents.ChangeScene("_GameOver");
			StartCoroutine(Reset());
		}

		public void Win() {
			AudioController.PlayWin();
			SceneEvents.ChangeScene("_Win");

			StartCoroutine(Reset());
		}
		
		void TogglePause() {
			if (Time.timeScale == 0.0f) {
				Unpause();
			} else {
				Pause();
			}
		}
	
		void Update() {
			if (Input.GetKeyUp(KeyCode.P)) {
				TogglePause();
			}
		}

		// Resets the game from the beginning
		IEnumerator Reset() {

			AmmoManager.RemoveAllAmmo();
			
			yield return new WaitForSeconds(3.0f);

			AudioController.PlayLoop();

			GotoStartLevel();
			
		}

		public static void GotoStartLevel() {
			SceneEvents.ChangeScene("Tutorial");
		}

	}
	
}
