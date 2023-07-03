using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast {

		/// <summary>
		/// GlacierMovement.cs
    /// A fatal collider that chases the player
		/// </summary>
    public class GlacierMovement : MonoBehaviour
    {
	
				// The movement speed of the glacier
				public float Speed = 1f;

				// The speed when pushing back, after firing
				public float PushBackSpeed = 2f;
	
				bool isPushingBack;
				float scalar = 0.0f;
	
				void FixedUpdate() {

						if (isPushingBack) {
								// Slide in to the right
								SlideBack();
						} else {
								Slide();
						}
				}
	
				void Slide() {
						Vector2 amount = new Vector2(Speed * Time.deltaTime, 0f);
						transform.Translate(amount);
				}

				void SlideBack() {
						transform.Translate(new Vector2(-PushBackSpeed * Time.deltaTime * scalar, 0f));
				}

				public void PushBack(float amount) {
						isPushingBack = true;
						scalar = amount;

						StartCoroutine(ResumeForwardMovement());
				}

				IEnumerator ResumeForwardMovement(float duration = 1.0f) {	   
						yield return new WaitForSeconds(duration);
	    
						isPushingBack = false;
				}
    }
    
}
