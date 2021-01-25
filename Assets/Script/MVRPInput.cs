using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MVRPInput : MonoBehaviour
{
    [SerializeField]
    private Button UpButton;
    [SerializeField]
    private Button DownButton;
    [SerializeField]
    private Button LeftButton;
    [SerializeField]
    private Button RightButton;

    private MVRPModel Model;

    public void InjectModel(MVRPModel model)
    {
        Model = model;
    }

    void Start()
    {
        UpButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Vector3 position = Model.CubePosition.Value;
                position.z += 3f;
                Model.CubePosition.Value = position;
            });
        DownButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Vector3 position = Model.CubePosition.Value;
                position.z -= 3f;
                Model.CubePosition.Value = position;
            });



    }
}