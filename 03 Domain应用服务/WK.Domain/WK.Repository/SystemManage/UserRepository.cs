﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WK.Code;
using WK.Data.Repository;
using WK.Domain.Entity.SystemManage;
using WK.Domain.IRepository.SystemManage;

namespace WK.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<UserEntity>(t => t.F_Id == keyValue);
                db.Delete<UserLogOnEntity>(t => t.F_UserId == keyValue);
                db.Commit();
            }
        }

        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userEntity);
                }
                else
                {
                    userLogOnEntity.F_Id = userEntity.F_Id;
                    userLogOnEntity.F_UserId = userEntity.F_Id;
                    userLogOnEntity.F_UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                    userLogOnEntity.F_UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.F_UserPassword, 32).ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    db.Insert(userLogOnEntity);
                }
                db.Commit();
            }
        }
    }
}
