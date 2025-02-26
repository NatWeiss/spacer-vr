using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DisableGrabbingHandModel : MonoBehaviour
{
	public GameObject leftHandModel;
	public GameObject rightHandModel;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		var grabInteractable = GetComponent<XRGrabInteractable>();
		grabInteractable.selectEntered.AddListener(HideGrabbingHand);
		grabInteractable.selectExited.AddListener(ShowGrabbingHand);
	}

	public void HideGrabbingHand(SelectEnterEventArgs args)
	{
		// args.interactorObject is an IXRSelectInteractor
		// https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.0/api/UnityEngine.XR.Interaction.Toolkit.IXRSelectInteractor.html
		// which has a transform
		// https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Transform.html
		// which inherits some properties from gameobject
		// https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.html
		//ShowModel(args.interactorObject.transform.parent.tag, false);
		// or you can directly reference the game object:
		ShowModel(args.interactorObject.transform.parent.gameObject.tag, false);
	}
	public void ShowGrabbingHand(SelectExitEventArgs args)
	{
		ShowModel(args.interactorObject.transform.parent.tag, true);
	}

	private void ShowModel(string tag, bool show)
	{
		var model = (tag == "RightHand" ? rightHandModel : leftHandModel);
		//Debug.Log("Show model " + tag + " " + show);
		model.SetActive(show);
	}

	// Update is called once per frame
	void Update()
	{
	}
}
