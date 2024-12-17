using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Button switchCameraButton;
	public Button positionButton;

	public List<Transform> cameraMarkers;
	private int currentMarkerIndex = 0;

	private void Start()
	{
		switchCameraButton.onClick.AddListener(SwitchCamera);
		positionButton.onClick.AddListener(SwitchPosition);
		ShowCamera(mainCamera);
	}

	private void SwitchCamera()
	{
		if (mainCamera.gameObject.activeSelf)
		{
			ShowCamera(secondaryCamera);
		}
		else
		{
			ShowCamera(mainCamera);
		}
	}

	private void ShowCamera(Camera cameraToShow)
	{
		mainCamera.gameObject.SetActive(cameraToShow == mainCamera);
		secondaryCamera.gameObject.SetActive(cameraToShow == secondaryCamera);
	}

	private void SwitchPosition()
	{
		if (secondaryCamera.gameObject.activeSelf)
		{
			currentMarkerIndex = (currentMarkerIndex + 1) % cameraMarkers.Count;
			SetCameraToMarker(currentMarkerIndex);
		}
	}

	private void SetCameraToMarker(int index)
	{
		Transform marker = cameraMarkers[index];
		secondaryCamera.transform.position = marker.position;
		secondaryCamera.transform.rotation = marker.rotation;
	}
}
