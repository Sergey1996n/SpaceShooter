using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject lose;
    [SerializeField] private Canvas canvas;

    [Tooltip("Скорость корабля")]
    public float speed;
    [Tooltip("Ссылка на префаб взрыва корабля")]
    public GameObject explosions;
    [Tooltip("Ссылка на префаб для бластера")]
    public GameObject shot;
    [Tooltip("Ссылка на объект появления бластеров")]
    public Transform shotSpawn;
    [Tooltip("Время появления бластеров")]
    public float fireRate;
    private float nextFire;

    public static int countHeart;
    [Tooltip("Сердца в левом верхнем углу")]
    public  GameObject[] heart = new GameObject[3];
    
    public static float boundaryX;
    public static float boundaryY;
    public static int startCountHealt;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
            countHeart = startCountHealt;
        else
            countHeart = 3;

        switch (countHeart)
        {
            case 2:
                heart[2].SetActive(false);
                break;
            case 1:
                heart[2].SetActive(false);
                heart[1].SetActive(false);
                break;
        }

        Transform trCanvas = canvas.GetComponent<Transform>();
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        Transform tr = GetComponent<Transform>();
        boundaryX = Screen.width / 2 * trCanvas.localScale.x - bc.size.x * tr.localScale.x / 2;
        boundaryY = Screen.height / 2 * trCanvas.localScale.y - bc.size.y * tr.localScale.y / 2;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement * speed;

        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, -boundaryX, boundaryX),
            Mathf.Clamp(rb.position.y, -boundaryY, boundaryY)
            ) ;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            countHeart--;
            switch (countHeart)
            {
                case 2:
                    heart[2].SetActive(false);
                    break;
                case 1:
                    heart[1].SetActive(false);
                    break;
                case 0:
                    heart[0].SetActive(false);
                    Instantiate(explosions, transform.position, transform.rotation);
                    Destroy(gameObject);
                    lose.SetActive(true);
                    
                    break;
            }
        }
    }

        
}
