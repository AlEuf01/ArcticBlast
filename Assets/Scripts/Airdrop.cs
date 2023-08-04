using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// Airdrop.cs
		/// Handles spawning bean cans and bean barrels
		/// </summary>
		public class Airdrop : MonoBehaviour
		{

				// Airplane prefab to spawn
				public GameObject airplane;

				// Delay before launching an airplane
				public float initialDelay;

				public float delayBetweenPlanes;
				
				// The coordinates to spawn airplanes from
				private Vector3 launchPoint;
				
				void Start()
				{
						launchPoint = new Vector3(GameParameters.Instance.EggPositionX, GameParameters.Instance.AirplaneHeight, 0);
						InvokeRepeating("LaunchAirplane", initialDelay, delayBetweenPlanes);						
				}
				
				void LaunchAirplane()
				{
						Instantiate(airplane, launchPoint, Quaternion.identity);
				}
		}

}
