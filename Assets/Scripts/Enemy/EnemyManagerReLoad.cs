using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManagerReLoad : MonoBehaviour
{
    private void Update()
    {
        List<BerserkerTree> berserkers = GameObject.FindObjectsByType<BerserkerTree>(FindObjectsSortMode.None).ToList();
        List<EliteTree> elites = GameObject.FindObjectsByType<EliteTree>(FindObjectsSortMode.None).ToList();
        List<GruntTree> grunts = GameObject.FindObjectsByType<GruntTree>(FindObjectsSortMode.None).ToList();

        if(berserkers.Count == 0 && elites.Count == 0 && grunts.Count == 0)
        {
            DontDestroyOnLoad(GameObject.Find("Player"));
            GameObject.Find("Player").transform.position = Vector2.zero;
            SceneManager.LoadScene("DungeonScene");
        }
    }
}
