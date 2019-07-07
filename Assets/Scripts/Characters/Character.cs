using UnityEngine;

namespace Characters {
    [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class Character : ScriptableObject {
        public new string name;
        public RuntimeAnimatorController animatorController;
    }
}