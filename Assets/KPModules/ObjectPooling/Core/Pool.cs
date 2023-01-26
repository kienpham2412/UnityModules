using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.ObjectPooling
{
    public abstract class Pool<T> where T : Component
    {
        public abstract T GetObject();
        public abstract void CreateObjects(int amount);
        public abstract IEnumerable GetActiveObjects();
        public abstract IEnumerable GetInactiveObjects();
        public abstract IEnumerable GetAllObjects();
    }
}
