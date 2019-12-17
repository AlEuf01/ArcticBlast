using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cyborg.Scenes;

namespace ArcticBlast.UI {


	public class RestartButton : MonoBehaviour, IButton
	{


		bool clicked = false;
		
		public void OnClick() {
			if (!clicked) {
				clicked = true;
				AudioController.PlayLoop();
				GameController.GotoStartLevel();
			}

		}

		void Update() {
			if (!clicked) {
				
				if (Input.GetButton("Jump") || Input.GetButton("Fire1")) {
					OnClick();
				}
			}
				   
		}
	}

}

