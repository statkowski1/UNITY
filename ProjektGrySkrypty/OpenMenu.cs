using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject CloseButton;

    public void OpenPanel()
    {
        if (Panel != null && CloseButton != null)
        {
            Panel.SetActive(true);
            CloseButton.SetActive(true);
        }
    }
}
