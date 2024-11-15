using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100; // Sant� maximale
    private int currentHealth;   // Sant� actuelle

    // R�f�rences pour la barre de vie
    public Image healthBar;      // Image de la barre de vie (vert)
    public Image healthBarBackground; // Arri�re-plan de la barre de vie

    // R�f�rences pour l'�cran de d�faite
    public GameObject defeatPanel;   // R�f�rence au panel de d�faite

    void Start()
    {
        // Initialisation de la sant� actuelle
        currentHealth = maxHealth;

        // Si les images de la barre de vie ne sont pas assign�es, on les cherche automatiquement
        if (healthBar == null)
        {
            healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        }

        if (healthBarBackground == null)
        {
            healthBarBackground = GameObject.Find("HealthBarBackground").GetComponent<Image>();
        }

        // Si le panel de d�faite n'est pas assign�, on le cherche automatiquement
        if (defeatPanel == null)
        {
            defeatPanel = GameObject.Find("DefeatPanel");
        }

        // Cacher le panel de d�faite au d�but
        defeatPanel.SetActive(false);

        // Initialisation de la barre de vie
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0; // S'assurer que la vie ne soit pas inf�rieure � 0

        // Mettre � jour la barre de vie
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Calculer la largeur de la barre de vie en fonction de la sant� actuelle
        float healthPercentage = (float)currentHealth / maxHealth; // Pourcentage de vie restant
        healthBar.rectTransform.localScale = new Vector3(healthPercentage, 1f, 1f); // Modifier l'�chelle du rectangle de la barre de vie

        // (Optionnel) Change la couleur de la barre de vie en fonction de la sant� restante
        if (healthPercentage > 0.5f)
        {
            healthBar.color = Color.green;
        }
        else if (healthPercentage > 0.2f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Afficher le panel de d�faite
        defeatPanel.SetActive(true);

        // (Optionnel) D�sactiver le joueur ou les contr�les ici
        // Par exemple : gameObject.SetActive(false); pour d�sactiver le joueur
    }
}