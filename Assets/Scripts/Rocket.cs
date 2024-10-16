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

    void Awake()
    {
        startY = transform.position.y;
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        float currentHeight = transform.position.y - startY;
        currentScoreTxt.text = $"{(int)currentHeight} M";
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= FUELPERSHOOT)
        {
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
            Debug.Log("Shoot");
            Debug.Log("if타는지");
        }
        else 
        {
            Debug.Log("fuel이 모자랍니다");
        }
    }
}
