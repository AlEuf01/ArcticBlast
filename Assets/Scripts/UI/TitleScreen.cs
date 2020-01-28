using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

namespace ArcticBlast {
    
    public class TitleScreen : MonoBehaviour
    {

	void Update() {
	    if (Input.GetKeyDown(KeyCode.Space)) {
		StartGame();
	    }
	}

	void StartGame() {
	    SceneEvents.ChangeScene("Tutorial");
	}
    }
}
