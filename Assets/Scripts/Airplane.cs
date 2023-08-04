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
						transform.Translate(new Vector2(Speed * Time.fixedDeltaTime * -1, 0));
				}
		}

}
