using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;
using Cyborg.Scenes;

using ArcticBlast.Ammo;
using ArcticBlast.Utils;

namespace ArcticBlast {

	// Controller for the main logic of the game
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

		void Restart() {		   
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

		void OnEnable() {
			Events.OnGameOver += Restart;
		}

		void OnDisable() {
			Events.OnGameOver -= Restart;
		}
		
		// Resets the game from the beginning
		IEnumerator Reset() {			
			
			yield return new WaitForSeconds(3.0f);

			Events.Restart();
			
		}

	}
	
}
