using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArcticBlast.UI {
    
    public class AmmoStatus : MonoBehaviour
    {
	
				public Text label;
				public Slider slider;		
	
				public void SetValue(int amount) {
						label.text = amount.ToString();
						slider.value = amount;
				}
	
				void Start() {
						SetValue(0);
				}
	
				void OnEnable() {
						Events.OnUpdateAmmo += SetValue;
				}
	
				void OnDisable() {
						Events.OnUpdateAmmo -= SetValue;
				}
	
	
    }
    
}
