using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T>  where T : MonoBehaviour
{
    public T _prefab;
    public Transform _container;

    private List<T> _pool;

    public PoolMono(T prefab, int objectCount, Transform container) {
        _prefab = prefab;
        _container = container;

        _pool = new List<T>();
        for (int i = 0; i < objectCount; i++) {
            Create();
        }
    }

    private T Create(bool isActive = false) {
        var obj = Object.Instantiate(_prefab, _container);
        obj.gameObject.SetActive(isActive);
        _pool.Add(obj);
        return obj;
    }

    public bool HasFreeObject(out T obj) {
        foreach (var mono in _pool) {
            if (!mono.gameObject.activeInHierarchy) {
                obj = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        obj = null;
        return false;
    }

    public T Get() {
        if (HasFreeObject(out var obj)) {
            return obj;
        }
        return Create(true);
    }

    public void Release(T obj) {
        obj.gameObject.SetActive(false);
    }
}

