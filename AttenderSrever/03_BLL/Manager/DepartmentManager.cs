using _01_DAL;
using _02_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BLL
{
    public class DepartmentManager
    {
        // Create;
        public bool AddDepartment(DepartmentModel newDepartment)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Department department = new Department()
                {
                    //Id = newDepartment.Id,
                    Name = newDepartment.Name,
                    DepartmentManager = newDepartment.DepartmentManager,
                    UniversityId = newDepartment.UniversityId
                };
                ef.Departments.Add(department);
                try{
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }

        //Read 
        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Department item in ef.Departments)
                {
                    departments.Add(new DepartmentModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DepartmentManager = item.DepartmentManager,
                        UniversityId = item.UniversityId
                    });
                }
            }
            return departments;
        }

        public DepartmentModel GetDepartmentById(int id)
        {

            DepartmentModel department = null;
            using (AttenderEntities ef = new AttenderEntities())
            {
                Department item = ef.Departments.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    department = new DepartmentModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DepartmentManager = item.DepartmentManager,
                        UniversityId = item.UniversityId
                    };
                }
            }
            return department;
        }

        // update 

        public bool UpdateDepartment(int id, DepartmentModel department)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Department updateDepartment = ef.Departments.FirstOrDefault(a => a.Id == id);
                if (updateDepartment == null) return false;

                //updateDepartment.Id = department.Id;
                updateDepartment.Name = department.Name;
                updateDepartment.DepartmentManager = department.DepartmentManager;
                updateDepartment.UniversityId = department.UniversityId;
                try{
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }

        // delete
        public bool DeleteDepartment(int id)
        {
            using (AttenderEntities ef = new AttenderEntities())
            {
                Department deletedDepartment = ef.Departments.FirstOrDefault(a => a.Id == id);
                if (deletedDepartment == null) return false;
                ef.Departments.Remove(deletedDepartment);
                try{
                    ef.SaveChanges();
                }
                catch{
                    return false;
                }
            }
            return true;
        }

        //Read 
        public List<string> GetDepartmentsByUniId(int id)
        {
            List<string> departments = new List<string>();
            using (AttenderEntities ef = new AttenderEntities())
            {
                foreach (Department item in ef.Departments)
                {
                    if (item.Id == id)
                        departments.Add("Id" + " " + item.Id + ":" + " " + item.Name);
                }
            }
            return departments;
        }
    }
}