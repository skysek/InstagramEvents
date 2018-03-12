using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.InstagramEvents
{
    public interface ICommentable
    {

        /// <summary>
        /// Gets the index.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Gets the poster.
        /// </summary>
        User Poster { get; }

        /// <summary>
        /// Gets the list of answers.
        /// </summary>
        IReadOnlyList<Comment> Comments { get; }

        /// <summary>
        /// Gets the posted date of the content.
        /// </summary>
        DateTime PostedAt { get; }

        Comment AddComment( User poster, string message );

        void DeleteComment( Comment answer );

    }
}
