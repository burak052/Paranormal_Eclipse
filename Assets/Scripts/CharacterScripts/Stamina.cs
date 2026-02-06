using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    EasyPeasyFirstPersonController.FirstPersonController fpsController;
    CharacterController charController;
    public CanvasGroup staminaCanvasGroup;

    [Header("UI")]
    public float uiFadeSpeed = 6f;
    public Slider staminaSlider;

    [Header("Stamina")]
    public float stamina = 100f;
    public float decreaseRate = 20f;

    [Header("Exhausted Audio")]
    public AudioSource exhaustedAudio;
    public float exhaustedThreshold = 20f;
    public float exhaustedMaxVolume = 0.8f;
    public float audioFadeSpeed = 5f;
    public bool canplay = true;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        fpsController = GetComponent<EasyPeasyFirstPersonController.FirstPersonController>();

        stamina = Mathf.Clamp(stamina, 0f, 100f);

        if (staminaCanvasGroup != null)
            staminaCanvasGroup.alpha = 0f;

        if (exhaustedAudio != null)
            exhaustedAudio.volume = 0f;

        stamina = 100f;
    }

    void Update()
    {
        if(fpsController.enabled)
        {
            // ?? STAMINA BAR UI
            if (staminaSlider != null)
                staminaSlider.value = stamina;

            bool showStamina =  stamina < 40f;
            float targetAlpha = showStamina ? 1f : 0f;

            if (staminaCanvasGroup != null)
            {
                staminaCanvasGroup.alpha = Mathf.Lerp(
                    staminaCanvasGroup.alpha,
                    targetAlpha,
                    Time.deltaTime * uiFadeSpeed
                );
            }

            // ????? STAMINA MANTI�I/////////////////////////////////////////////////////////////////////
            //if (fpsController.isSprinting)
                //stamina -= decreaseRate * Time.deltaTime;
            else
                stamina += 10f * Time.deltaTime;

            stamina = Mathf.Clamp(stamina, 0f, 100f);

            // ?? SPRINT K�L�D�
            if (stamina <= 0f)
                fpsController.sprintSpeed = fpsController.walkSpeed;
            else
                fpsController.sprintSpeed = 5f;

            // ????? YORGUNLUK SES� (FADE IN / OUT)
            HandleExhaustedAudio();
        }
        else
            IncreaseStamina();
    }

    void HandleExhaustedAudio()
    {
        if (exhaustedAudio == null) return;

        bool shouldPlay = stamina <= exhaustedThreshold;

        if (shouldPlay && canplay)
        {
            if (!exhaustedAudio.isPlaying)
                exhaustedAudio.Play();

            exhaustedAudio.volume = Mathf.MoveTowards(
                exhaustedAudio.volume,
                exhaustedMaxVolume,
                Time.deltaTime * audioFadeSpeed
            );
        }
        else
        {
            exhaustedAudio.volume = Mathf.MoveTowards(
                exhaustedAudio.volume,
                0f,
                Time.deltaTime * audioFadeSpeed
            );

            if (exhaustedAudio.volume <= 0.01f && exhaustedAudio.isPlaying)
                exhaustedAudio.Stop();
        }
    }
    void IncreaseStamina()
    {
        // ?? STAMINA BAR UI
        if (staminaSlider != null)
            staminaSlider.value = stamina;

        if (staminaCanvasGroup != null)
            staminaCanvasGroup.alpha = 0f;

        stamina += 10f * Time.deltaTime;

        stamina = Mathf.Clamp(stamina, 0f, 100f);

        // ????? YORGUNLUK SES� (FADE IN / OUT)
        HandleExhaustedAudio();
    }
}
