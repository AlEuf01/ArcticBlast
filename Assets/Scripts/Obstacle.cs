using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// A snowball or other static obstacle
		/// </summary>
		public class Obstacle : MonoBehaviour, IEnemy
		{

				private int hitPoints = 3;

				public GameObject[] states;
				
				void OnEnable()
				{
						Events.OnCompleteLevel += RemoveObstacle;
				}

				void OnDisable()
				{
						Events.OnCompleteLevel -= RemoveObstacle;
				}

				void Start()
				{
						SetActiveState();
				}
				
				void RemoveObstacle()
				{
						gameObject.SetActive(false);
				}

				public void FartOn()
				{
						// Do nothing
				}

				public void MegaFartOn()
				{
						
						hitPoints--;
						if (hitPoints == 0)
						{
								RemoveObstacle();
						}
						else
						{
								SetActiveState();
						}
				}

				/// <summary>
				/// Only show the sprite renderer and collider that corresponds to the current state of the obstacle
				/// </summary>
				void SetActiveState()
				{						
						// Update the state to be smaller
						int n = hitPoints - 1;
						foreach(GameObject state in states)
						{
								state.SetActive(false);
						}
						states[n].SetActive(true);
				}
		}

}
