using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    private int playingAsPlayer;
    private GameObject player;

    private TextMeshProUGUI TMP;
    private Image img;

    void Start()
    {
        playingAsPlayer = gameSettings.playingAsPlayer;
        player = gameSettings.GetPlayer(playingAsPlayer);

        TMP = transform.Find("HealthText").GetComponent<TextMeshProUGUI>();
        img = transform.Find("Heart").GetComponent<Image>();
    }

    void Update()
    {
        playingAsPlayer = gameSettings.playingAsPlayer;
        player = gameSettings.GetPlayer(playingAsPlayer);

        if (player.GetComponent<FirstPersonSettings>() == null)
        {
            TMP.text = Mathf.FloorToInt(player.GetComponent<ThirdPersonSettings>().PlayerHealth).ToString();
        }
        else
        {
            TMP.text = Mathf.FloorToInt(player.GetComponent<FirstPersonSettings>().PlayerHealth).ToString();
        }

    }
}
