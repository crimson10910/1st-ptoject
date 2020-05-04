using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Block : MonoBehaviour
    {
        public bool isStone = false;
        [SerializeField] private int live = 1;

        public Action<int> onCollision = (points) => { };
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isStone)
            {
                Destroy(gameObject);
                onCollision.Invoke(10);
            }
            else
            {
                live--;
                if (live <= 0)
                {
                    Destroy(gameObject);
                    onCollision.Invoke(20);
                }
            }
        }
    }
}