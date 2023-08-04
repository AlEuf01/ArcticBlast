using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		public class Airplane : MonoBehaviour
		{

				public float Speed = 5.0f;

				void FixedUpdate()
				{
						if (transform.position.x < GameParameters.Instance.MinGlacierX)
						{
								Destroy(gameObject);
						}
						else
						{
								transform.Translate(new Vector2(Speed * Time.fixedDeltaTime * -1, 0));
						}
				}
		}

}
