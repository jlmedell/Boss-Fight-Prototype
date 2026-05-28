using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;

    public GameObject winText;
    public GameObject loseText;

    void Update()
    {
        if (boss == null)
        {
            winText.SetActive(true);
            Time.timeScale = 0;
        }

        if (player == null)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
