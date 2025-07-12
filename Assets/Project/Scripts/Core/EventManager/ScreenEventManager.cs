using UnityEngine;

public class ScreenEventManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int lastWidth;
    private int lastHeight;
    public UnityEngine.Events.UnityEvent OnScreenSizeChanged;
    void Start()
    {
        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
       if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            lastWidth = Screen.width;
            lastHeight = Screen.height;
            OnScreenSizeChanged?.Invoke();
        }
    }
}
