using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneLoader", menuName = "SceneLoader")]
public class SceneLoaderSO : ScriptableObject
{
    public int SceneIndexToLoad
    {
        get { return sceneToLoad; }
        private set { sceneToLoad = value; }
    }

    [SerializeField] private int sceneToLoad = 0;
    [SerializeField] private GameEvent changeSceneEvent = null;

    public void LoadScene(int index)
    {
        SceneIndexToLoad = index;
        if(changeSceneEvent != null) changeSceneEvent.Raise();
    }

    public void ResetScene() => LoadScene(SceneManager.GetActiveScene().buildIndex);

}
