using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MVRPView : MonoBehaviour
{
	[SerializeField]
	private GameObject StartUI;

	[SerializeField]
	private Transform Cube;

	[SerializeField]
	private Image GameOverImage;

	[SerializeField]
	private Transform CameraTransform;

	[SerializeField]
	private GameObject WallPrefab;
	[SerializeField]
	private Transform StageTransform;


	[SerializeField]
	private TMP_Text ScoreText;

	public void SetCubePosition(Vector3 position)
	{
		Cube.position = position;

		//カメラ位置の調整
		Vector3 cameraTargetPosition = position;
		cameraTargetPosition.y = 5.0f;

		//カメラが向いている方向の単位ベクトル
		Vector3 cameraFaceVector = CameraTransform.rotation * Vector3.forward;
		CameraTransform.position = cameraTargetPosition - cameraFaceVector * 10f;


		//スコアのセット
		ScoreText.text = position.x.ToString("F2") + "m";
	}

	public void OnGameStateChange(GameStates newState)
	{
		switch (newState)
		{
			case GameStates.Title:
				StartUI.SetActive(true);
				GameOverImage.enabled = false;
				break;

			case GameStates.Playing:
				StartUI.SetActive(false);
				GameOverImage.enabled = false;
				break;

			case GameStates.GameOver:
				StartUI.SetActive(false);
				GameOverImage.enabled = true;
				break;
		}

	}

	private List<GameObject> Walls = new List<GameObject>();

	public void CreateWalls(List<Vector3> positions)
	{
		Debug.Log("View CreateWalls");

		foreach (var position in positions)
		{
			GameObject wallObject = Instantiate(WallPrefab, StageTransform);
			wallObject.transform.position = position;
			Walls.Add(wallObject);
		}
	}

	public void DestroyAllWalls()
	{
		foreach (var wall in Walls)
		{
			Destroy(wall);
		}

		Walls.Clear();
	}


}