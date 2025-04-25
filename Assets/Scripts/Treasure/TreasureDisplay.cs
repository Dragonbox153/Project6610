using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text HPDisplay, treasureDisplay;
    [SerializeField]
    private GameObject player;
    private GetTreasure treasureCount;
    private PlayerHealth hpCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        treasureCount = player.GetComponent<GetTreasure>();
        hpCount = player.GetComponent<PlayerHealth>();
        treasureDisplay.text = "Treasure: $" + (float)treasureCount.totalTreasure + ".00";
        HPDisplay.text = "HP: " + (float)hpCount.health;
    }

    // Update is called once per frame
    void Update()
    {
        treasureDisplay.text = "Treasure: $" + (float)treasureCount.totalTreasure + ".00";
        HPDisplay.text = "HP: " + (float)hpCount.health;
    }
}
