using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>
		/// BarrelSpawner.cs
		/// Spawns barrels
		/// </summary>
		public class BarrelSpawner : PowerUpSpawner
		{
				public BeanBarrel barrelPrefab;

				void Start()
				{
						InvokeRepeating("LaunchBarrel", Delay, RepeatRate);
				}

				void LaunchBarrel()
				{
						Instantiate(barrelPrefab, GetSpawnPosition(), GetSpawnRotation());
				}
		}

}
