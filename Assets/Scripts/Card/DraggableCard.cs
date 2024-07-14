// using UnityEngine;
// using UnityEngine.EventSystems;

// public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
// {
//     private Vector3 startPosition;
//     private CanvasGroup canvasGroup;
//     private Transform parentToReturnTo;
//     public Card card;



//     private void Awake()
//     {
//         canvasGroup = GetComponent<CanvasGroup>();
//     }

//       public void OnPointerClick(PointerEventData eventData)
//     {
//         HandleCardClick();
//     }


//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         startPosition = transform.position;
//         parentToReturnTo = transform.parent;
//         transform.SetParent(transform.root); // Move to root to avoid being masked by other UI elements

//         canvasGroup.blocksRaycasts = false; // Disable raycast blocking to allow the card to be detected by other elements
//         Debug.Log("поднял карту");
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         transform.position = eventData.position;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         canvasGroup.blocksRaycasts = true; // Re-enable raycast blocking

//         // Check if the card is released over a valid drop area using 2D physics
//         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
//         print(hit.collider);
//         if (hit.collider != null && hit.collider.CompareTag("DropArea"))
//         {
//             HandleCardDrop(hit.collider.gameObject);
//             Debug.Log("опустил карту в нужную зону");
//         }
//         else
//         {
//             // Return the card to its original position if dropped in an invalid area
//             transform.position = startPosition;
//             transform.SetParent(parentToReturnTo);
//             Debug.Log("опустил карту в НЕнужную зону");
//         }
//     }

//     private void HandleCardDrop(GameObject dropArea)
//     {
//         // Implement your logic for handling card drop
//         // For example, call PlayCard method on the event associated with the drop area
//         AbstractEvent eventComponent = dropArea.GetComponent<AbstractEvent>();
//         if (eventComponent != null)
//         {
//             Card card = GetComponent<CardObject>().card;
//             eventComponent.PlayCard(card, FindObjectOfType<GameManager>());
//         }
//         // Destroy the card or move it to another parent if necessary
//         Destroy(gameObject);
//     }



//     private void HandleCardClick()
//     {
//         GameManager gameManager = FindObjectOfType<GameManager>();
//         AbstractEvent currentEvent = gameManager.currentEvent;

//         if (currentEvent != null && card != null)
//         {
//             currentEvent.PlayCard(card, gameManager);
//             Hand.Instance.Remove(card);
//             gameManager.hand.DrawCard(gameManager.hand.hand.IndexOf(card));
//         }
//     }

// }