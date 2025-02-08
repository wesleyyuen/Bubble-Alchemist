using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ToggleBlockRaycast))]
public abstract class DraggableObject : MonoBehaviour, IDraggable
{
    [Header("Drag Failed Settings")]
    [SerializeField] private TweenSettings _dragFailedTweenSettings;
    
    [SerializeField, HideInInspector] protected RectTransform _rect;
    [SerializeField, HideInInspector] protected ToggleBlockRaycast _toggleRaycast;

    public IDroppable CurrentSlot { get; protected set; }
    
    protected Vector2 _preDropPos;
    
    protected void OnValidate()
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

    // Called AFTER OnDrop of IDroppable (i.e. can be used to validate)
    public void OnEndDrag(PointerEventData eventData)
    {
        _toggleRaycast.EnableBlockRaycast(true);
        
        // TODO: unset slot logic?
    }
    
    public void OnDropSuccess(IDroppable slot)
    {
        transform.SetParent(slot.gameObject.transform);
        CurrentSlot = slot;
        Tween.UIAnchoredPosition(_rect, Vector2.zero, slot.AttachTweenSettings);
    }

    public void OnDropFailed()
    {
        Tween.UIAnchoredPosition(_rect, _preDropPos, _dragFailedTweenSettings);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
