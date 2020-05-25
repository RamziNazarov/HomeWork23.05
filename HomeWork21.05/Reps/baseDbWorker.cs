using Dapper;
using HomeWork21._05.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HomeWork21._05.Reps
{
    public abstract class DbWorker<TModel> : IReadAllFromDB<TModel>, IAddOnePerson, IReadById<TModel>, ISearchByFLM<TModel>
    {
        public void AddOnePerson(Person person)
        {
            if(!NorE(person.FirstName) && !NorE(person.LastName) && !NorE(person.MiddleName))
            using (IDbConnection db = new SqlConnection(ConString.constring))
            {
                db.Execute($"insert into Person(FirstName,LastName,MiddleName) values('{person.FirstName}','{person.LastName}','{person.MiddleName}')");
            }
        }

        public List<TModel> ReadAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConString.constring))
                {
                    return db.Query<TModel>($"select * from {typeof(TModel).Name}").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public TModel ReadById(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConString.constring))
                {
                    return db.Query<TModel>($"select * from {typeof(TModel).Name} where Id = {id}").ToList()[0];
                }
            }
            catch
            {
                return (dynamic)null;
            }
        }
        public bool NorE(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public List<TModel> SearchByFLM(string FirstName, string LastName, string MiddleName)
        {
            try
            {
                FirstName = (FirstName != null)?FirstName.ToLower():FirstName;
                LastName = (LastName != null)?LastName.ToLower():LastName;
                MiddleName = (MiddleName != null)?MiddleName.ToLower():MiddleName;
                string comstr = $"select * from {typeof(TModel).Name}";
                comstr += (!NorE(FirstName) && !NorE(LastName) && !NorE(MiddleName)) ? $" where LOWER(FirstName) = '{FirstName}' and LOWER(LastName) = '{LastName}' and LOWER(MiddleName) = '{MiddleName}'"
                    : (!NorE(FirstName) && !NorE(LastName)) ? $" where LOWER(FirstName) = '{FirstName}' and LOWER(LastName) = '{LastName}'"
                    : (!NorE(FirstName) && !NorE(MiddleName)) ? $" where LOWER(FirstName) = '{FirstName}' and LOWER(MiddleName) = '{MiddleName}'"
                    : (!NorE(LastName) && !NorE(MiddleName)) ? $" where LOWER(LastName) = '{LastName}' and LOWER(MiddleName) = '{MiddleName}'"
                    : (!NorE(FirstName)) ? $" where LOWER(FirstName) = '{FirstName}'"
                    : (!NorE(LastName)) ? $" where LOWER(LastName) = '{LastName}'"
                    : (!NorE(MiddleName)) ? $" where LOWER(MiddleName) = '{MiddleName}'"
                    : "";
                using (IDbConnection db = new SqlConnection(ConString.constring))
                {
                    return db.Query<TModel>(comstr).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
