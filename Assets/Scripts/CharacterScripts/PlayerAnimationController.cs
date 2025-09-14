using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Model inside Capsule")]
    public GameObject maleModel;

    private Animator _animator;
    private CharacterController _controller;

    void Start()
    {
        if (maleModel != null)
            _animator = maleModel.GetComponent<Animator>();
        else
            Debug.LogError("Male Model referansý atanmadý!");

        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_animator != null && _controller != null)
        {
            bool wPressed = Input.GetKey(KeyCode.W);
            bool sPressed = Input.GetKey(KeyCode.S);
            bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

            // Koþma öncelikli
            bool isRunning = wPressed && shiftPressed;
            bool isWalking = (wPressed || sPressed) && !isRunning;

            // Animator parametrelerini güncelle
            _animator.SetBool("isRunning", isRunning);
            _animator.SetBool("isWalking", isWalking);

            // speed parametresi opsiyonel, istersen yürüme/koþma hýzýna göre ayarlayabilirsin
            Vector3 horizontalVelocity = new Vector3(_controller.velocity.x, 0f, _controller.velocity.z);
            float speed = horizontalVelocity.magnitude;
            _animator.SetFloat("SpeedMultiplier", speed / 4f); // 4f = MoveSpeed
        }
    }
}
