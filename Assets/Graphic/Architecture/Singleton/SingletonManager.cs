#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonManager : MonoBehaviour
{
    private static readonly Dictionary<Type, object> _instances = new();
    
    private static bool _sceneEventRegistered = false;

    //인스턴스 가져옴
    public static T Get<T>() where T : class
    {
        if (_instances.TryGetValue(typeof(T), out var obj))
            return (T)obj;
        throw new Exception($"Singleton of type {typeof(T)} not initialized.");
    }

    //수동으로 초기화
    public static void Set<T>(T instance) where T : class
    {
        _instances[typeof(T)] = instance!;
    }

    //SingletonAttribute 있는 클래스 초기화
    public static void InitializeAllSingletons(Assembly? targetAssembly = null)
    {
        var asm = targetAssembly ?? Assembly.GetExecutingAssembly();

        foreach (var type in asm.GetTypes())
        {
            if (type.GetCustomAttribute<SingletonAttribute>() == null) continue; //SingletonAttribute 가 없는 클래스
            //if (_instances.ContainsKey(type)) continue; //이미 초기화된 클래스

            object? instance = null;

            // MonoBehaviour 생성
            if (typeof(UnityEngine.MonoBehaviour).IsAssignableFrom(type))
            {
                instance = FindAnyObjectByType(type);
                Debug.Log($"Try To Singleton: {type}");

                if (instance == null)
                {
                    GameObject obj = new GameObject(type.Name, type);
                    instance = obj.GetComponent(type);

                    Debug.Log($"{type.Name} Singletoned! (type : MonoBehaviour)");
                }

                GameObject instanceObject = ((UnityEngine.MonoBehaviour)instance).gameObject;

                
                // if (instanceObject.transform.parent != null && instanceObject.transform.root != null)
                //     DontDestroyOnLoad(instanceObject.transform.root.gameObject);
                // else DontDestroyOnLoad(instanceObject);
                
            }

            // ScriptableObject는 CreateInstance로 생성
            else if (typeof(UnityEngine.ScriptableObject).IsAssignableFrom(type))
            {
                instance = UnityEngine.ScriptableObject.CreateInstance(type);
                Debug.Log($"{type.Name} Singletoned! (type : ScriptableObject)");
            }

            // 일반 클래스
            else if (type.GetConstructor(Type.EmptyTypes) != null)
            {
                instance = Activator.CreateInstance(type);
                Debug.Log($"{type.Name} Singletoned! (type : ScriptableObject)");
            }


            if (instance != null)
                _instances[type] = instance;
        }

                // 씬 로드 이벤트 등록 (한 번만)
        if (!_sceneEventRegistered)
        {
            SceneManager.sceneLoaded += OnAnySceneLoaded;
            _sceneEventRegistered = true;
        }
    }

    private static void OnAnySceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (var instance in _instances.Values)
        {
            if (instance is ISceneLoadHandler handler)
                handler.OnSceneLoaded(scene, mode);
        }
    }
}