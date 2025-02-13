using UnityEngine;
using UnityEngine.EventSystems;

public interface IHoverable : IPointerEnterHandler, IPointerExitHandler
{
    // This hijacks the unity's gameObject property
    GameObject gameObject {get;}
}
