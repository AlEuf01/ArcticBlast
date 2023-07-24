using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// Glacier.cs
    /// A fatal collider that chases the player
		/// </summary>
    public class Glacier : MonoBehaviour
    {

				/// <summary>
				/// The movement speed of the glacier, going forward
				/// </summary>
				public float Speed = 1f;

				/// <summary>
				/// The speed when pushed back by the player
				/// </summary>
				public float PushBackSpeed = 2f;

				/// <summary>
				/// The length of time to push back the glacier
				/// </summary>
				public float PushBackDuration = 1f;

				/// <summary>
				/// True if the glacier is currently sliding backwards
				/// </summary>
				private bool _isPushingBack;

				/// <summary>
				/// Variable amount of force to slide the glacier back by
				/// </summary>
				private float _slideBackForce = 0.0f;

				void OnEnable()
				{
						Events.OnMeltGlacier += PushBack;
				}
				
				void OnDisable()
				{
						Events.OnMeltGlacier -= PushBack;
				}
								
				void FixedUpdate()
				{
						Move();
				}

				// Moves the glacier incrementally
				void Move()
				{						
						if (_isPushingBack)
						{
								// Slide back away from the egg
								SlideBack();
						}
						else
						{
								// Continually slide forward
								SlideForward();
						}
				}
				// Push back the glacier by the target amount
				void PushBack(float amount)
				{
						_isPushingBack = true;
						_slideBackForce = amount;
						StartCoroutine(ResumeForwardMovement());
				}

				// Slide forwards by a given amount
				void SlideForward()
				{
						Vector2 amount = new Vector2(Speed * Time.deltaTime, 0f);
						transform.Translate(amount);
				}

				// Slide backwards by a given amount
				void SlideBack()
				{
						transform.Translate(new Vector2(-PushBackSpeed * Time.deltaTime * _slideBackForce, 0f));
				}

				// Resume moving forward after the given duration
				IEnumerator ResumeForwardMovement()
				{	   
						yield return new WaitForSeconds(PushBackDuration);	    
						_isPushingBack = false;
				}
    }
    
}
