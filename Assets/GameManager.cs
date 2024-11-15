using UnityEngine;
using TMPro;  // Importer la namespace TextMesh Pro

public class GameManager : MonoBehaviour
{
    public float gameTime = 10f;  // Temps de jeu en secondes (2 minutes)
    private float timeRemaining;
    private bool gameIsOver = false;

    public TextMeshProUGUI timerText;  // R�f�rence � TextMesh Pro pour afficher le timer
    public GameObject victoryPanel;   // R�f�rence au Panel de victoire

    void Start()
    {
        timeRemaining = gameTime;  // Initialiser le temps restant
        timerText.text = FormatTime(timeRemaining);  // Afficher le temps au d�part
    }

    void Update()
    {
        if (!gameIsOver)
        {
            timeRemaining -= Time.deltaTime;  // D�cr�menter le temps restant � chaque frame
            timerText.text = FormatTime(timeRemaining);  // Mettre � jour l'affichage du timer

            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        victoryPanel.SetActive(true);  // Afficher le panel de victoire
        
        gameIsOver = true;
        Debug.Log("Game Over!");
    }

    // Fonction pour formater le temps en minutes:secondes
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // M�thode pour r�initialiser le jeu
    public void RestartGame()
    {
        gameIsOver = false;
        timeRemaining = gameTime;
        victoryPanel.SetActive(false);  // Cacher le VictoryPanel avant de recommencer
        Debug.Log("Game Restarted");
    }
}