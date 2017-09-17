using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WK.Data.Repository;
using WK.Domain.Entity.SystemManage;

namespace WK.Domain.IRepository.SystemManage
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
    }
}
