using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{

		/// <summary>
		/// Glacier.cs
    /// A fatal collider that chases the player
		/// </summary>
    public class Glacier : MonoBehaviour
    {

				private float Speed = 1.0f;
				
				/// <summary>
				/// True if the glacier is currently sliding backwards
				/// </summary>
				private bool _isPushingBack;

				/// <summary>
				/// Variable amount of force to slide the glacier back by
				/// </summary>
				private float _slideBackForce = 0.0f;

				private bool levelDone;
				
				void OnEnable()
				{
						Events.OnMeltGlacier += PushBack;
						Events.OnCompleteLevel += StopMovingForward;
				}
				
				void OnDisable()
				{
						Events.OnMeltGlacier -= PushBack;
						Events.OnCompleteLevel += StopMovingForward;
				}

				void Start()
				{
						// Set speed as a range
						Speed = Mathf.Clamp(GameParameters.Instance.GlacierSpeed + GameParameters.Instance.GlacierSpeedIncreaseRate * GameController.Instance.levelNum, GameParameters.Instance.GlacierSpeed, GameParameters.Instance.MaxGlacierSpeed);
						
				}
				
				void FixedUpdate()
				{
						Move();
				}

				// Moves the glacier incrementally
				void Move()
				{						
						if (_isPushingBack || levelDone)
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
						transform.Translate(new Vector2(GameParameters.Instance.GlacierPushBackSpeed * Time.deltaTime * _slideBackForce * -1, 0f));
				}

				// Resume moving forward after the given duration
				IEnumerator ResumeForwardMovement()
				{	   
						yield return new WaitForSeconds(GameParameters.Instance.GlacierPushBackDuration);	    
						_isPushingBack = false;
				}

				void StopMovingForward()
				{
						levelDone = true;
				}
    }
    
}
