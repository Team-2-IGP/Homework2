using UnityEngine;
using TMPro;
public class NumEnemies : MonoBehaviour
{
    public static NumEnemies Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI EnemyText;
    private int numEnemiesLeft = 0;

    public int CurrentEnemies => numEnemiesLeft;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateEnemyCounter();
    }

    private void addEnemy()
    {
        numEnemiesLeft += 1;
        UpdateEnemyCounter();
    }

    private void removeEnemy()
    {
        numEnemiesLeft -= 1;
        UpdateEnemyCounter();
    }

    private void UpdateEnemyCounter()
    {
        if (EnemyText != null)
        {
            EnemyText.text = $"Enemies Left: {numEnemiesLeft}";
        }
    }
}
