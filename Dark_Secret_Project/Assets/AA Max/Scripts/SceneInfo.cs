using UnityEngine;
[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{
    public int previousScene;

    private void Awake()
    {
        previousScene = 0;
    }

}
