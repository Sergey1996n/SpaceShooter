using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject score;

    private float boundaryX;

    [Tooltip("Список астероидов")]
    public List<AsteroidData> asteroidsSettings;
    [Tooltip("Количество объектов в пуле")]
    public int poolCount;
    [Tooltip("Ссылка на базовый префаб для астероидов")]
    public GameObject asteroidPrefab;
    [Tooltip("Время между спауном астероидов")]
    public float spawnTime;

    public static int asteroidsCount;
    public static Dictionary<GameObject, Asteroid> asteroids;
    private Queue<GameObject> currentAsteroids;

    void Start()
    {
        asteroids = new Dictionary<GameObject, Asteroid>();
        currentAsteroids = new Queue<GameObject>();
        poolCount = (SceneManager.GetActiveScene().buildIndex - 1) * 20;
        asteroidsCount = 0;
        for (int i = 0; i < poolCount; i++)
        {
            var prefab = Instantiate(asteroidPrefab);
            var script = prefab.GetComponent<Asteroid>();
            prefab.SetActive(false);
            asteroids.Add(prefab, script);
            currentAsteroids.Enqueue(prefab);
        }

        Asteroid.onAsteroidOverFly += ReturnAsteroid;

        Transform trCanvas = canvas.GetComponent<Transform>();
        CapsuleCollider2D ecAsteroidPrefab = asteroidPrefab.GetComponent<CapsuleCollider2D>();
        Transform trAsteroidPrefab = asteroidPrefab.GetComponent<Transform>();
        boundaryX = Screen.width / 2 * trCanvas.localScale.x - ecAsteroidPrefab.size.x * trAsteroidPrefab.localScale.x / 2;
        StartCoroutine(Spawn());

    }

    private void Update()
    {
        score.GetComponent<Text>().text = "Осталось уничтожить: " + (poolCount - asteroidsCount);
    }

    IEnumerator Spawn()
    {
                if (spawnTime == 0)
        {
            Debug.LogError("Не выставленно время спауна");
            spawnTime = 1f;
        }
        while (asteroidsCount != poolCount && PlayerController.countHeart != 0)
        {
            yield return new WaitForSeconds(spawnTime);
            if (currentAsteroids.Count > 0)
            {
                var asteroid = currentAsteroids.Dequeue();
                var script = asteroids[asteroid];
                asteroid.SetActive(true);

                int rand = Random.Range(0, asteroidsSettings.Count);
                script.Init(asteroidsSettings[rand]);

                asteroid.transform.position = new Vector2(Random.Range(-boundaryX, boundaryX), transform.position.y);
            }
        }
        if (PlayerController.countHeart != 0)
        {
            win.SetActive(true);
        }
    }

    private void ReturnAsteroid(GameObject _asteroid)
    {
        _asteroid.transform.position = new Vector2(0, 6f);
        _asteroid.SetActive(false);
        currentAsteroids.Enqueue(_asteroid);
    }

}
