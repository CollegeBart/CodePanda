using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform m_CamTransform;

    // How long the object should shake for.
    public float m_ShakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float m_ShakeAmount = 0.7f;
    public float m_DecreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (m_CamTransform == null)
        {
            m_CamTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = m_CamTransform.localPosition;
    }

    void Update()
    {
        if (m_ShakeDuration > 0)
        {
            m_CamTransform.localPosition = originalPos + Random.insideUnitSphere * m_ShakeAmount;

            m_ShakeDuration -= Time.deltaTime * m_DecreaseFactor;
        }
        else
        {
            m_ShakeDuration = 0f;
            m_CamTransform.localPosition = originalPos;
        }
    }
}
