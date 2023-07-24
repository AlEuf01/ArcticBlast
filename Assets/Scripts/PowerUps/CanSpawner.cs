using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// CanSpawner.cs
		/// </summary>
		public class CanSpawner : PowerUpSpawner
		{
		
				public BeanCan canPrefab;
		
				// Start is called before the first frame update
				void Start()
				{
						InvokeRepeating("LaunchBeanCan", GameParameters.Instance.BeanCanSpawnDelay, GameParameters.Instance.BeanCanSpawnRate);    
				}
		
				void LaunchBeanCan()
				{
						Instantiate(canPrefab, GetSpawnPosition(), GetSpawnRotation());
				}
		
		}
	
}
