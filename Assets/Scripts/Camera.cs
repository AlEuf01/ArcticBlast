using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class Camera : Cyborg.Platformer.CameraController
    {
	// Reference to the edge of the glacier
	private GlacierEdge glacierEdge;
	
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

	    base.SetPlayerPosition();
	}
	
    }
    
}
