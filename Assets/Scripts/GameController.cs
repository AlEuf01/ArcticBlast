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

		public void Pause() {
			// Play Sound Clip
			AudioController.Pause();

			Time.timeScale = 0.0f;

			PauseOverlay.Show();
		}
		
		public void Unpause() {
			AudioEvents.UnPause();
			
			Time.timeScale = 1.0f;

			PauseOverlay.Hide();
		}

		public void Restart() {		   
			Debug.Log("Restarting the game.");
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
