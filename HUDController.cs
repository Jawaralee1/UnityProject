using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemsText;
    [SerializeField] TextMeshProUGUI healthText;
    void Update()
    {
        gemsText.text = "GEMS: " + GameManager.Instance.GetGems();
        healthText.text = "HEALTH: " + GameManager.Instance.GetHealth() + "%";

    }
}
