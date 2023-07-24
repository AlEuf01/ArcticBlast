using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcticBlast.Utils;

namespace ArcticBlast
{
		
		public class GameParameters : Singleton<GameParameters>
		{

				public float PlayerFireRange = 5.0f;
				public float PlayerSpeed = 5.0f;
				public int PlayerJumpForce = 1250;

				public float GlacierSpeed = 1.0f;
				public float GlacierPushBackSpeed = 2.0f;
				public float GlacierPushBackDuration = 1.0f;

				public float EnemySpeed = 1.0f;

				public float BarrelSpawnRate = 1.0f;
				public float BeanCanSpawnRate = 1.0f;
				public float BarrelSpawnDelay = 2.0f;
				public float BeanCanSpawnDelay = 2.0f;
				public float PowerUpSpawnRange = 5.0f;
		}

}
