using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    private struct Player
    {
        private float money;
        private Vector3 position;
        private Quaternion rotation;
        private int trophey;
        private int[] object_actual; //type d'object, le but est d'ajouter les ID des objects à une liste/tableau
        private int[] Dice; //type de dés
        private int ID;
        private int actual_order;

    }
    
}
