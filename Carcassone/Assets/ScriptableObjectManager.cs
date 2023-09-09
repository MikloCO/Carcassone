using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectManager : MonoBehaviour
{
    [SerializeField]
    ScriptableObject[] scriptableObjects;
    

    public ScriptableObject GetSO(int index)
    {
        if (index < scriptableObjects.Length && index > 0)
        {
            return scriptableObjects[index];
        }
        else
        {
            return scriptableObjects[0];
        }
    }

    public int GetSOCount()
    {
        return scriptableObjects.Length;
    }

    public Tile GetSOByCardID(string id)
    {
        for (int i = 0; i < scriptableObjects.Length; i++)
        {
            Tile t = (Tile)scriptableObjects[i];
            if (t.card_id.Equals(id))
            {
                return t;
            }
        }
        return null;
    }


}
