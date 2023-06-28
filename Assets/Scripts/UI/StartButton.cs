using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.UI
{

		/// <summary>
		/// StartButton.cs
		/// Press this button to start the game
		/// </summary>		
    public class StartButton : MonoBehaviour, IButton
    {

				/// <summary>
				/// Click Handler for Button
				/// </summary>
				public void OnClick()
				{
						SceneEvents.RestartGame();
				}
    
		}
}
