using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/NewSheepProperty")]
public class SheepProperty : ScriptableObject
{
   [SerializeField] private string sheepName;
   [SerializeField] private float sheepSpeed;

    public string SheepName
    {
        get
        {
            if (sheepName == "")
            {
                Debug.LogWarning("No Name Sheep");
                return "None Name";
            }
            else
            {
                return sheepName;
            }       
        }
        set
        {
            sheepName = value;
        }
    }
    public float SheepSpeed
    {
        get
        {
            if (sheepSpeed == 0)
            {
                Debug.LogWarning("No Speed Sheep. Default speed = 5");
                return 5;
            }
            else
            {
                return sheepSpeed;
            }
        }
        private set
        {
            if(value > 20f)
            {
                Debug.LogWarning("Speed LIMIT Sheep. Max speed = 20");
                sheepSpeed = 1f;
            }
            else
            {
                sheepSpeed = value;
            }
        }
    }

    

    //public string SheepName { get; }
    //public float SheepSpeed => sheepSpeed; // эквивалент - public float SheepSpeed { get { return sheepSpeed; } }


}
