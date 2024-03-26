using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicMangerScript : MonoBehaviour
{
    public int score = 0;
    public Text scoretext;
    public GameObject GameOverScreen;
    public void addscore()
    {
        score += 1;
        scoretext.text = score.ToString();
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameover()
    {
        GameOverScreen.SetActive(true);
    }
}
