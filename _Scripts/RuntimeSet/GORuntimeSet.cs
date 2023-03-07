using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GORuntimeSet : ScriptableObject
{
    public List<GameObject> set;
    
    public void Add(GameObject g)
    {
        if (!set.Contains(g))
            set.Add(g);
    }

    public void Remove(GameObject g)
    {
        if (set.Contains(g))
            set.Remove(g);
    }

    public void DestoryObjectsInSet()
    {
        for(int i = set.Count -1; i >= 0; i--)
        {
            Destroy(set[i]);
        }
    }
}
