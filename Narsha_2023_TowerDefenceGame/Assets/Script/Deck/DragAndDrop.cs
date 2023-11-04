using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject draggedObject;
/*    [SerializeField] private TextMeshProUGUI draggedTmp1;
    [SerializeField] private TextMeshProUGUI draggedTmp2;*/
    [SerializeField] private Image draggedImg;
    
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 10.0f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 10.0f;
        draggedObject.transform.localScale = new Vector2(1.0f, 1.0f);
        draggedImg.transform.localScale = new Vector2(1f, 1f);
        canvasGroup.blocksRaycasts=true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Point has been down");
        /*draggedTmp1.transform.localScale = 3*/
        draggedObject.transform.localScale = new Vector2(1.2f,1.2f);
        draggedImg.transform.localScale = new Vector2(1.2f, 1.2f);
    }
}
