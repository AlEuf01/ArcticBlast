using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		public class Obstacle : MonoBehaviour
		{

				void OnEnable()
				{
						Events.OnCompleteLevel += RemoveObstacle;
				}

				void OnDisable()
				{
						Events.OnCompleteLevel -= RemoveObstacle;
				}

				void RemoveObstacle()
				{
						gameObject.SetActive(false);
						// gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
						// gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				}
		}

}
