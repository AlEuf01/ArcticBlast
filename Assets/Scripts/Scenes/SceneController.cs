using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArcticBlast
{

    // Singleton to load and unload scenes
    public class SceneController : MonoBehaviour, ISceneController
		{
		
        // Scene configuration
        public SceneConfig config;

				// Canvas for the scene fade transition
				public SceneFader Fader;
		
        // Before and after scene load callbacks
        public static event Action BeforeSceneUnload;
				public static event Action AfterSceneUnload;
        public static event Action BeforeSceneLoad;
        public static event Action AfterSceneLoad;        

				void OnEnable()
				{
						SceneEvents.OnChangeScene += SwitchScene;
						SceneEvents.OnRestartGame += Restart;
				}
	
				void OnDisable()
				{
						SceneEvents.OnChangeScene -= SwitchScene;
						SceneEvents.OnRestartGame -= Restart;
				}

				/// <summary>
				/// Restarts from the start scene
				/// </summary>
				void Restart()
				{
						SwitchScene(config.Start);
				}

				/// <summary>
        /// Called from triggers between areas when the player wants to switch scenes
				/// </summary>
        public void SwitchScene(string sceneName)
				{
						if (Fader.isFading)
						{
								// Do nothing; currently fading in/out
						}
						else
						{
								StartCoroutine(FadeAndSwitchScenes(sceneName));
						}
        }

				/// <summary>
        /// Load the title screen
				/// </summary>
        public void ToMainMenu()
				{
	    
						if (BeforeSceneUnload != null)
						{
								BeforeSceneUnload();
						}
	    
            StartCoroutine(LoadMainMenu());
        }

				/// <summary>
				/// Starts the game
				/// </summary>
				IEnumerator Start ()
        {
						// Load UI in the background
            yield return LoadUI();
	    
						// If there's a main menu, load it
						if (config.Title != "")
						{
								yield return LoadMainMenu();
						}
						else if (config.Start != "")
						{
								yield return LoadStartScene(config.Start);
						}
						else
						{
								Debug.LogError("No Title or Start Scene specified in Scene Config; can't load the first scene.");
						}
				}

				
				/// <summary>
        /// Load the start scene
				/// </summary>
				IEnumerator LoadStartScene(string sceneName)
				{
	    
						if (sceneName == "") {
								Debug.LogError("Trying to load an empty scene name.");
								yield return null;
						}
	    
						// Load the game's first scene
						yield return StartCoroutine(Fader.FadeOut());
			
						if (AfterSceneUnload != null) {
								AfterSceneUnload();
						}
	    
						yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
	    
						yield return StartCoroutine(Fader.FadeIn());
	    
				}

				/// <summary>
        /// Load the title screen
				/// </summary>
        IEnumerator LoadMainMenu()
				{
						yield return StartCoroutine(LoadStartScene(config.Title));
        }

				/// <summary>
				/// Load all UI scenes
				/// </summary>
        IEnumerator LoadUI()
				{            
            foreach(string sceneName in config.UserInterface)
						{
                yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);     
            }     
        }

				/// <summary>
				/// Fade out and swap out scenes
				/// </summary>
        IEnumerator FadeAndSwitchScenes(string sceneName)
				{

						if (BeforeSceneUnload != null)
						{
								BeforeSceneUnload();
						}
            
            // Fade to black
            yield return StartCoroutine(Fader.FadeOut());
	    
						// Switch scene
            yield return SwitchToScene(sceneName);
	    
            if (BeforeSceneLoad != null)
						{
                BeforeSceneLoad();
            }
            
            // Fade from black
            yield return StartCoroutine(Fader.FadeIn());
	    
						if (AfterSceneLoad != null)
						{
								AfterSceneLoad();
						}
	    
        }
				/// <summary>
        /// Loads the scene at scenepath and sets it to be active
				/// <param name="scenePath">the new scene to load</param>
				/// </summary>
        IEnumerator LoadSceneAndSetActive (string scenePath)
        {
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);

						// TODO: Show a loading scene

            yield return asyncLoad;

            Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene (newlyLoadedScene);

        }
				/// <summary>
        /// Switch from the currently loaded scene to this new scene
				/// <param name="sceneName">the new scene to load</param>
				/// </summary>
        IEnumerator SwitchToScene(string sceneName) {
            yield return SwitchToScene(SceneManager.GetActiveScene().buildIndex, sceneName);
        }

				/// <summary>
        /// Unload the old scene (by index) and load the new scene				
				/// <param name="oldScene">the old scene index to unload</param>
				/// <param name="newScene">the new scene to load</param>
				/// </summary>
        IEnumerator SwitchToScene(int oldSceneIndex, string newScene)
				{
            yield return SwitchToScene(SceneManager.GetSceneByBuildIndex(oldSceneIndex).name, newScene);
        }

				/// <summary>
        /// Unload the old scene and load the new scene
				/// <param name="oldScene">the old scene to unload</param>
				/// <param name="newScene">the new scene to load</param>
				/// </summary>
        IEnumerator SwitchToScene(string oldScene, string newScene)
				{
            if (Application.CanStreamedLevelBeLoaded(newScene))
						{
								yield return SceneManager.UnloadSceneAsync(oldScene);
								yield return StartCoroutine(LoadSceneAndSetActive(newScene));
						}
        }

				/// <summary>
        /// Returns true if sceneName is the active scene
				/// <param name="sceneName">the scene to test</param>
				/// </summary>
        bool IsActiveScene(string sceneName)
				{
            return SceneManager.GetActiveScene().name == sceneName;
        }
    }
    
}

