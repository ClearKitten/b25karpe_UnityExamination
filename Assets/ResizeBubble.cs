using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ResizeBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int characterWrapLimit;
    [SerializeField] private LayoutElement layoutElement;

    private void Update()
    {
        int textLength = text.text.Length;
        layoutElement.enabled = textLength > characterWrapLimit ? true : false;
    }
}
