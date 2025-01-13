using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    [SerializeField] private bool showFPS;
    [SerializeField] private TextMeshProUGUI fpsText;
    [Tooltip("How often it counts the frames."), Min(0), SerializeField] private float pollingTime = 1;

    private float time;
    private int frameCount;

    private void Update()
    {
        fpsText.enabled = showFPS;

        time += Time.deltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = $"{frameRate} FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }

    public void ShowFPS(Toggle toggle)
    {
        showFPS = toggle.isOn;
    }
}
