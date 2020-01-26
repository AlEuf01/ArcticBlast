using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cyborg.Scenes;

namespace ArcticBlast {
    
    public class Tutorial : MonoBehaviour
    {

	int tutorialNumber = 0;
	
	void OnEnable() {
	    SceneController.AfterSceneLoad += MoveTutorial;
	    Events.OnConsumeBeanCan += FartTutorial;		
	}
	
	void OnDisable() {
	    SceneController.AfterSceneLoad -= MoveTutorial;
	    Events.OnConsumeBeanCan -= FartTutorial;	    
	}

	void MoveTutorial() {
	    tutorialNumber = 0;
	    Events.ChoosePath("start");
	}
	
	void FartTutorial() {
	    if (tutorialNumber == 0) {
		tutorialNumber++;
		Events.ChoosePath("fart");
	    } 
	}

    }
}
