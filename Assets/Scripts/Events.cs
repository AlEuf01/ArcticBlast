using System;
using UnityEngine;

namespace ArcticBlast
{
		
    /// <summary>
    /// Class to handle all events for the game
		/// </summary>
    public class Events
    {
	
				public delegate void IntEvent(int amount);
				public static event IntEvent OnUpdateAmmo;

				public delegate void FloatEvent (float amount);
				public static event FloatEvent OnMeltGlacier;

				// Event handler for completing a level
				public static event Action OnCompleteLevel;

				// Event handler for completing the game
				// TODO: Is this winning or losing?
				public static event Action OnGameOver;
	
				// Event handlers for damaing the player
				public static event Action OnKillPlayer;
				public static event Action OnHitPlayer;
	
				// Event handlers for consuming a power-up
				public static event Action OnConsumeBeanCan;
				public static event Action OnConsumeBeanBarrel;
	
				// Event handlers for firing (fart, flamethrower)
				public static event Action OnFart;
				public static event Action OnMegaFart;

				// Event handlers for pausing and unpausing
				public static event Action OnPause;
				public static event Action OnUnPause;

				// Event handlers for player firing and jumping
				public static event Action OnFire;
				public static event Action OnJump;

				// Event handler when an enemy is killed
				public static event Action OnEnemyKilled;

				
				public static void UpdateAmmo(int amount)
				{
						if (OnUpdateAmmo != null)
						{
								OnUpdateAmmo(amount);
						}
				}

				public static void MeltGlacier(float amount)
				{
						if (OnMeltGlacier != null)
						{
								OnMeltGlacier(amount);
						}
				}
				public static void EnemyKilled()
				{
						if (OnEnemyKilled != null)
						{
								OnEnemyKilled();
						}
				}
	
				public static void GameOver()
				{
						if (OnGameOver != null)
						{
								OnGameOver();
						}
				}
	
				public static void Jump()
				{
						if (OnJump != null)
						{
								OnJump();
						}
				}
		
				public static void Fire()
				{
						if (OnFire != null)
						{
								OnFire();
						}
				}
		
				public static void Pause()
				{
            if (OnPause != null)
						{
								OnPause();  
            }			
				}
	
				public static void UnPause()
				{
            if (OnUnPause != null)
						{
                OnUnPause();    
            }	    
				}
	
				public static void CompleteLevel()
				{
						if (OnCompleteLevel != null)
						{
								OnCompleteLevel();
						}
				}
	
				public static void KillPlayer()
				{
						if (OnKillPlayer != null)
						{
								OnKillPlayer();
						}
				}

				
				public static void HitPlayer()
				{
						if (OnHitPlayer != null)
						{
								OnHitPlayer();
						}
				}
				
				public static void ConsumeBeanCan()
				{
						if (OnConsumeBeanCan != null)
						{
								OnConsumeBeanCan();
						}
				}
	
				public static void ConsumeBeanBarrel()
				{
						if (OnConsumeBeanBarrel != null)
						{
								OnConsumeBeanBarrel();
						}
				}
	
				public static void Fart()
				{
						if (OnFart != null)
						{
								OnFart();
						}
				}
	
				public static void MegaFart()
				{
						if (OnMegaFart != null)
						{
								OnMegaFart();
						}
				}
	
    }
    
}

