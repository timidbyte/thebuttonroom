using UnityEngine;
using UnityEngine.Events;

public class LightButton : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<bool> clickEvent;

    private bool pressed;

    public void Click()
    {
        pressed = !pressed;
        clickEvent.Invoke(pressed);
    }
}
