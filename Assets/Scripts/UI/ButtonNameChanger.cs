using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonNameChanger : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.gameIsPaused)
        {
            text.text = "Resume the Search";
            this.GetComponent<ButtonNameChanger>().enabled = false;
        }
    }
}
