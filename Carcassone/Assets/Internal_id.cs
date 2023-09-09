using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internal_id : MonoBehaviour
{
    [SerializeField]
    private int internal_id = 0;

    public void StoreintiID(int assigned_identity)
    {
        internal_id = assigned_identity;
    }

    public int GetID()
    {
        return internal_id;
    }
}
