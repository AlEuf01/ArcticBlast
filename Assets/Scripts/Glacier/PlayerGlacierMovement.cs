using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// PlayerGlacierMovement.cs
		/// Handles moving the player when they are on top of the glacier
		/// </summary>
		public class PlayerGlacierMovement : MonoBehaviour
		{

				public float Speed = 0.1f;

				public LayerMask layerMask;
		
				const float RANGE = 3.0f;
		
				void FixedUpdate()
				{
						RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, RANGE, layerMask);

						if (hitDown.collider != null && hitDown.collider.gameObject.tag == "Glacier")
						{

								// Debug.Log("On top of Glacier");
								transform.SetParent(hitDown.collider.gameObject.transform);
						}
						else
						{
								// Debug.Log("Not on top of Glacier.");

								// Debug.Log("On top of: " + hitDown.collider.gameObject.name);
								transform.SetParent(GameObject.Find("Environment").transform);
						}
			
				}

		}
	
}
