using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data: ScriptableObject
{
    public int num;
    public int record;
    public int coins;
    public int cena;
    public int lvlNumber;

    public bool soundOn;
}
