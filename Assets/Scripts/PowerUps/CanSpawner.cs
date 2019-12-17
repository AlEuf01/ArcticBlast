using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {
	
	public class CanSpawner : PowerUpSpawner
	{
		
		public BeanCan canPrefab;
		
		// Start is called before the first frame update
		void Start()
		{
			InvokeRepeating("LaunchBeanCan", Delay, RepeatRate);    
		}
		
		void LaunchBeanCan() {
			Instantiate(canPrefab, GetSpawnPosition(), GetSpawnRotation());
		}
		
	}
	
}
