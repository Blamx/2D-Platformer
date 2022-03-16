using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    Light2D Moodlight;

    [SerializeField]
    float RateChange = 0.5f;

    [SerializeField]
    float Max = 20f;

    [SerializeField]
    float Min = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Moodlight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moodlight.pointLightOuterRadius += Random.Range(-RateChange, RateChange);
        Moodlight.pointLightOuterRadius = Mathf.Clamp(Moodlight.pointLightOuterRadius, Min, Max);
    }
}
