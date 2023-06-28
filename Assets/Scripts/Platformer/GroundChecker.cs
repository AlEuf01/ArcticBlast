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
				public LayerMask GroundLayer;

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
								return GetGroundOverlapCircle() != null;
						}
				}
		
				/// <summary>
				/// See if there's overlap between the player and the ground
				/// </summary>
				Collider2D GetGroundOverlapCircle()
				{
						return Physics2D.OverlapCircle(IsGroundedChecker.position, GROUND_CHECK_RADIUS, GroundLayer);
				}

				/// <summary>
				/// See if there's overlap between the player and the ground
				/// </summary>
				public bool IsJumpingInMidair()
				{
						return Physics2D.OverlapCircle(IsGroundedChecker.position, JUMP_MIDAIR_RADIUS, GroundLayer);
				}
		
		}
}
