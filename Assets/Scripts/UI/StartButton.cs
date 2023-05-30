using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

namespace ArcticBlast.UI {

		/// <summary>
		/// Press this button to start the game
		/// </summary>		
    public class StartButton : MonoBehaviour, IButton
    {

				/// <summary>
				/// Click Handler for Button
				/// </summary>
				public void OnClick()
				{
						SceneEvents.ChangeScene("Tutorial");
				}
    
		}
}
