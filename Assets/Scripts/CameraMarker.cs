using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMarker : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		// Cubo verde
		Gizmos.color = Color.green;
		Gizmos.DrawCube(transform.position, new Vector3(10, 10, 10));

		// Linea roja
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 20);
	}
}
