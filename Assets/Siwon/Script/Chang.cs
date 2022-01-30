using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chang : MonoBehaviour
{
    void OnEnable()
    {
        UIManager.Instance.ShowChoiceUI();
    }
}
