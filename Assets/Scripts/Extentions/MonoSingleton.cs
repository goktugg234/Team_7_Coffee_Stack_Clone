using UnityEngine;

namespace Extentions
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
    
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject newGo = new GameObject();
                        _instance = newGo.AddComponent<T>();
                    }
                }
    
                return _instance;
            }
        }
    
        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }

    // public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    // {
    //     private static T instance;
    //     public static T Instance
    //     {
    //         get
    //         {
    //             if(instance == null)
    //             {
    //                 instance = FindObjectOfType<T>();
    //             }
    //             return instance;
    //         }
    //     }
    //
    //     protected virtual void Awake()
    //     {
    //         if(instance == null)
    //         {
    //             instance = this as T;
    //         }
    //     }
    // }
}