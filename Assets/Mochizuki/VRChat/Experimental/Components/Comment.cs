using UnityEngine;

namespace Mochizuki.VRChat.Experimental.Components
{
    public class Comment : MonoBehaviour
    {
        [SerializeField]
        [TextArea]
        private string Notes = "";
    }
}