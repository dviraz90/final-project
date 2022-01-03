using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;

using System.Linq;

namespace _03_BLL
{
    public class MemberRoleManager
    {

        // Create;
        public bool AddMemberRole(MemberRoleModel newMemberRole)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole memberRole = new MemberRole()
                {
                    //Id = newMemberRole.Id,
                    MemberId = newMemberRole.MemberId,
                    UniversityId = newMemberRole.UniversityId,
                    Role = newMemberRole.Role
                };
                //ef.MemberRoles.Add(memberRole);           
                try
                {
                    ef.Database.ExecuteSqlCommand($"INSERT INTO [dbo].[MemberRole] ([MemberId],[UniversityId],[Role]) VALUES ({memberRole.MemberId} , {memberRole.UniversityId} , '{memberRole.Role}')");
                    //ef.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        //Read 
        public List<MemberRoleModel> GetAllMemberRoles()
        {
            List<MemberRoleModel> MemberRoles = new List<MemberRoleModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (MemberRole item in ef.MemberRoles)
                {
                    MemberRoles.Add(new MemberRoleModel()
                    {
                        Id = item.Id,
                        MemberId = item.MemberId,
                        UniversityId = item.UniversityId,
                        Role = item.Role
                    });
                }
            }
            return MemberRoles;
        }

        public MemberRoleModel GetMemberRoleById(int id)
        {

            MemberRoleModel memberRole = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole item = ef.MemberRoles.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    memberRole = new MemberRoleModel()
                    {
                        Id = item.Id,
                        MemberId = item.MemberId,
                        UniversityId = item.UniversityId,
                        Role = item.Role
                    };
                }
            }
            return memberRole;
        }

        // update 
        public bool UpdateMemberRole(int id, MemberRoleModel memberRole)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole updateMemberRole = ef.MemberRoles.FirstOrDefault(a => a.Id == id);
                if (updateMemberRole == null) return false;

                //updateMemberRole.Id = memberRole.Id;
                updateMemberRole.MemberId = memberRole.MemberId;
                updateMemberRole.UniversityId = memberRole.UniversityId;
                updateMemberRole.Role = memberRole.Role;

                try
                {
                    ef.Database.ExecuteSqlCommand($"UPDATE [dbo].[MemberRole] SET [MemberId] = {updateMemberRole.MemberId},[UniversityId] = {updateMemberRole.UniversityId},[Role] = { updateMemberRole.Role} WHERE [Id] = {id}");
                    //ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        // delete
        public bool DeleteMemberRole(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole deletedMemberRole = ef.MemberRoles.FirstOrDefault(a => a.Id == id);
                if (deletedMemberRole == null) return false;
                ef.MemberRoles.Remove(deletedMemberRole);
                try
                {
                    ef.Database.ExecuteSqlCommand($"DELETE FROM [dbo].[MemberRole] WHERE Id = {id}");
                    //ef.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public string GetRoleById(int memberId)
        {
            string memberRole = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole item = ef.MemberRoles.FirstOrDefault(a => a.MemberId == memberId);
                if (item != null)
                {
                    memberRole = item.Role;
                   
                }
            }
            return memberRole;
        }

        public int GetUniversityById(int memberId)
        {

            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole item = ef.MemberRoles.FirstOrDefault(a => a.MemberId == memberId);
                if (item != null)
                    return item.UniversityId;
            }
            return 0;
        }

        public int GetIdByMemberId(int memberId, string role)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                MemberRole item = ef.MemberRoles.FirstOrDefault(a => a.MemberId == memberId && a.Role == role);
                if (item != null)
                    return item.Id;
            }
            return 0;
        }
    }
}