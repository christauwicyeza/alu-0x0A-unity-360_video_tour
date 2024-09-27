using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VRHotspot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject sphereToActivate;
    public GameObject sphereToDeactivate;
    public float gazeDuration = 2f;
    private float gazeTimer = 0f;
    private bool isGazedAt = false;
    private Button button;
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.1f;
    private Vector3 initialScale;

    void Start()
    {
        button = GetComponent<Button>();
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (isGazedAt)
        {
            gazeTimer += Time.deltaTime;

            if (gazeTimer >= gazeDuration)
            {
                SwitchSpheres();
            }

            float scaleFactor = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
            transform.localScale = initialScale * scaleFactor;
        }
        else
        {
            gazeTimer = 0f;
            transform.localScale = initialScale;
        }
    }

    public void SwitchSpheres()
    {
        if (sphereToDeactivate != null)
        {
            sphereToDeactivate.SetActive(false);
        }

        if (sphereToActivate != null)
        {
            sphereToActivate.SetActive(true);
        }

        isGazedAt = false;
        gazeTimer = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isGazedAt = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isGazedAt = false;
    }

    public void OnClick()
    {
        SwitchSpheres();
    }
}
