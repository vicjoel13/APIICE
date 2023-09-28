using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Models.DataModels;

namespace Repository
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
    public class EmployeeParameters : RequestParameters
    {

        public string flavor { get; set; }
        public string name { get; set; }

        public int quantity { get; set; }

        public DateTime MaxDate { get; set; }

        public DateTime MinDate { get; set; }

        public bool ValidDate => MaxDate > MinDate;

        public bool is_season_flavor { get; set; }
        public int signo { get; set; }

    }
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll(EmployeeParameters employeeParameters = null);

        IQueryable<T> GetAll();
        T Get(int id);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void SoftDelete(T entity);
        void SoftDeleteRange(IEnumerable<T> entities);
        void HardDelete(T entity);
        void HardDeleteRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}
