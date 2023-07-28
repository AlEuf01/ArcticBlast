using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
				public int levelNum = 0;
				
				/// <summary> 
				/// Total number of levels
				/// </summary>
				public int numLevels = 5;

				[Header("Scene Names")]
				/// <summary> Scene to load on victory </summary>
				public string VictorySceneName = "_Win";

				/// <summary> scene to load on Game Over </summary>
				public string GameOverSceneName = "_GameOver";

				private bool isChangingLevel = false;
			 
				void OnEnable()
				{
						Events.OnGameOver += Restart;
						Events.OnCompleteLevel += CompleteLevel;
				}
	
				void OnDisable()
				{
						Events.OnGameOver -= Restart;
						Events.OnCompleteLevel -= CompleteLevel;
				}
				
				/// <summary>
				/// Pause the game
				/// </summary>
				public void Pause()
				{
						Time.timeScale = 0.0f;
						Events.Pause();
				}
	
				/// <summary>
				/// Unpause the game
				/// </summary>
				public void Unpause()
				{			
						Time.timeScale = 1.0f;
						Events.UnPause();
				}

				
				void Update()
				{
						// Handle Key Input Events
						if (Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape))
						{
								TogglePause();
						}
				}

				/// <summary>
				/// Restart the game
				/// </summary>
				void Restart()
				{	    
						StartCoroutine(Lose());
				}

				
				/// <summary>
				/// Completes a level
				/// </summary>
				void CompleteLevel()
				{

						if (isChangingLevel == false)
						{
								isChangingLevel = true;
								AudioEvents.PlayWin();
								
								// Reset the player's ammo to zero
								AmmoManager.Amount = 0;
								
								// Got to the next level
								levelNum++;
								
								StartCoroutine(HandleCompleteLevel());
						}
				}

				/// <summary>
				/// Pause or unpause the game
				/// </summary>
				void TogglePause()
				{
						if (Time.timeScale == 0.0f)
						{
								Unpause();
						}
						else
						{
								Pause();
						}
				}

				/// <summary>
				/// Resets the game from the beginning
				/// </summary>
				IEnumerator Reset()
				{			
	    
						AudioEvents.PlayLoop();
	    
						yield return new WaitForSeconds(GameParameters.Instance.DelayWhenLosingLevel);
	    
						SceneEvents.RestartGame();
				}
				

				/// <summary>
				/// Advances to the next level
				/// </summary>								
				void NextLevel()
				{
						if (levelNum < numLevels)
						{
								Debug.Log($"Advancing to level {levelNum} out of {numLevels}");
								SceneEvents.ChangeScene($"Level{levelNum}");
								isChangingLevel = false;
						}
						else
						{
								Debug.LogError("No next level to jump towards.");
						}
				}

				/// <summary>
				/// Handles winning a level
				/// </summary>
				IEnumerator HandleCompleteLevel()
				{
							    	 
						if (levelNum == numLevels)
						{
								// SceneEvents.ChangeScene(VictorySceneName);
	    
								// yield return new WaitForSeconds(GameParameters.Instance.DelayWhenWinningGame);

								// Reset to the first level
								levelNum = 0;

								// Restart to the beginning
								SceneEvents.RestartGame();
		
						}
						else
						{
								yield return new WaitForSeconds(GameParameters.Instance.DelayWhenAdvancingLevel);
								NextLevel();
						}
		
						yield return new WaitForSeconds(GameParameters.Instance.DelayBeforeStartingMusic);
	    
						AudioEvents.PlayLoop();
	    
				}

				/// <summary>
				/// Handles losing a level
				/// </summary>
				IEnumerator Lose()
				{

						AmmoManager.Amount = 0;
	    
						AudioEvents.PlayLose();
	    
						// SceneEvents.ChangeScene(GameOverSceneName);

						// yield return new WaitForSeconds(GameParameters.Instance.DelayWhenLosingLevel);

						Debug.Log("Advancing to next level.");
						
						NextLevel();
	    
						yield return new WaitForSeconds(GameParameters.Instance.DelayBeforeStartingMusic);
	    
						AudioEvents.PlayLoop();
				}
	
    }
	
}
