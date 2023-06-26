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

				bool isMidair = false;
	
				protected override void Start() {
						base.Start();
						GroundChecker = GetComponent<GroundChecker>();
				}
		
				void FixedUpdate() {
						Move();
						Jump();
				}
		
				// Handles movement
				void Move() {
						float deltaX = Input.GetAxisRaw("Horizontal") * Speed;
			
						UpdateAnimator(deltaX != 0, GroundChecker.IsGrounded);
			
						UpdateFlip(deltaX);
			
						// Update the velocity
						rb.velocity = new Vector2(deltaX, rb.velocity.y);
			
				}

				bool IsJumping() {
						// If pressing the jump toggles
						if (Input.GetButtonDown("Jump") || Input.GetKeyUp(KeyCode.UpArrow)) {
								// Only let the player jump if they are grounded
								return GroundChecker.IsGrounded;
						} else {
								return false;
						}
				}
		
				void Jump() {
						if (IsJumping()) {
								rb.AddForce(Vector2.up * JumpForce);
				
								// Tie events to jumping
								PlatformerEvents.Jump();
						}
				}
		
				// Update the Animator to reflect the player's current state
				void UpdateAnimator(bool isWalking = false, bool isGrounded = false) {
						animator.SetBool("isWalking", isGrounded && isWalking);

						if (isGrounded)
						{
								animator.SetBool("isJumping", false);
						}
						else
						{					 

								animator.SetBool("isJumping", true);
								// TODO: Ease in and out of jump
								
						}

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
