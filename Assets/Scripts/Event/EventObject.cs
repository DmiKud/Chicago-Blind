// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class EventObject : MonoBehaviour
// {

//     public AbstractEvent eventInst;
//     private GameManager gameManager;


//     void Start()
//     {
//         gameManager = FindObjectOfType<GameManager>();
//         GetComponentInChildren<TextMeshProUGUI>().text = eventInst.eventName;
//         GetComponentInChildren<Image> ().sprite = eventInst.eventImage;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         GetComponentInChildren<TextMeshProUGUI>().text = eventInst.eventName;
//         GetComponentInChildren<Image> ().sprite = eventInst.eventImage;
//     }
// }


using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventObject : MonoBehaviour
{
    public TextMeshProUGUI eventNameText;
    public Image eventImage;
    private GameManager gameManager;

    void Start()
    {
        // Найдите GameManager в сцене
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager instance not found.");
            return;
        }

        // Убедитесь, что TextMeshProUGUI и Image установлены
        if (eventNameText == null || eventImage == null)
        {
            Debug.LogError("UI components not assigned.");
            return;
        }

        // Обновите UI элементы на основе текущего события
        UpdateEventUI();
    }

    void Update()
    {
        // Обновляйте UI элементы каждый кадр (или добавьте условие, если необходимо)
        UpdateEventUI();
    }

    void UpdateEventUI()
    {
        if (gameManager.currentEvent != null)
        {
            eventNameText.text = gameManager.currentEvent.eventName;
            eventImage.sprite = gameManager.currentEvent.eventImage;
        }
    }
}
