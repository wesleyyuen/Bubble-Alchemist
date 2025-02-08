using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDroppable : IDropHandler
{
    // This hijacks the unity's gameObject property
    GameObject gameObject { get;}

    TweenSettings AttachTweenSettings { get; }
    IDraggable CurrentObjectInSlot { get; }
}