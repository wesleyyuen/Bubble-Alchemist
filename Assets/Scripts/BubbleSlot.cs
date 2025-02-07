using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleSlot : MonoBehaviour, IDroppable
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        DraggableObject draggable = eventData.pointerDrag.GetComponentInChildren<DraggableObject>();
        if (draggable == null) return;

        eventData.pointerDrag.transform.SetParent(transform);

        // TODO: get rect and set anchored position 0
        eventData.pointerDrag.transform.localPosition = Vector3.zero;
    }
}
