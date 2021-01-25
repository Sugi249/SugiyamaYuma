using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MVRPModel
{
	public ReactiveProperty<Vector3> CubePosition
		= new ReactiveProperty<Vector3>(new Vector3(0f, 0.5f, 0f));
}
