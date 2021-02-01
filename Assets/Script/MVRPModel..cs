using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MVRPModel
{
	public ReactiveProperty<GameStates> GameState
		= new ReactiveProperty<GameStates>(GameStates.Title);

	public ReactiveProperty<Vector3> CubePosition
		= new ReactiveProperty<Vector3>(new Vector3(0f, 6f, 0f));

	public ReactiveProperty<Vector3> CubeVelocity
		= new ReactiveProperty<Vector3>(new Vector3(7f, 0f, 0f));

	public const float Gravity = -10f;


	public List<Vector3> Walls;
	public Subject<Unit> OnWallsChanged = new Subject<Unit>();
}

public enum GameStates
{
	Title,
	Playing,
	GameOver,
}
