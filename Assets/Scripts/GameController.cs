using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Audio;
using Cyborg.Scenes;

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

			Debug.Log("Restarting the game.");
			
			StartCoroutine(Lose());
		}

		public void Win() {
			Debug.Log("Winning the game.");
			
			StartCoroutine(Won());			
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
			Events.OnCompleteLevel += Win;
		}

		void OnDisable() {
			Events.OnGameOver -= Restart;
			Events.OnCompleteLevel -= Win;
		}
		
		// Resets the game from the beginning
		IEnumerator Reset() {			

			AudioController.PlayLoop();

			yield return new WaitForSeconds(3.0f);

			Events.Restart();																		 
		}

		IEnumerator Won() {
			AudioController.PlayWin();

			SceneEvents.ChangeScene("_Win");
			
			yield return new WaitForSeconds(3.0f);
		   			
			Events.Restart();

			yield return new WaitForSeconds(1.0f);
			
			AudioController.PlayLoop();

		}
		
		IEnumerator Lose() {

			AudioController.PlayLose();

			SceneEvents.ChangeScene("_GameOver");
			
			yield return new WaitForSeconds(3.0f);
			
			Events.Restart();

			yield return new WaitForSeconds(1.0f);
			
			AudioController.PlayLoop();
		}

	}
	
}
