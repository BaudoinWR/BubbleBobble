using UnityEngine;

public class gamesystem : MonoBehaviour {

    public AudioSource source;
    public GameObject pad;

    //public string[] levels = { "Level1.1", "Level2", "Level3", "Level4", "Level5" };
    int currentLevel = 1;
	// Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(source);
        DontDestroyOnLoad(pad);
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(levels[levels.Length-1]);
        source.mute = false;
        source.Play();

    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("EnemyTag").Length == 0
            && GameObject.FindGameObjectsWithTag("EnemyBubbleTag").Length == 0)
        {
            print("reload");
            currentLevel = (currentLevel + 1) % UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            if (currentLevel == 0)
            {
                currentLevel++;
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);

        }
    }
}
