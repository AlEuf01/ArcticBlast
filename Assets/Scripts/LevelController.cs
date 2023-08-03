using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcticBlast.Utils;

namespace ArcticBlast
{
		/// <summary>
		/// LevelController.cs
		/// Controller for individual levels
		/// </summary>
		public class LevelController : Singleton<LevelController>
		{

				public GameObject[] backgrounds;

				public GameObject camera;
				public GameObject grid;
				public GameObject boundaryPrefab;
				
				public PlayerMovement player;
				public Glacier glacier;
				public Goal goal;
				public Egg egg;
				public Enemy EnemyPrefab, EnemyHardPrefab;

				private Vector3 playerPosition;
				private Vector3 glacierPosition;
				private Vector3 goalPosition;
				private Vector3 eggPosition;

				private Vector3 leftBoundaryPosition;
				private Vector3 rightBoundaryPosition;

				private float enemyMinPosition, enemyMaxPosition, enemyPositionY;
				
				// Start is called before the first frame update
				void Start()
				{
						int bgIndex = GameController.Instance.levelNum % backgrounds.Length;

						playerPosition = new Vector3(GameParameters.Instance.PlayerStartPositionX, -1.41f, 0);

						float glacierX = Mathf.Clamp(GameParameters.Instance.MaxGlacierX - 2.0f * GameController.Instance.levelNum, GameParameters.Instance.MinGlacierX, GameParameters.Instance.MaxGlacierX);
						glacierPosition = new Vector3(glacierX, -0.13f, 0);

						goalPosition = new Vector3(glacierPosition.x + 1f, -1.1f, 0);
						eggPosition = new Vector3(GameParameters.Instance.EggPositionX, -1.75f, 0);

						leftBoundaryPosition = new Vector3(glacierPosition.x - 4f, -1.25f, 0);
						rightBoundaryPosition = new Vector3(GameParameters.Instance.EggPositionX + 1, -1.25f, 0);

						enemyMinPosition = goalPosition.x + 4f;
						enemyMaxPosition = playerPosition.x - 4f;

								
						Instantiate(backgrounds[bgIndex]);
						Instantiate(grid);
						Instantiate(camera);
						Instantiate(player, playerPosition, Quaternion.identity);
						Instantiate(glacier, glacierPosition, Quaternion.identity);
						Instantiate(goal, goalPosition, Quaternion.identity);
						Instantiate(egg, eggPosition, Quaternion.identity);
						Instantiate(boundaryPrefab, leftBoundaryPosition, Quaternion.identity);
						Instantiate(boundaryPrefab, rightBoundaryPosition, Quaternion.identity);

						float enemy1Position = Random.Range(enemyMinPosition, enemyMaxPosition);
						// Spawn 1 enemy
						if (GameController.Instance.levelNum >= GameParameters.Instance.EnemyHardStartLevel)
						{
								// Spawn a hard enemy
								Instantiate(EnemyHardPrefab, new Vector3(enemy1Position, GameParameters.Instance.EnemyPositionY, 0), Quaternion.identity);
						}
						else if (GameController.Instance.levelNum >= GameParameters.Instance.EnemyStartLevel)
						{
								// Spawn an easy enemy
								Instantiate(EnemyPrefab, new Vector3(enemy1Position, GameParameters.Instance.EnemyPositionY, 0), Quaternion.identity);
						}


						// If we're supposed to spawn multiple enemies and this isn't the first time we're spawning a hard one, spawn a new easy one
						if (GameController.Instance.levelNum >= GameParameters.Instance.MultipleEnemyStartLevel && GameController.Instance.levelNum != GameParameters.Instance.EnemyHardStartLevel)
						{
								if ((enemyMinPosition + 5f) > enemy1Position)
								{
										Instantiate(EnemyPrefab, new Vector3(enemyMinPosition, GameParameters.Instance.EnemyPositionY, 0), Quaternion.identity);
								}
						}
										
				}

		}

}
