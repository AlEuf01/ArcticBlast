using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.UI {

	// Press this button to start the game
    public class StartButton : MonoBehaviour, IButton
    {
		
		public void OnClick() {
			Events.Start();
		}
    }
    
}
