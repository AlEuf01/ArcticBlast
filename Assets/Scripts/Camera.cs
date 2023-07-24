using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// Camera.cs
		/// 
		/// Panning Camera for Arctic Blast
		/// </summary>
    public class Camera : CameraController
    {

				// Reference to glacier, used for clamping movement
				private Glacier glacier;

				// Cache the xMin specified by the user
				private float initXMin;

				const float MIN_WIDTH = 1f;
				const float GLACIER_OFFSET = 2f;
				
				void OnEnable()
				{
						SceneController.AfterSceneLoad += ResetXMin;
				}

				void OnDisable()
				{
						SceneController.AfterSceneLoad -= ResetXMin;
				}

				void Awake()
				{
						initXMin = xMin;
				}

				// Reset back to the initial value after loading a new level
				void ResetXMin()
				{
						xMin = Mathf.Max(initXMin);
				}
	
				// Initializes the glacier edge
				void SetGlacierEdge()
				{
						if (glacier == null)
						{
								glacier = GameObject.FindObjectOfType<Glacier>();
						}
				}

				protected override void TrackPlayer()
				{	    
						SetPlayer();	    
						SetGlacierEdge();
	    
						if (player == null)
						{
								ResetCamera();
						}
						else
						{
								SetPlayerPosition();
						}
				}

				protected override void SetPlayerPosition()
				{
						
						// Debug.Log("Setting glacier edge to " + glacierEdge.transform.position.x);
						xMin = Mathf.Max(initXMin, glacier.gameObject.transform.position.x + GLACIER_OFFSET);

						// Make sure xMin is less than xMax by MIN_WIDTH
						xMin = Mathf.Min(xMin, xMax - MIN_WIDTH);
	    
						base.SetPlayerPosition();
				}
	
    }
    
}
