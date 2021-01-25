using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MVRPPresenter
{
	public MVRPPresenter(MVRPModel model, MVRPView view)
	{
		model.CubePosition.Subscribe(
			position => view.SetCubePosition(position));
	}
}