us  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVRPEntryPoint : MonoBehaviour
{
    [SerializeField]
    private MVRPInput Input;
    [SerializeField]
    private MVRPView View;

    void Start()
    {
        MVRPModel model = new MVRPModel();

        Input.InjectModel(model);

        MVRPPresenter presenter = new MVRPPresenter(model, View);
    }

}