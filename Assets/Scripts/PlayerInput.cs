using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";

    private Vector3 _inputAxis;
    public static Action<Vector3> OnInput;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _inputAxis.Set(horizontal, 0, vertical);

        OnInput?.Invoke(_inputAxis);
    }
}