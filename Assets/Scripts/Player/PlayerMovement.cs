using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
		/// <summary>
    /// Handles movement and jumping for a character
		/// </summary>
    public class PlayerMovement : Character
    {

				/// <summary>
				/// Collider to check if the player is grounded
				/// </summary>
				GroundChecker GroundChecker;

				bool isJumping = false;
				
				float moveX = 0f;
				float moveY = 0f;
				bool jump = false;

				bool checkInput = true;
				bool runningToEgg = false;

				const float RANGE_EGG_MAX = 8.0f;
				const float RANGE_EGG_MIN = 2.0f;

				private Transform egg;

				protected override void Start()
				{
						base.Start();
						GroundChecker = GetComponent<GroundChecker>();
						egg = GameObject.FindObjectOfType<Egg>().transform;
				}

				void OnEnable()
				{
						Events.OnCompleteLevel += RunToEgg;
				}
				
				void OnDisable()
				{
						Events.OnCompleteLevel -= RunToEgg;
				}

				void Update()
				{
						if (checkInput == true)
						{
								moveX = Input.GetAxisRaw("Horizontal") * GameParameters.Instance.PlayerSpeed;
								moveY = rb.velocity.y;
								jump = Input.GetButtonDown("Jump") || Input.GetKeyUp(KeyCode.UpArrow);
						}
						
				}
				void FixedUpdate()
				{

						if (checkInput == true)
						{
								Move();														
								Land();
								Jump();
						}
						else
						{
								Land();
								if (runningToEgg)
								{
										MoveToEgg();
								}
						}
				}
		
				// Handles movement
				void Move()
				{

						float speed = Mathf.Abs(moveX * Time.fixedDeltaTime * 10f);
						animator.SetFloat("Speed", speed);
						
						UpdateFlip(moveX);
			
						rb.velocity = new Vector2(moveX, moveY);
						
				}

				void MoveToEgg()
				{
						if (transform.position.x < egg.position.x - RANGE_EGG_MIN)
						{
								moveX = 1.5f * GameParameters.Instance.PlayerSpeed;
						}
						else
						{
								moveX = 0;
						}

						moveY = rb.velocity.y;

						Move();
				}

		
				void Jump()
				{
						if (jump && GroundChecker.IsGrounded)
						{
								rb.AddForce(Vector2.up * GameParameters.Instance.PlayerJumpForce);
				
								// Tie events to jumping
								PlatformerEvents.Jump();

								animator.SetBool("IsJumping", true);
								isJumping = true;
						}

						jump = false;
				}

				void Land()
				{
						if (isJumping && GroundChecker.IsGrounded)
						{
								isJumping = false;
								animator.SetBool("IsJumping", false);
						}
				}
				
				// Update the flip direction of the sprite
				void UpdateFlip(float deltaX)
				{						
	    
						if (deltaX < 0.0f && !sr.flipX )
						{
								// If moving left and not flipped
								FlipSprite();
						}
						else if (deltaX > 0.0f && sr.flipX)
						{
								// If moving right and flipped
								FlipSprite();	
						}		
				}
	
				void FlipSprite()
				{
						sr.flipX = !sr.flipX;					
				}

				/// <summary>
				/// Play Level Over animation
				/// </summary>				
				void RunToEgg()
				{
						// Prevent the player from moving						
						checkInput = false;
						animator.SetBool("IsJumping", false);

						runningToEgg = true;
						sr.flipX = false;
						
						// Check to see if within range of the egg
						if (transform.position.x < egg.position.x - RANGE_EGG_MAX)
						{
								// Teleport the player closer to the egg
								transform.position = new Vector3(egg.position.x - RANGE_EGG_MAX, egg.position.y, transform.position.z);
						}

						
				}
	
    }
    
}
