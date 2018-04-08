using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform m_CamTransform;

    private const float _BasicShakeDuration = 3f;

    // How long the object should shake for.
    public float m_ShakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float m_ShakeAmount = 0.15f;

    public float m_DecreaseFactor = 1.0f;

    public AnimationCurve _curve;

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

    public void BasicShake()
    {
        m_ShakeDuration = _BasicShakeDuration;
    }

    public void EndShake()
    {
        m_ShakeDuration = _BasicShakeDuration * 2;
    }

    void Update()
    {
        if (m_ShakeDuration > 0)
        {
            float thisShake = Mathf.Lerp(0, m_ShakeAmount, _curve.Evaluate(m_ShakeDuration / _BasicShakeDuration));
            m_CamTransform.localPosition = originalPos + Random.insideUnitSphere * thisShake;

            m_ShakeDuration -= Time.deltaTime * m_DecreaseFactor;
        }
        else
        {
            m_ShakeDuration = 0f;
            m_CamTransform.localPosition = originalPos;
        }
    }
}
