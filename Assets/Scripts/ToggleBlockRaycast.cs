using UnityEngine;
using UnityEngine.UI;

public class ToggleBlockRaycast : MonoBehaviour
{
    public void EnableBlockRaycast(bool shouldBlock)
    {
        // TODO: cache this? but maybe more might be added/remove in runtime that invalidate the cache
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            image.raycastTarget = shouldBlock;
        }
    }
}
