using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    private GameManager gameManager;

    void Start()
    {
        // Найдите GameManager в сцене и убедитесь, что он не равен null
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager instance not found.");
            return;
        }

        if (slider == null)
        {
            slider = GetComponent<Slider>();
            if (slider == null)
            {
                Debug.LogError("Slider component not found.");
                return;
            }
        }

        UpdateProgressBar();
    }

    void Update()
    {
        UpdateProgressBar();
    }

    void UpdateProgressBar()
    {
        if (gameManager != null && slider != null)
        {
            float progress = (float)gameManager.scorePoints / (float)gameManager.winScore;
            slider.value = progress;
            // Debug.Log($"There is {progress} progress in the bar");
        }
    }
}
