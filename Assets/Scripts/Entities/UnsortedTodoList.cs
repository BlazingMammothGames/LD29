using UnityEngine;
using System.Collections.Generic;

public class UnsortedTodoList : MonoBehaviour {
    public List<string> todoItems = new List<string>();

    public void CheckItem(string item)
    {
        todoItems.Remove(item);
    }

    public int ItemsRemaining()
    {
        return todoItems.Count;
    }
}
