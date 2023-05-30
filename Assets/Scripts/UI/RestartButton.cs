using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cyborg.Scenes;

namespace ArcticBlast.UI {

		/// <summary>
		/// Press this button to restart the game
		/// </summary>
		public class RestartButton : MonoBehaviour, IButton
		{

				// True if this button has been clicked (but hasn't disappeared yet)
				private bool clicked = false;

				// Fire or jump events trigger this button
				void OnEnable() {
						Events.OnFire += OnClick;
						Events.OnJump += OnClick;
				}

				void OnDisable() {
						Events.OnFire -= OnClick;
						Events.OnJump -= OnClick;
				}

				/// <summary>
				/// Click handler for restart button
				/// </summary>
				public void OnClick() {
						if (!clicked) {
								clicked = true;
								SceneEvents.ChangeScene("Tutorial");
						}
				}


		}

}

