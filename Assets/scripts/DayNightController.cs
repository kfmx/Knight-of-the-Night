using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;

public class DayNightController : MonoBehaviour
{
    [SerializeField]
    private float dayDuration = 30;
    [SerializeField]
    private float nightDuration = 60;
    private float curDuration = 0;
    public bool isNight = false;

    [SerializeField]
    private Light2D globalLight;
    [SerializeField]
    private Light2D playerLight;
    private IEnumerator dayCO;
    private IEnumerator nightCO;
    private float curIntensity = 1;

    [SerializeField]
    private TextMeshProUGUI dayNightText;
    [SerializeField]
    private Color32 dayColor;
    [SerializeField]
    private Color32 nightColor;

    void Start() {
        dayCO = DayCO();
        nightCO = NightCO();

        if (isNight) SetNight();
        else SetDay();
    }

    void Update()
    {
        dayNightText.text = (isNight ? "Night: " + Mathf.RoundToInt(nightDuration - curDuration) : "Day: " + Mathf.RoundToInt(dayDuration - curDuration));
        
        curDuration += Time.deltaTime;

        if (curDuration >= (isNight ? nightDuration : dayDuration)) {
            if (isNight) SetDay();
            else SetNight();
            curDuration = 0;
        }
    }

    public void SetDay() {
        isNight = false;
        dayNightText.color = dayColor;
        StopCoroutine(nightCO);
        dayCO = DayCO();
        StartCoroutine(dayCO);
    }
    public void SetNight() {
        isNight = true;
        dayNightText.color = nightColor;
        StopCoroutine(dayCO);
        nightCO = NightCO();
        StartCoroutine(nightCO);
    }


    private IEnumerator DayCO() {
        while (curIntensity < 1) {
            curIntensity += Time.deltaTime;
            globalLight.intensity = Mathf.Clamp(curIntensity, 0, 1);
            playerLight.intensity = Mathf.Clamp(playerLight.intensity - Time.deltaTime, 0, 0.55f);
            yield return null;
        }
    }

    private IEnumerator NightCO() {
        while (curIntensity > 0) {
            curIntensity -= Time.deltaTime;
            globalLight.intensity = Mathf.Clamp(curIntensity, 0, 1);
            playerLight.intensity = Mathf.Clamp(playerLight.intensity + Time.deltaTime, 0, 0.55f);
            yield return null;
        }
    }
}
