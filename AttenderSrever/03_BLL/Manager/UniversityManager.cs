
using _01_DAL;
using _02_BOL;
using System.Collections.Generic;
using System.Linq;

namespace _03_BLL
{
    public class UniversityManager
    {
        // Create;
        public bool AddUniversity(UniversityModel newUniversity)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                University university = new University()
                {
                   // Id = newUniversity.Id,
                    Name = newUniversity.Name,
                    Country = newUniversity.Country,
                    City = newUniversity.City,
                    Address = newUniversity.Address,
                    Zip = newUniversity.Zip,
                    Site = newUniversity.Site,
                    PhoneNumber = newUniversity.PhoneNumber
                };
                ef.Universities.Add(university);
                try{
                    //ef.Database.ExecuteSqlCommand($"INSERT INTO [dbo].[University] ([Name],[Country],[City],[Address],[Zip],[Site],[PhoneNumber]) VALUES ({university.Name} , {university.Country} , {university.City}, {university.Address} , {university.Zip}, {university.Site} , {university.PhoneNumber})");
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }

        //Read 
        public List<UniversityModel> GetAllUniversities()
        {
            List<UniversityModel> universities = new List<UniversityModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (University item in ef.Universities)
                {
                    universities.Add(new UniversityModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        City = item.City,
                        Address = item.Address,
                        Zip = item.Zip,
                        Site = item.Site,
                        PhoneNumber = item.PhoneNumber
                    });
                }
            }
            return universities;
        }
        public UniversityModel GetUniversityById(int id)
        {

            UniversityModel university = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                University item = ef.Universities.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    university = new UniversityModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        City = item.City,
                        Address = item.Address,
                        Zip = item.Zip,
                        Site = item.Site,
                        PhoneNumber = item.PhoneNumber
                    };
                }
            }
            return university;
        }

        // update 
        public bool UpdateUniversity(int id, UniversityModel university)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                University updateUniversity = ef.Universities.FirstOrDefault(a => a.Id == id);
                if (updateUniversity == null) return false;

                //updateUniversity.Id = university.Id;
                updateUniversity.Name = university.Name;
                updateUniversity.Country = university.Country;
                updateUniversity.City = university.City;
                updateUniversity.Address = university.Address;
                updateUniversity.Zip = university.Zip;
                updateUniversity.Site = university.Site;
                updateUniversity.PhoneNumber = university.PhoneNumber;
                
                try{
                //   ef.Database.ExecuteSqlCommand($"UPDATE [dbo].[University] SET [Name] = {updateUniversity.Name}, [Country] = {updateUniversity.Country},[City] = { updateUniversity.City}, [Address] = { updateUniversity.Address}, [Zip] = { updateUniversity.Zip}, [Site] = { updateUniversity.Site}, [PhoneNumber] = { updateUniversity.PhoneNumber}  WHERE [Id] = {id}");
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }

        // delete
        public bool DeleteUniversity(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                University deletedUniversity = ef.Universities.FirstOrDefault(a => a.Id == id);
                if (deletedUniversity == null) return false;
                ef.Universities.Remove(deletedUniversity);
                try{
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }
    }
}