using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;

    void Start()
    {
        Panel.SetActive(false);
        Button.SetActive(false);
    }

    public void ClosePanel()
    {
        if(Panel != null && Button != null)
        {
            Panel.SetActive(false);
            Button.SetActive(false);
        }
    }
}
