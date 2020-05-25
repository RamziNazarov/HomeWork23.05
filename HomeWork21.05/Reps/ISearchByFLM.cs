using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork21._05.Reps
{
    interface ISearchByFLM<TModel>
    {
        List<TModel> SearchByFLM(string FirstName, string LastName, string MiddleName);
    }
}
