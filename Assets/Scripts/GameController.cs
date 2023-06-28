using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

using ArcticBlast.Utils;

namespace ArcticBlast
{

    /// <summary>
		/// GameController.cs
		/// Controller for the main logic of the game
		/// </summary>
    public class GameController : Singleton<GameController>
    {

				/// <summary>
				/// Current level
				/// </summary>				
				public int levelNumber = 0;

				/// <summary> 
				/// Total number of levels
				/// </summary>
				public int numLevels = 4;
								
				void OnEnable() {
						Events.OnGameOver += Restart;
						Events.OnCompleteLevel += Win;
				}
	
				void OnDisable() {
						Events.OnGameOver -= Restart;
						Events.OnCompleteLevel -= Win;
				}
				
				/// <summary>
				/// Pause the game
				/// </summary>
				public void Pause() {
						Time.timeScale = 0.0f;
						Events.Pause();
				}
	
				/// <summary>
				/// Unpause the game
				/// </summary>
				public void Unpause() {			
						Time.timeScale = 1.0f;
						Events.UnPause();
				}

				
				void Update() {
						// Handle Key Events
						if (Input.GetKeyUp(KeyCode.P)) {
								TogglePause();
						}
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
	
				// Resets the game from the beginning
				IEnumerator Reset() {			
	    
						AudioController.PlayLoop();
	    
						yield return new WaitForSeconds(3.0f);
	    
						SceneEvents.ChangeScene("Tutorial");
				}
	
				IEnumerator Won() {

	    
						AudioController.PlayWin();

						AmmoManager.Amount = 0;
	    
						levelNumber++;
	    
						if (levelNumber == numLevels) {
								SceneEvents.ChangeScene("_Win");
	    
								yield return new WaitForSeconds(3.0f);

								levelNumber = 0;

								SceneEvents.ChangeScene("Tutorial");
		
						} else {
								NextLevel();
						}
		
						yield return new WaitForSeconds(1.0f);
	    
						AudioController.PlayLoop();
	    
				}

				void NextLevel() {
						if (levelNumber == 1) {
								// TODO: Go To Next Level Dynamically
								SceneEvents.ChangeScene("Level1");
						} else if (levelNumber == 2) {
								SceneEvents.ChangeScene("Level2");
						} else if (levelNumber == 3) {
								SceneEvents.ChangeScene("Level3");
						} else {
								SceneEvents.ChangeScene("Tutorial");
								Debug.LogError("No next level to jump towards.");
						}
				}
	
				IEnumerator Lose() {

						AmmoManager.Amount = 0;
	    
						AudioController.PlayLose();
	    
						SceneEvents.ChangeScene("_GameOver");
			
						yield return new WaitForSeconds(3.0f);
	    
						NextLevel();
	    
						yield return new WaitForSeconds(1.0f);
	    
						AudioController.PlayLoop();
				}
	
    }
	
}
