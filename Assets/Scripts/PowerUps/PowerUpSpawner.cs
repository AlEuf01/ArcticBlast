using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

    // Spawns power-ups 
    public class PowerUpSpawner : MonoBehaviour
    {
	
		// The range in which the power up can spawn from origin
		public float range;	   
		
		public float RepeatRate = 1f;
		public float Delay = 2f;

		// The maximum angle this can be rotated when spawning
		const float MAX_ANGLE = 180f;

		// Get a randomized spawn position
		protected Vector2 GetSpawnPosition() {
		
			Vector2 spawnPosition = transform.position;
			spawnPosition.x = Random.Range(transform.position.x - range/2, transform.position.x + range/2);

			return spawnPosition;
		
		}

		// Get a randomized spawn rotation
		protected Quaternion GetSpawnRotation() {
			float angle = Random.Range(0, MAX_ANGLE);
			
			return Quaternion.Euler(0, 0, angle);
		}
		
    }
    
}
