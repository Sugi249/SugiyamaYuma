using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVRPEntryPoint : MonoBehaviour
{
    [SerializeField]
    private MVRPInput Input;
    [SerializeField]
    private CollisionInput Collision;

    [SerializeField]
    private MVRPView View;

    void Start()
    {
        MVRPModel model = new MVRPModel();
        MVRPUseCase useCase = new MVRPUseCase(model);

        Input.InjectModel(model);
        Collision.InjectModel(model);

        MVRPPresenter presenter = new MVRPPresenter(model, View);
    }

}