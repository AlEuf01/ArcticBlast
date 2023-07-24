using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// PowerUpSpawner.cs
		///
		/// Spawns power-ups
		/// </summary>
    public class PowerUpSpawner : MonoBehaviour
    {

				/// <summary>
				/// The maximum angle this can be rotated when spawning
				/// </summary>
				const float MAX_ANGLE = 180f;
				
				/// <summary>
				/// Get a randomized spawn position
				/// </summary>
				protected Vector2 GetSpawnPosition()
				{
		
						Vector2 spawnPosition = transform.position;
						spawnPosition.x = Random.Range(transform.position.x - GameParameters.Instance.PowerUpSpawnRange/2, transform.position.x + GameParameters.Instance.PowerUpSpawnRange/2);

						return spawnPosition;
		
				}

				/// <summary>
				/// Get a randomized spawn rotation
				/// </summary>
				protected Quaternion GetSpawnRotation()
				{
						return Quaternion.Euler(0, 0, Random.Range(0, MAX_ANGLE));
				}
		
    }
    
}
