using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcticBlast.Ammo {
	
	public interface IAmmoManager 
	{

		void Add();
		void Remove();
		void Fill();
		void RemoveAllAmmo();		
		
		bool HasAmmo();
		bool HasMegaFartAmmo();

	}

}
