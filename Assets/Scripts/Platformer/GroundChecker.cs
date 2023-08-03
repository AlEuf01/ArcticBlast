using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// GroundChecker.cs
		/// Determines if a character is grounded or not
		/// </summary>
		public class GroundChecker : MonoBehaviour
		{

				/// <summary>
				/// Transform that checks to see if this is grounded
				/// </summary>
				public Transform IsGroundedChecker;

				/// <summary>
				/// References the Ground layer to keep track of Ground objects
				/// </summary>
				public LayerMask[] GroundLayers;

				/// <summary>
				/// Radius to check against
				/// </summary>
				const float GROUND_CHECK_RADIUS = 0.07f;

				/// <summary>
				/// Radius to check jumps against
				/// </summary>
				const float JUMP_MIDAIR_RADIUS = 2.0f;

				/// <summary>
				/// Returns true if the player is grounded
				/// </summary>
				public bool IsGrounded
				{
						get
						{			
								if (IsGroundedChecker == null)
								{
										// Debug.LogError("Platformer needs a transform to check on whether it's grounded.");
										return false;
								}
				
								// Return true if it exists, false otherwise
								return GetGroundOverlapCircle();
						}
				}
		
				/// <summary>
				/// See if there's overlap between the player and the ground
				/// </summary>
				bool GetGroundOverlapCircle()
				{
						return GetOverlapCircle(GROUND_CHECK_RADIUS);
				}

				/// <summary>
				/// See if there's overlap between the player and the ground
				/// </summary>
				public bool IsJumpingInMidair()
				{
						return GetOverlapCircle(JUMP_MIDAIR_RADIUS);
				}

				private bool GetOverlapCircle(float radius)
				{
						
						bool result = false;
						foreach (LayerMask layer in GroundLayers)
						{
								result = result || Physics2D.OverlapCircle(IsGroundedChecker.position, radius, layer);
						}
						return result;
				}
				
		
		}
}
