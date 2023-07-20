using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barController : MonoBehaviour
{
    private void Update()
    {
        Slider slippy = this.gameObject.GetComponent<Slider>();
        slippy.value = (float) GameManager.Instance.GetHealth() / 100;
    }
}
