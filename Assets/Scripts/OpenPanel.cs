using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        GlobalVars.isPanelOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = !panel.activeSelf;
            panel.SetActive(isActive);

            GlobalVars.isPanelOpen = isActive;
            Time.timeScale = isActive ? 0 : 1;

            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isActive;
        }
    }
}
