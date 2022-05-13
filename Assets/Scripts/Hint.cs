using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private Image hintImage;
    [SerializeField] private TextMeshProUGUI hintTextMeshProUGUI;
    [SerializeField] private string hintText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            hintTextMeshProUGUI.text = hintText;
            hintImage.gameObject.SetActive(true);
            hintTextMeshProUGUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            hintImage.gameObject.SetActive(false);
            hintTextMeshProUGUI.gameObject.SetActive(false);
        }
    }
}
