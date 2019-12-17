using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Platformer;
using Cyborg.Scenes;
using ArcticBlast.Ammo;

namespace ArcticBlast.Player {

    public class PlayerEventHandler : MonoBehaviour
    {
		void OnEnable() {			
			Events.OnConsumeBeanCan += ConsumeBeanCan;
			Events.OnConsumeBeanBarrel += ConsumeBeanBarrel;
		}
		
		void OnDisable() {					
			Events.OnConsumeBeanCan -= ConsumeBeanCan;
			Events.OnConsumeBeanBarrel -= ConsumeBeanBarrel;
		}
		
		void ConsumeBeanCan() {
			// Debug.Log("Consumed a bean can");
			
			// Increment player's ammo
			
			AmmoManager.Add();

			// TODO: UI event?
			
		}

		void ConsumeBeanBarrel() {
			// Debug.Log("Consumed a bean barrel");

			AmmoManager.Fill();
		}
    }
	
}

