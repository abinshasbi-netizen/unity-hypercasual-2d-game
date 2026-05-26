
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }

   // private GameObject canvas;
   
    
    private Pooling pooling;
    

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float fixedY;
    private Vector3 spawnpoint;

    [SerializeField] private float spawntime;
    private float nextspawn;

    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private Image lifebar_fill;

    private int fails;
    private float fillamount;

    [SerializeField] GameObject gameoverPanel;
    private void Awake()
    {
        if (Instance != null && Instance != this) { 

            Destroy(gameObject);
      
        }
        
        Instance = this;

       // canvas = null;
       // canvas = FindAnyObjectByType<Canvas>(FindObjectsInactive.Include).gameObject;
      

        pooling = GetComponent<Pooling>();

        gameoverPanel.SetActive(false);
      

    }
   
    void Start()
    {
        Time.timeScale = 0f;

        nextspawn = 0+spawntime;
        fails = 0;
        fillamount = 0;

        AudioManagement.Instance.PlayBackgroundMusic();
        
    }

    
    void Update()
    {
        float randomX = Random.Range(minX, maxX);
        spawnpoint = new Vector3(randomX, fixedY, 0);

        if (Time.time >= nextspawn)
        {
            GameObject obj = pooling.GetFromPool();
            if (obj != null)
            {
                obj.transform.position = spawnpoint;
            }

            nextspawn = Time.time + spawntime;
        }


    }

   public void UpdateUI(int score) {

        

        scoretext.text = $"Score : {score}";
    }
    public void UpdateLife()
    {
        fails++;

        if (fails == 1) { fillamount = .350f; }
        else if (fails == 2) { fillamount = .650f; }
        else if (fails == 3) { fillamount = 1; }

        lifebar_fill.fillAmount = fillamount;
    }

    public void GameOver()
    {

        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
        AudioManagement.Instance.Playgameover();
    }



}
