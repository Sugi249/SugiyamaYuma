using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class MVRPUseCase
{
	private MVRPModel Model;

	public MVRPUseCase(MVRPModel model)
	{
		Model = model;

		model.GameState.Subscribe(_state =>
		{
			if (_state == GameStates.Title)
				CreateWalls();
		});

		MainThreadDispatcher.UpdateAsObservable()
			.Subscribe(_ => Update());
	}

	//UniRxを使うことにより毎フレーム呼ばれる
	private void Update()
	{
		if (Model.GameState.Value == GameStates.Playing)
		{
			UpdateCubeVelocity();
			MoveCube();
			CheckGameOver();
		}
	}

	//壁を生成する
	private void CreateWalls()
	{
		Debug.Log("CreateWalls");

		Model.Walls = new List<Vector3>();
		for (int i = 1; i < 100; i++)
		{
			//x座標は20m間隔
			float x = i * 20f;
			x += Random.Range(-5f, 5f);

			//y座標は0 or 10
			float y = 0;
			if (Random.value > 0.5f)
				y = 10f;

			Vector3 position = new Vector3(x, y, 0f);
			Model.Walls.Add(position);
		}

		MainThreadDispatcher.StartCoroutine(UpdateWallsNextFrame());
	}

	private IEnumerator UpdateWallsNextFrame()
	{
		yield return null;
		Model.OnWallsChanged.OnNext(Unit.Default);
	}


	//時間経過により、キューブが現在速度に従って動く
	private void MoveCube()
	{
		Vector3 position = Model.CubePosition.Value;

		position += Model.CubeVelocity.Value * Time.deltaTime;

		Model.CubePosition.Value = position;
	}

	//重力加速度により、キューブの速度が毎フレーム変化する
	private void UpdateCubeVelocity()
	{
		Vector3 velocity = Model.CubeVelocity.Value;

		velocity.y += MVRPModel.Gravity * Time.deltaTime;

		Model.CubeVelocity.Value = velocity;
	}


	private void CheckGameOver()
	{
		bool isGameOver = false;

		//床にぶつかったら終了
		if (Model.CubePosition.Value.y < 0.5f)
			isGameOver = true;

		//天井にぶつかったら終了
		if (Model.CubePosition.Value.y > 9.5f)
			isGameOver = true;

		if (isGameOver)
			Model.GameState.Value = GameStates.GameOver;
	}

}
