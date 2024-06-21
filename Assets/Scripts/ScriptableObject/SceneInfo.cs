using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence", order = 0)]
public class SceneInfo : ScriptableObject {
    
    public int currentLevel = 1;
    public string namePlayer = "";
}
