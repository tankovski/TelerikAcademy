using NewsBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog.Repository
{
    public class CommentsRepository:Repository<Comment>
    {
        public CommentsRepository(DbContext context)
            :base(context)
        {
        }

        public override void Delete(Comment entity)
        {
            var subCommentSet = Context.Set<SubComment>();
            foreach (var subcomment in entity.SubComments)
            {
                subCommentSet.Remove(subcomment);
            }

            base.Delete(entity);
        }
    }
}
