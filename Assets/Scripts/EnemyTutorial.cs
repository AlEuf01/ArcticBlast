using UnityEngine;
using Cyborg.Scenes;

namespace ArcticBlast {
    
    public class EnemyTutorial : MonoBehaviour
    {
	
	void OnEnable() {
	    SceneController.AfterSceneLoad += EnemiesTutorial;
	    Events.OnConsumeBeanBarrel += MegaFartTutorial;
	}

	void OnDisable() {
	    SceneController.AfterSceneLoad -= EnemiesTutorial;
	    Events.OnConsumeBeanBarrel -= MegaFartTutorial;
	}

	void EnemiesTutorial() {
	    Events.ChoosePath("enemy");
	}

	void MegaFartTutorial() {
	    if (AmmoManager.Amount == AmmoManager.maxAmmo) {
		Events.ChoosePath("megafart");
	    }
	}
    }
}
