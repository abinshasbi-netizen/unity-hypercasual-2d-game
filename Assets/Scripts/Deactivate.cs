using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField] private bool isplayer;
    private int score;
    private int fallcount;

    [SerializeField] GameObject collectFXPrefab;

    private void Start()
    {
        score = 0;
        fallcount= 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 fxPos = collision.transform.position;
        if (collision.CompareTag("Objects")) { 

            collision.gameObject.SetActive(false);
            

        }
        if (isplayer) {

            score++;
            GameManagement.Instance.UpdateUI(score);
            AudioManagement.Instance.PlayCollect();

            /*Instantiate(
            collectFXPrefab,
            fxPos,
            Quaternion.identity
        );*/

        }
        else
        {
            fallcount++;
            GameManagement.Instance.UpdateLife();
            AudioManagement.Instance.Playfail();

            if (fallcount >= 3) {

                GameManagement.Instance.GameOver();
                
            
            }
        }
    }

}
