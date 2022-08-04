using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] SceneLoaderSO sceneLoaderAsset = null;
    private Animator anim;

    private void Start() {
        anim = GetComponentInChildren<Animator>();
        if(sceneLoaderAsset == null) Debug.LogWarning("SCENE LOADER: Missing scene loader asset reference");
    }
    
    public void InitLoadScene() // is called upon ChangeScene event
    {
        StartCoroutine(LoadScene());
    }
    
    public void LoadSceneByIndex(int index) {
        sceneLoaderAsset.LoadScene(index);
    }

    private IEnumerator LoadScene() 
    {
        anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneLoaderAsset.SceneIndexToLoad);
    }
}
