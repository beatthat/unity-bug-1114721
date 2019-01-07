using UnityEngine;

namespace BeatThat.Comments.StateMachine
{

    /// <summary>
    /// A comment you can attach to an Animator state.
    /// </summary>
    public class Comment : StateMachineBehaviour 
	{
		[Multiline(10)]
		public string text;
	}
}

