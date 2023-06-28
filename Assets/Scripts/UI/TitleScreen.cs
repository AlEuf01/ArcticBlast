using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// TitleScreen.cs
		/// </summary>
    public class TitleScreen : MonoBehaviour
    {

				void Update()
				{
						if (Input.GetKeyDown(KeyCode.Space))
						{
								StartGame();
						}
				}

				void StartGame()
				{
						SceneEvents.RestartGame();
				}
    }
}
