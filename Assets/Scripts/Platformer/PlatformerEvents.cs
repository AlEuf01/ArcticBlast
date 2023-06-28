using System;
using UnityEngine;

namespace ArcticBlast
{

		public class PlatformerEvents
		{

				public static event Action OnJump;

				public static void Jump()
				{
						if (OnJump != null) {
								OnJump();
						}
				}
		}

}
