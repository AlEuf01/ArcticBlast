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
	
				protected override void Start()
				{
						base.Start();
						GroundChecker = GetComponent<GroundChecker>();
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
								MoveToEgg();
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
						if (transform.position.x < GameObject.FindObjectOfType<EndOfLevel>().transform.position.x - 2)
						{
								moveX = 1.5f * GameParameters.Instance.PlayerSpeed;
						}
						else
						{
								moveX = 0;
						}

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

				void RunToEgg()
				{
						checkInput = false;
						animator.SetBool("IsJumping", false);
						sr.flipX = false;

						
				}
	
    }
    
}
