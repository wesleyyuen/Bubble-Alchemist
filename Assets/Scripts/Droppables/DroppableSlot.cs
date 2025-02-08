using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableSlot : MonoBehaviour, IDroppable
{
    [field: Header("Attachment Settings")]
    [field: SerializeField] public TweenSettings AttachTweenSettings { get; private set; }

    public IDraggable CurrentObjectInSlot { get; private set; }
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggableObject = eventData.pointerDrag;
        if (draggableObject == null) return;

        DraggableObject draggable = draggableObject.GetComponentInChildren<DraggableObject>();
        if (draggable == null) return;

        if (CurrentObjectInSlot != null)
        {
            draggable.OnDropFailed();
        }
        else
        {
            CurrentObjectInSlot = draggable;
            draggable.OnDropSuccess(this);
        }
    }
}
