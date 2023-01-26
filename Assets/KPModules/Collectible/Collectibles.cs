using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KPModules.Collectible
{
    [System.Serializable]
    public class Collectibles
    {
        public List<Collectible> collectibles;
    }

    [System.Serializable]
    public class Collectible
    {
        public Collectible() { }
        public Collectible(int id, int amount)
        {
            this.id = id;
            this.amount = amount;
        }
        public int id, amount;
    }
}
