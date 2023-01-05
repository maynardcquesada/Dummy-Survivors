using UnityEngine;

public class MousePlayModeSettings : MonoBehaviour
{
    [SerializeField] private bool lockAndHideCursor;
    
    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        LockAndHideCursor();
    }

    private void LockAndHideCursor()
    {
        if (!lockAndHideCursor)
            return;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
