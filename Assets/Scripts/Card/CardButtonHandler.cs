using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class CardButtonHandler : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    public int buttonIndex;
    private TextMeshProUGUI textMeshProUGUI_button_object;
    private Image image_button_object;
    public Image buttonImage;

    


    void Start()
    {
        // buttonImage.sprite = Hand.hand[buttonIndex].cardImage;
        textMeshProUGUI_button_object = GetComponentInChildren<TextMeshProUGUI>();
        image_button_object = GetComponentInChildren<Image>();

        textMeshProUGUI_button_object.text = Hand.hand[buttonIndex].cardName;
        image_button_object.sprite = Hand.hand[buttonIndex].cardImage;   
        button = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        if (gameManager != null)
        {
            gameManager.NextStep(buttonIndex, GameManager.Instance.currentEvent);
        }
        else
        {
            Debug.LogError("GameManager or Card is not assigned.");
        }
    }


    public void Update()
    {
        textMeshProUGUI_button_object.text = Hand.hand[buttonIndex].cardName;
        image_button_object.sprite = Hand.hand[buttonIndex].cardImage;  
        // Debug.Log("кнопки обновлены");
    }
}