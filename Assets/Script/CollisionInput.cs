using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInput : MonoBehaviour
{
	private MVRPModel Model;

	public void InjectModel(MVRPModel model)
	{
		Model = model;
	}


	private void OnTriggerEnter(Collider other)
	{
		Model.GameState.Value = GameStates.GameOver;
	}
}