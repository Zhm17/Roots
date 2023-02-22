using UnityEngine;

[CreateAssetMenu(fileName = "Data", 
    menuName = "ScriptableObjects/NewBabyRoot", 
    order = 1)]
public class BabyRoot_SO : ScriptableObject
{
    public BabyRootType Type;
    public Sprite Sprite;
}
