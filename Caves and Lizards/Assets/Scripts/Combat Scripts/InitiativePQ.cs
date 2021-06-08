using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

namespace PQNS {
    public class PQ {
        public LinkedList<GameObject> list;

        public PQ() {
            list = new LinkedList<GameObject>();
        }

        public void add(GameObject GO) {
            float insertInit = GO.GetComponent<StatInterface>().getStats().getInitiative();
            for (LinkedListNode<GameObject> node = list.First; node != null; node = node.Next)
            {   
                float currInit = node.Value.GetComponent<StatInterface>().getStats().getInitiative();
                if (currInit >= insertInit) {
                    continue;
                } else {
                    list.AddBefore(node, GO);
                    return;
                }
            }
        }
        /**
         * Takes out an item and cycles it to the back, while outputting it to the caller
         */
        public GameObject nextTurn() {
            LinkedListNode<GameObject> turn = list.First;
            list = list.First.Next.List;
            list.AddLast(turn);
            return turn.Value;
        }

        public int count() {
            return list.Count;
        }

        public void remove(GameObject GO) {
            list.Remove(GO);
        }

        public void clear() {
            list = new LinkedList<GameObject>();
        }

        // reinserts the object at the correct space if init was changed. 
        public void initChanged(GameObject GO) {
            list.Remove(GO);
            this.add(GO);
        }
    }
}
