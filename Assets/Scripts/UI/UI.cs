using UnityEngine;


public abstract class UI <T, K> : MonoBehaviour where T: class
{
    protected T UIComponent = default;
    private void Awake()
    {
        UIComponent = GetComponent<T>();
    }

    public abstract void UpdateValues(K input);
}
