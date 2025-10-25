using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;

public class CameraMove : MonoBehaviour
{
    [SerializeField, MinMaxSlider(-20.0f, 20.0f)]
    Vector2 cameraMoveRange;

    [SerializeField] float moveSpeed;

    private InputAction moveAction;
    private float moveDirection;

    void Awake()
    {
        var inputActions = new InputActionMap("CameraControls");
        moveAction = inputActions.AddAction("Move", binding: "<Gamepad>/leftStick/x");
        moveAction.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d")
            .With("Negative", "<Keyboard>/leftArrow")
            .With("Positive", "<Keyboard>/rightArrow");

        moveAction.performed += ctx => moveDirection = ctx.ReadValue<float>();
        moveAction.canceled += ctx => moveDirection = 0f;
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        float x = moveDirection;

        if (x > 0 && transform.position.x < cameraMoveRange.y)
        {
            transform.position += Vector3.right * x * moveSpeed * Time.deltaTime;
        }
        else if (x < 0 && transform.position.x > cameraMoveRange.x)
        {
            transform.position += Vector3.right * x * moveSpeed * Time.deltaTime;
        }
    }
}