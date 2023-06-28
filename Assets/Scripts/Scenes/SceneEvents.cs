using UnityEngine;
using System;

namespace ArcticBlast
{

		/// <summary>
		/// Sceneevents.cs
		/// </summary>
    public class SceneEvents
		{
	
				public delegate void ChangeSceneHandler(string sceneName);
				public static event ChangeSceneHandler OnChangeScene;

				public static event Action OnRestartGame;

				public static void RestartGame()
				{
						if (OnRestartGame != null)
						{
								OnRestartGame();
						}
				}
				
				public static void ChangeScene(string sceneName)
				{
						if (OnChangeScene != null)
						{
								OnChangeScene(sceneName);
						}
				}
    }
}
