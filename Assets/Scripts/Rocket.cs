using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    private float startY;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;
    [SerializeField] private GameObject warnText;
    
    int currentScore;
    int highScore;



    void Awake()
    {
        warnText.SetActive(false);

        startY = transform.position.y;
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        float score = (int)(transform.position.y - startY);
        currentScoreTxt.text = $"{score} M";

        if (score > 0)
        {
            currentScore = (int)score; // 현재 점수를 업데이트
            CheckHightScore(); // 최고 점수 체크
        }
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT)
        {
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
        }
        else 
        {
            warnText.SetActive(true);
        }
    }

    public void CheckHightScore()
    {
        // 1. HighScoreTxt.text가 비어 있거나 0이면, 현재 점수를 최고 점수로 설정
        if (string.IsNullOrEmpty(HighScoreTxt.text) || !int.TryParse(HighScoreTxt.text, out int highScore))
        {
            highScore = currentScore;
            HighScoreTxt.text = highScore.ToString();
            Debug.Log("최초 최고 점수 설정: " + highScore);
            return;
        }

        // 2. 기존 최고 점수와 현재 점수를 비교
        if (currentScore > highScore)
        {
            // 3. 현재 점수가 더 높으면 최고 점수를 업데이트
            highScore = currentScore;
            HighScoreTxt.text = highScore.ToString();
            Debug.Log("최고 점수 갱신됨: " + highScore);
        }
        else
        {
            Debug.Log("현재 점수는 최고 점수보다 낮습니다.");
        }
    }
}
