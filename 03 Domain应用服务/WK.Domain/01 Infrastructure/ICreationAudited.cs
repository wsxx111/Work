using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WK.Domain
{
    public interface ICreationAudited
    {
        string F_Id { get; set; }
        string F_CreatorUserId { get; set; }
        DateTime? F_CreatorTime { get; set; }
    }
}
