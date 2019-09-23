using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for interaction with Employees
    /// </summary>
    public interface IEmployeeServices
    {
        /// <summary>
        /// Get the list of employees
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();
        
        /// <summary>
        /// Get an employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeView GetById(int id);

        /// <summary>
        /// Save changes to a DB
        /// </summary>
        void Commit();

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="model"></param>
        void AddNew(EmployeeView model);

        /// <summary>
        /// Delete an employee by Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
