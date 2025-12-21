using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public EasyPeasyFirstPersonController.FirstPersonController fpsController;
    public CharacterController charController;
    public CanvasGroup staminaCanvasGroup;

    [Header("UI")]
    public float uiFadeSpeed = 6f;
    public Slider staminaSlider;

    [Header("Stamina")]
    public float stamina = 100f;
    public float decreaseRate = 20f;

    [Header("Exhausted Audio")]
    public AudioSource exhaustedAudio;
    public float exhaustedThreshold = 10f;
    public float exhaustedMaxVolume = 0.8f;
    public float audioFadeSpeed = 2.5f;

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
        // ?? STAMINA BAR UI
        if (staminaSlider != null)
            staminaSlider.value = stamina;

        bool showStamina = fpsController.isSprinting || stamina < 30f;
        float targetAlpha = showStamina ? 1f : 0f;

        if (staminaCanvasGroup != null)
        {
            staminaCanvasGroup.alpha = Mathf.Lerp(
                staminaCanvasGroup.alpha,
                targetAlpha,
                Time.deltaTime * uiFadeSpeed
            );
        }

        // ????? STAMINA MANTIÐI
        if (fpsController.isSprinting)
            stamina -= decreaseRate * Time.deltaTime;
        else
            stamina += 2f * Time.deltaTime;

        stamina = Mathf.Clamp(stamina, 0f, 100f);

        // ?? SPRINT KÝLÝDÝ
        if (stamina <= 0f)
            fpsController.sprintSpeed = fpsController.walkSpeed;
        else
            fpsController.sprintSpeed = 25f;

        // ????? YORGUNLUK SESÝ (FADE IN / OUT)
        HandleExhaustedAudio();
    }

    void HandleExhaustedAudio()
    {
        if (exhaustedAudio == null) return;

        bool shouldPlay = stamina <= exhaustedThreshold;

        if (shouldPlay)
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
}
