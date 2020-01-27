using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Scenes;

namespace ArcticBlast {
    
    public class Camera : Cyborg.Platformer.CameraController
    {
	// Reference to the edge of the glacier
	private GlacierEdge glacierEdge;

	// Cache the xMin specified by the user
	float initXMin;
	
	void OnEnable() {
	    SceneController.AfterSceneLoad += ResetXMin;
	}

	void OnDisable() {
	    SceneController.AfterSceneLoad -= ResetXMin;
	}

	void Awake() {
	    // Cache the xMin specified by the user
	    initXMin = xMin;
	}

	// Reset back to the initial value after loading a new level
	void ResetXMin() {
	    xMin = Mathf.Max(initXMin);
	}
	
	// Initializes the glacier edge
	void SetGlacierEdge() {
	    if (glacierEdge == null) {
		glacierEdge = GameObject.FindObjectOfType<GlacierEdge>();
	    }
	}

	protected override void TrackPlayer() {
	    SetPlayer();	    
	    SetGlacierEdge();
	    
	    if (player == null) {
		ResetCamera();
	    } else {
		SetPlayerPosition();
	    }
	}

	protected override void SetPlayerPosition() {	    
	    // Debug.Log("Setting glacier edge to " + glacierEdge.transform.position.x);
	    xMin = Mathf.Max(xMin, glacierEdge.gameObject.transform.position.x + glacierEdge.cameraOffset);

	    // Make sure xMin is less than xMax
	    xMin = Mathf.Min(xMax, xMin);
	    
	    base.SetPlayerPosition();
	}
	
    }
    
}
