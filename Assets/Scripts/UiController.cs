using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Text text;

    public void UpdateUI(string message)
    {
        text.text = message;
    }
}