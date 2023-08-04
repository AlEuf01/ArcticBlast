using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		public class Obstacle : MonoBehaviour, IEnemy
		{

		
				public void FartOn()
				{
						// Do nothing
						transform.parent.GetComponent<ObstacleContainer>().FartOn();
				}

				public void MegaFartOn()
				{

						transform.parent.GetComponent<ObstacleContainer>().FartOn();
				}
		}
}
