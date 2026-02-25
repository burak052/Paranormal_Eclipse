using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Model inside Capsule")]
    public GameObject maleModel;
    public GameObject malelabModel;

    public bool isSetAnimator = false;

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
            bool aPressed = Input.GetKey(KeyCode.A);
            bool dPressed = Input.GetKey(KeyCode.D);
            bool spacePressed = Input.GetKeyDown(KeyCode.Space);
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
            if(GetComponent<Stamina>() != null)
            {
                bool run = GetComponent<Stamina>().canRun;
                isRunning = wPressed && shiftPressed && run;
            }
            bool isJumping = spacePressed && !ctrlPressed;
            bool isWalking = ((wPressed || sPressed || aPressed || dPressed) && !isRunning && !ctrlPressed && !spacePressed);
            bool isCrouchingWalkingFoward =((wPressed || dPressed || aPressed) && !sPressed && !isRunning && ctrlPressed);
            bool isCrouchingWalkingBack = (sPressed || (sPressed && (dPressed || aPressed)) && !isRunning && ctrlPressed);


            // Animator parametrelerini g�ncelle
            _animator.SetBool("isRunning", isRunning);
            _animator.SetBool("isWalking", isWalking);
            _animator.SetBool("isJumping", isJumping);
            _animator.SetBool("isWalkingCrounching", isCrouchingWalkingFoward);
            _animator.SetBool("isWalkingCrounchingBack", isCrouchingWalkingBack);
            _animator.SetBool("isCrouching", isCrouching);

        }
    }

    public void ChangeOutfit()
    {
        if(malelabModel != null)
        {
            maleModel.SetActive(false);
            malelabModel.SetActive(true);
            _animator = malelabModel.GetComponent<Animator>();
        }
    }
    public void SetAnimator()
    {
        isSetAnimator = true;
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isWalking", false);
        _animator.SetBool("isJumping", false);
        _animator.SetBool("isWalkingCrounching", false);
        _animator.SetBool("isWalkingCrounchingBack", false);
        _animator.SetBool("isCrouching", false);
    }
}