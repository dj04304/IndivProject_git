using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputTmeText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMesh;

    private void FixedUpdate()
    {
        SetTimeText();
    }

    private void SetTimeText()
    {
        textMesh.text = DateTime.Now.ToString("t");
    }


}
