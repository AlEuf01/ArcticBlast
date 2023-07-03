using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// InputManager.cs
		///
		/// Manages keyboard input
		/// </summary>
		public class InputManager : MonoBehaviour
		{
	    
				// Check for Jump or Fire events
				void FixedUpdate()
				{
						if (Input.GetButton("Jump")) {
								Events.Jump();
						}
		
						if (Input.GetButtonDown("Fire1")) {
								Events.Fire();
						}
				}
		}
    
}
