using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MVRPInput : MonoBehaviour
{
	[SerializeField]
	private Button GameStartButton;

	[SerializeField]
	private Button ActionButton;

	private MVRPModel Model;

	public void InjectModel(MVRPModel model)
	{
		Model = model;
	}

	void Start()
	{
		GameStartButton.OnClickAsObservable()
			.Subscribe(_ => Model.GameState.Value = GameStates.Playing);

		ActionButton.OnClickAsObservable()
			.Subscribe(_ => Jump());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	private void Jump()
	{
		Vector3 velocity = Model.CubeVelocity.Value;
		velocity.y = 7f;
		Model.CubeVelocity.Value = velocity;
	}
}