using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
    
    public class Tutorial : MonoBehaviour
    {

	int tutorialNumber = 0;
	
	void OnEnable() {
	    Events.OnConsumeBeanCan += FartTutorial;
	    Events.OnConsumeBeanBarrel += FartTutorial;
		
	}

	void OnDisable() {
	    Events.OnConsumeBeanCan -= FartTutorial;
	    Events.OnConsumeBeanBarrel -= FartTutorial;
	}

	void FartTutorial() {
	    if (tutorialNumber == 0) {
		tutorialNumber++;
		Events.ChoosePath("fart");
	    } 
	}

    }
}
