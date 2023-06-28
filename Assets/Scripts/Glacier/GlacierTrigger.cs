using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast
{
    public abstract class GlacierTrigger : MonoBehaviour
    {

				void OnTriggerEnter2D(Collider2D other)
				{
						if (IsColliderGlacier(other))
						{
								TriggerEntered();
						}
				}

				void OnTriggerExit2D(Collider2D other)
				{
						if (IsColliderGlacier(other))
						{
								TriggerExited();
						}
				}
		
				// Returns true if the collider is named "Glacier"
				bool IsColliderGlacier(Collider2D other)
				{
						return other.gameObject.tag == "Glacier";
				}

				void TriggerEntered()
				{
						EnterPayload();
				}

				void TriggerExited()
				{
						ExitPayload();
				}
		
				protected virtual void EnterPayload()
				{
						// Effect when glacier enters trigger
				}

		
				protected virtual void ExitPayload()
				{
						// Effect when glacier exits trigger
				}

    }
    
}
