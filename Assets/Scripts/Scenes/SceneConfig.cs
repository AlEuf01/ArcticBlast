using UnityEngine;

namespace ArcticBlast
{

    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Scene Configuration")]
    public class SceneConfig : ScriptableObject 
    {

				public string Start;
				public string Title = "Title";
				public string GameOver = "_GameOver";
				public string[] UserInterface = new string[]{};

    }
    
}

