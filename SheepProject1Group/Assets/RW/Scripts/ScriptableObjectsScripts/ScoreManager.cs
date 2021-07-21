using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "ScriptableObjects/NewScoreManager")]
public class ScoreManager : ScriptableObject
{
   [SerializeField] private int sheepSaved;
   [SerializeField] private int sheepDropped;
   [SerializeField] private int sheepDroppedBeforeGameOver;
 
    public int SheepSaved { get { return sheepSaved; } private set { sheepSaved = value;  }}
    public int SheepDropped { get { return sheepDropped; } private set { sheepDropped = value; }}
    public int SheepDroppedBeforeGameOver { get { return sheepDroppedBeforeGameOver; }}

    private void OnEnable()
    {
        SheepSaved = 0;
        SheepDropped = 0;
    }

    public void SaveSheep()
    {
        SheepSaved++;
    }

    public void DropSheep()
    {
        SheepDropped++;
    }
}
