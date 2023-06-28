using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
		
		/// <summary>
		/// CameraController.cs
    /// Camera controller designed for platformers
		/// </summary>    
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
	
				// Set to clamp the camera
				public float xMin;
				public float xMax;
				public float yMin;
				public float yMax;
	
				// Reference to the player character
				protected GameObject player;

				// Starting position for the camera
				Vector3 StartingPosition = new Vector3(0f, 0f, -10f);
	
				void LateUpdate()
				{
						TrackPlayer();
				}

				/// <summary>
				/// Tracks the player
				/// </summary>
				protected virtual void TrackPlayer()
				{
	    
						SetPlayer();
	    
						if (player == null) {
								ResetCamera();
						} else {
								SetPlayerPosition();
						}
				}
				
				/// <summary>
				/// Initializes the player
				/// </summary>
				protected void SetPlayer()
				{
						if (player == null)
						{
								player = GameObject.FindWithTag("Player");
						}
				}
	
				protected virtual void SetPlayerPosition()
				{	    
						//Debug.Log("Setting camera minimum to " + xMin);
						float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
						float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
	    
						transform.position = new Vector3(x, y, transform.position.z);		
				}
				
				/// <summary>
				/// Reset the camera to the starting position
				/// </summary>
				protected void ResetCamera()
				{
						transform.position = StartingPosition;
				}
	
    }	
    
}
	
