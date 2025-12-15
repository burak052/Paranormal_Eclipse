using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Model inside Capsule")]
    public GameObject maleModel;

    private Animator _animator;
    private CharacterController _controller;

    private bool isCrouching = false;

    void Start()
    {
        if (maleModel != null)
            _animator = maleModel.GetComponent<Animator>();
        else
            Debug.LogError("Male Model referans� atanmad�!");

        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_animator != null && _controller != null)
        {
            bool wPressed = Input.GetKey(KeyCode.W);
            bool sPressed = Input.GetKey(KeyCode.S);
            bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
            bool ctrlPressed = Input.GetKey(KeyCode.LeftControl);

            if (ctrlPressed)
            {
                isCrouching = true;
            }
            else
                isCrouching = false;

            // Ko�ma �ncelikli
            bool isRunning = wPressed && shiftPressed;
            bool isWalking = ((wPressed || sPressed) && !isRunning && !ctrlPressed);
            bool isCrouchingWalking = ((wPressed || sPressed) && !isRunning && ctrlPressed);

            Debug.Log("yürüme "  + isWalking);
            Debug.Log("çömelmeyürüme" +isCrouchingWalking);
            Debug.Log("çömelme " + isCrouching);

            // Animator parametrelerini g�ncelle
            _animator.SetBool("isRunning", isRunning);
            _animator.SetBool("isWalking", isWalking);
            _animator.SetBool("isWalkingCrounching", isCrouchingWalking);
            _animator.SetBool("isCrouching", isCrouching);

        }
    }
}