using UnityEngine;

namespace Ryan
{
    public interface Item
    {
        Transform transform { get; set; }
        bool Pickup { get; set; }
    }

    [CreateAssetMenu]
    public class Weapon : ScriptableObject, Item
    {
        public GameObject item;
        public float damage;

        Transform Item.transform
        {
            get { Transform transform = item.transform; return transform; }
            set { Transform transform = value; }
        }

        bool Item.Pickup
        {
            get { bool pickup = false; return pickup; }
            set { bool pickup = value; }
        }
    }

    [CreateAssetMenu]
    public class Consumable : ScriptableObject, Item
    {
        public GameObject item;
        public int heal;

        Transform Item.transform
        {
            get { Transform transform = item.transform; return transform; }
            set { Transform transform = value; }
        }

        bool Item.Pickup
        {
            get { bool pickup = false; return pickup; }
            set { bool pickup = value; }
        }
    }

    [CreateAssetMenu]
    public class KeyItems : ScriptableObject, Item
    {
        public GameObject item;
        bool important = true;

        Transform Item.transform
        {
            get { Transform transform = item.transform; return transform; }
            set { Transform transform = value; }
        }

        bool Item.Pickup
        {
            get { bool pickup = false; return pickup; }
            set { bool pickup = value; }
        }
    }

    [CreateAssetMenu]
    public class Distraction : ScriptableObject, Item
    {
        public GameObject item;
        bool distract = false;

        Transform Item.transform
        {
            get { Transform transform = item.transform; return transform; }
            set { Transform transform = value; }
        }

        bool Item.Pickup
        {
            get { bool pickup = false; return pickup; }
            set { bool pickup = value; }
        }
    }

    //class Items : ScriptableObject
    //{
    //    public enum Item
    //    {
    //        pipe, 
    //        rock,
    //        key,
    //        roomKey,
    //        twoXfour,
    //        bottle,
    //        knife
    //    }
    //}
}