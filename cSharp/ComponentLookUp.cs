using System;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentLookUp 
{
    public static void GetChildRecursive<T>(GameObject obj, List<T> objectList)
    {
        //if we are at the end return
        if (null == obj)
            return;

        //get all components in this transform
        T[] comps = obj.GetComponents<T>();

        //loop through components
        foreach (T comp in comps)
            if (comp is T)//if comp is T add it to list
                objectList.Add(comp);

        //go through all transform children
        foreach (Transform child in obj.transform)
        {
            //if child is null go next
            if (null == child)
                continue;
            
            //go to next child
            GetChildRecursive(child.gameObject, objectList);
        }
    }
}
