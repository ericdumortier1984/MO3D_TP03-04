using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraConfigurator : MonoBehaviour
{
    public Camera mainCamera;
    public Button projectionButton;
    public Slider fovSlider;
    public Slider sizeSlider;
    public Slider nearClipSlider;
    public Slider farClipSlider;

    private bool isPerspective = true;

	void Start()
    {
        //Inicializamos los controles de UI con los valores por defecto de la camara
        fovSlider.maxValue = 180;
        fovSlider.minValue = 1;
        fovSlider.value = mainCamera.fieldOfView;
        fovSlider.gameObject.SetActive(mainCamera.orthographic == false);

        sizeSlider.maxValue = 100;
        sizeSlider.minValue = 0.1f;
        sizeSlider.value = mainCamera.orthographicSize;
        sizeSlider.gameObject.SetActive(mainCamera.orthographic == true);

        nearClipSlider.maxValue = 100;
        nearClipSlider.minValue = 0.1f;
        nearClipSlider.value = mainCamera.nearClipPlane;

        farClipSlider.maxValue = 1000;
        farClipSlider.minValue = 0.1f;
        farClipSlider.value = mainCamera.farClipPlane;

        //Asiganamos las funciones a los eventos
        projectionButton.onClick.AddListener(ToggleProjection);
        fovSlider.onValueChanged.AddListener(UpdateFov);
        sizeSlider.onValueChanged.AddListener(UpdateSize);
        nearClipSlider.onValueChanged.AddListener(UpdateNearClip);
        farClipSlider.onValueChanged.AddListener(UpdateFarClip);
    }

    void ToggleProjection()
    {
        isPerspective = !isPerspective;
        mainCamera.orthographic = !isPerspective;

        //Mostrar u ocultar sliders segun perspectiva
        fovSlider.gameObject.SetActive(isPerspective);
        sizeSlider.gameObject.SetActive(!isPerspective);
    }

    void UpdateFov(float value)
    {
        if (isPerspective)
        {
            mainCamera.fieldOfView = value;
        }
    }

    void UpdateSize(float value)
    {
        if (!isPerspective)
        {
            mainCamera.orthographicSize = Mathf.Max(value, 0.1f);
        }
    }

    void UpdateNearClip(float value)
    {
		if (value < mainCamera.farClipPlane && value >= 0.1f)
		{
			mainCamera.nearClipPlane = value;
		}
	}

    void UpdateFarClip(float value)
    {
		if (value > mainCamera.nearClipPlane)
		{
			mainCamera.farClipPlane = value;
		}
	}

	void OnDrawGizmos()
	{
        //Dibujo Gizmo para ver posicion y rotacion de Main Camera
        Gizmos.color = Color.red;
        Gizmos.matrix = mainCamera.transform.localToWorldMatrix;
        Gizmos.DrawSphere(mainCamera.transform.position, 10f);
        Gizmos.DrawLine(mainCamera.transform.position, mainCamera.transform.forward * 20);
	}
}
