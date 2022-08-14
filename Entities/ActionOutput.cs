using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddItemOutput<T> : ActionOutput<T>
    {
    }

    public class UpdateItemOutput<T> : ActionOutput<T>
    {
        public T OldItem { get; set; }
    }

    public class DeleteItemOutput<T> : ActionOutput<T>
    {
    }

    public class ActionOutput<T>
    {
        public ActionResult Result { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }
    }

    public enum ActionResult { Succeeded = 1, Failed = 2 }
}
