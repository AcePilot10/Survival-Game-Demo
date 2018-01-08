using UnityEngine;

namespace ToolItem
{
    public class Tool : Item
    {
        public virtual void Equip() { }

        public virtual void Unequip() { }

        public virtual void InitModel() { }

        public virtual void UnequipModel() { }
    }
}