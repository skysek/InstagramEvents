using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.InstagramEvents
{
    public interface ILikable
    {

        /// <summary>
        /// Gets the index.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Gets the liker.
        /// </summary>
        User Poster { get; }

        /// <summary>
        /// Gets the list of likes.
        /// </summary>
        IReadOnlyList<Like> Likes { get; }

        Like AddLike( User liker );

    }
}
