using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data: ScriptableObject
{
    public int record;
    public int lvlNumber;
    public int maxLvlNumber;
    public bool soundOn;
}
