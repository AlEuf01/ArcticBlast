using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cyborg.Platformer {

    // Handles movement and jumping for a character
    public class PlayerMovement : Character
    {
				// The speed of the player's movement
				public int Speed = 6;
	
				// The amount of force in a jump
				public int JumpForce = 1250;
		
				// Collider to check if the player is grounded
				GroundChecker GroundChecker;

				bool isLanding = false;

				float moveX = 0f;
				float moveY = 0f;
				bool jump = false;
	
				protected override void Start() {
						base.Start();
						GroundChecker = GetComponent<GroundChecker>();
				}

				void Update()
				{
						moveX = Input.GetAxisRaw("Horizontal") * Speed;
						moveY = rb.velocity.y;
						jump = Input.GetButtonDown("Jump") || Input.GetKeyUp(KeyCode.UpArrow);
						
				}
				void FixedUpdate() {
						Move();
						Jump();
				}
		
				// Handles movement
				void Move() {

						float speed = Mathf.Abs(moveX * Time.fixedDeltaTime * 10f);
						animator.SetFloat("Speed", speed);
						animator.SetBool("IsJumping", !GroundChecker.IsGrounded);

						if (GroundChecker.IsGrounded)
						{
								isLanding = false;
						}
						
						UpdateFlip(moveX);
			
						// Update the velocity
						if (isLanding)
						{
								// do nothing
						}
						else
						{
								rb.velocity = new Vector2(moveX, moveY);
						}
						
				}

		
				void Jump() {
						if (jump && GroundChecker.IsGrounded) {
								rb.AddForce(Vector2.up * JumpForce);
				
								// Tie events to jumping
								PlatformerEvents.Jump();
						}

						jump = false;
				}

				void Land()
				{
						isLanding = true;					 
				}
				
				// Update the flip direction of the sprite
				void UpdateFlip(float deltaX) {
	    
						if (deltaX < 0.0f && !sr.flipX ) {
								// If moving left and not flipped
								FlipSprite();
						} else if (deltaX > 0.0f && sr.flipX) {
								// If moving right and flipped
								FlipSprite();	
						}		
				}
	
				void FlipSprite() {
						sr.flipX = !sr.flipX;					
				}
	
    }
    
}
