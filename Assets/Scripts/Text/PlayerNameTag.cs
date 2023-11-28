using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameTag : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float textSize = 12f;

    private TextMeshProUGUI _textMash;

    private void Awake()
    {
        _textMash = GetComponent<TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.position;
            TextFontSize();
        }

    }

    private void TextFontSize()
    {
        if(_textMash != null)
        {
            _textMash.fontSize = textSize;
        }
    }

}
