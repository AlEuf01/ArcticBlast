using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ArcticBlast.Ammo;

namespace ArcticBlast.UI {

    public class AmmoStatus : MonoBehaviour
    {
		public Text label;

		public Slider slider;

		void OnGUI() {
			label.text = "Ammo: " + AmmoManager.Amount.ToString();

			slider.value = AmmoManager.Amount;
			
		}
    }
    
}
