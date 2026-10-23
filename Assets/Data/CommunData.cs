using UnityEngine;

[CreateAssetMenu(fileName = "CommunData", menuName = "Scriptable Objects/CommunData")]
public class CommunData : ScriptableObject
{
    private struct CommunDatePlayer
    {
        private int order;
        private int playerID;
        public int Order { get { return order; } }
        public int PlayerID { get { return playerID; } }
        private Vector3 acutal_position;
        public Vector3 Position { get { return acutal_position; } }
        private Vector3[] PlayerPosition;
        
    }
    
    
}
