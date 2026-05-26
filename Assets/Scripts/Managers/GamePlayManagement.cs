using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManagement : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameoverPanel;


    public static GamePlayManagement Instance { get; private set; }


    private void Awake()
    {
        startPanel.SetActive(true);
        pausePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }

        Instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void StartGame() { 

        Time.timeScale= 1.0f;
        startPanel.SetActive(false);
    
    }
    public void PauseGame() { 
        Time .timeScale= 0f;
        pausePanel.SetActive(true);
    
    }
    public void ResumeGame()
    {

        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);

    }
    public void RestartGame() {

      
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startPanel.SetActive(false);
        Time.timeScale= 1.0f;   
    }
   


} 

