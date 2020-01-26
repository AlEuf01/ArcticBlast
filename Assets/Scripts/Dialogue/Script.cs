using System.Collections;
using UnityEngine;
using Ink.Runtime;

namespace ArcticBlast {
    
    public class Script : MonoBehaviour
    {
	// Compiled JSON asset
	public TextAsset inkAsset;

	// The Ink story being wrapped
	Story _inkStory;

	void Awake() {
	    _inkStory = new Story(inkAsset.text);

	    AdvanceStory();
	}

	void OnEnable() {
	    Events.OnChoosePath += ChoosePath;
	}

	void OnDisable() {
	    Events.OnChoosePath -= ChoosePath;
	}

	void ChoosePath(string knotName) {
	    try {
		Debug.Log(string.Format("Choosing path named {0}", knotName));
		_inkStory.ChoosePathString(knotName);

		_inkStory.Continue();
		
		Debug.Log("Current story text: " + _inkStory.currentText);
		
		UIEvents.ShowSpeech(_inkStory.currentText);
		// AdvanceStory();
	    } catch (StoryException e) {
		Debug.LogError(string.Format("No knot specified for {0}; check the Ink script", knotName));
		Debug.LogException(e);
	    }
	}
	
	void AdvanceStory() {
	    if (_inkStory.canContinue) {
		string text = _inkStory.Continue();

		// Remove white space
		text = text.Trim();
		
		UIEvents.ShowSpeech(text);
	    } else if (_inkStory.currentChoices.Count > 0) {
		for (int i = 0; i < _inkStory.currentChoices.Count; ++i) {
		    Choice choice = _inkStory.currentChoices[i];

		    // TODO: Show Choice
		    Debug.Log("Choice " + (i + 1) + ". " + choice.text);
		}
	    } else {
		// The story is finished
	    }
	}
    }
}
