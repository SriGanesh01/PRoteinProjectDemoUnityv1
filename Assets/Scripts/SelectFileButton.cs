using UnityEngine;
using UnityEngine.UI;
using TMPro; // <-- Add this for TMP support

public class SelectFileButton : MonoBehaviour
{
    private Button button;
    private Text legacyText;
    private TMP_Text tmpText;

    [Header("Optional override")]
    public string overrideFileName;

    void Start()
    {
        button = GetComponent<Button>();

        // Try both types of text
        legacyText = GetComponentInChildren<Text>();
        tmpText = GetComponentInChildren<TMP_Text>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void OnClick()
    {
        string selectedFileName = !string.IsNullOrEmpty(overrideFileName)
            ? overrideFileName
            : (tmpText != null ? tmpText.text : (legacyText != null ? legacyText.text : string.Empty));
        GlobalVars.SetFile(selectedFileName);

        // Reload the new file data and regenerate visuals
        ReadTxt.ReloadFile(); 
    }

}
