using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVRPView : MonoBehaviour
{
	[SerializeField]
	private Transform Cube;

	public void SetCubePosition(Vector3 position)
	{
		Cube.position = position;
	}
}