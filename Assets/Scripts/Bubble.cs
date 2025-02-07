using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ToggleBlockRaycast))]
public class Bubble : MonoBehaviour, IDraggable
{
    [SerializeField, HideInInspector] private RectTransform _rect;
    [SerializeField, HideInInspector] private ToggleBlockRaycast _toggleRaycast;

    private Vector2 _preDropPos;
    
    private void OnValidate()
    {
        _rect ??= GetComponent<RectTransform>();
        _toggleRaycast ??= GetComponent<ToggleBlockRaycast>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        _preDropPos = _rect.anchoredPosition;
        _toggleRaycast.EnableBlockRaycast(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");
        _toggleRaycast.EnableBlockRaycast(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("OnPointerUp");

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("OnPointerEnter");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("OnPointerExit");

    }
}
