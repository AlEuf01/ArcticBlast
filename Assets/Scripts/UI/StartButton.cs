using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.UI {
	
    public class StartButton : MonoBehaviour, IButton
    {
		
		public void OnClick() {
			GameController.GotoStartLevel();
		}
    }
    
}
