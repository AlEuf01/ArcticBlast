using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcticBlast.Utils;

namespace ArcticBlast
{
		
		public class GameParameters : Singleton<GameParameters>
		{

				[Header("Player")]
				public float PlayerFireRange = 5.0f;
				public float PlayerSpeed = 5.0f;
				public int PlayerJumpForce = 1250;
				public float PlayerStartPositionX = 2.25f;
				public float EggPositionX = 7.01f;

				[Header("Glacier and Enemies")]
				public float GlacierSpeed = 1.0f;
				public float GlacierSpeedIncreaseRate = 0.3f;
				public float MaxGlacierSpeed = 2.0f;
				public float MinGlacierX = -14f;
				public float MaxGlacierX = -2f;
				
				public float GlacierPushBackSpeed = 2.0f;
				public float GlacierPushBackDuration = 1.0f;

				public int EnemyStartLevel = 2;
				public int MultipleEnemyStartLevel = 4;
				public int EnemyHardStartLevel = 5;
				public float EnemySpeed = 1.0f;
				public float EnemyPositionY = -1.56f;
				public float ObstacleSpawnChance = 0.4f;
				public int ObstacleMinLevel = 1;

				public float AirplaneHeight = 2.0f;
				
				[Header("Power Ups")]
				public float BarrelSpawnRate = 1.0f;
				public float BeanCanSpawnRate = 1.0f;
				public float BarrelSpawnDelay = 2.0f;
				public float BeanCanSpawnDelay = 2.0f;
				public float PowerUpSpawnRange = 5.0f;

				[Header("Fade Timing")]
				public float DelayWhenWinningGame = 5.0f;
				public float DelayWhenAdvancingLevel = 3.0f;
				public float DelayWhenLosingLevel = 2.0f;
				public float DelayBeforeStartingMusic = 1.0f;
		}

}
