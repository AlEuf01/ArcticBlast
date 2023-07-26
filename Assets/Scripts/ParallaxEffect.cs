using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Apply a parallax effect to the background in the combat level
/// Attach to a layer when setting up the background
/// Based off of https://pavcreations.com/parallax-scrolling-in-pixel-perfect-2d-unity-games/
/// </summary>
public class ParallaxEffect : MonoBehaviour
{
		/// <summary>
		/// Amount of parallax to apply to this layer
		/// Small values are close to the foreground and move quickly; large values are far away and move slowly
		/// </summary>
		[Range(0,1)]
		public float ParallaxFactor;

		/// <summary>
		/// Length of the background
		/// </summary>
		private float Length;

		/// <summary>
		/// Starting x-value
		/// </summary>
		private float StartPosition;

		/// <summary>
		/// Referrence to the game camera
		/// </summary>
		private Camera cam;
           
		void Start()
		{
				// Setup initial values
				StartPosition = transform.position.x;
				Length = GetComponent<SpriteRenderer>().bounds.size.x;
				cam = GameObject.FindObjectOfType<Camera>();                        
		}


		void Update()
		{
				float temp = cam.transform.position.x * (1 - ParallaxFactor);

				// Calculate the distance each layer moves per frame
				float distance = cam.transform.position.x * ParallaxFactor;

				// Apply a new position from this distance
				transform.position = new Vector3(StartPosition + distance, transform.position.y, transform.position.z);        

				// Reanchor the background as we move the camera
				if (temp > StartPosition + 10)
				{
						StartPosition += Length;            
				}
				else if (temp < StartPosition - 10)
				{
						StartPosition -= Length;            
				}                              
		}

}
