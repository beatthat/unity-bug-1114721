using UnityEngine;

namespace BeatThat.Comments
{

    /// <summary>
    /// Component for adding comments to GameObjects viewable via the Unity editor Inspector.
    /// </summary>
    public class Comment : MonoBehaviour 
	{
		[Multiline(10)]
		public string text;
	}
}

