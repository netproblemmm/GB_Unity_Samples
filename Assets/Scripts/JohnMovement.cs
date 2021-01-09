using UnityEngine;

//[(RequireComponent(typeof(Rigidbody))]

public class JohnMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    [SerializeField] private float _moveSpeedMultiplier = 15f;
    [SerializeField, Range(0.0f, 1.0f)] private float _percentageOfSlowdown = 0.01f;
    public float PercentageOfSlowdown => (1 - _percentageOfSlowdown);
    private Rigidbody _body;
    private Vector3 _moveDirection;
    private bool _isMoved = false;

    void Start()
    {
        _body = GetComponent<Rigidbody>();

        PlayerInput.OnInput += Move;
    }

    private void Move(Vector3 input)
    {
        _moveDirection.Set(input.x, 0, input.z);

        // Двигаем
        _body.AddForce(_moveDirection * _moveSpeedMultiplier);
        
        _isMoved = true;
    }

    private void Update()
    {
        // если получать Input в Update, то перемещение Джона работает.
        // Если вынести в отдельный класс (как сейчас сделано в Start и Move), то не работает.
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _moveDirection.Set(horizontal, 0, vertical);

        // Двигаем
        _body.AddForce(_moveDirection * _moveSpeedMultiplier);

        // Смотрим по направлению движения
        transform.LookAt(_moveDirection + transform.position);
    }

    private void FixedUpdate()
    {
        if (_isMoved) return;
        _body.velocity = new Vector3(_body.velocity.x * PercentageOfSlowdown, _body.velocity.y, _body.velocity.z * PercentageOfSlowdown);
    }

    private void LateUpdate()
    {
        if (_moveDirection == Vector3.zero)
        {
            _isMoved = false;
        }
    }
}  