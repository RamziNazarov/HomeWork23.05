using System.Collections.Generic;

namespace HomeWork21._05.Reps
{
    interface IReadAllFromDB<TModel>
    {
        List<TModel> ReadAll();
    }
}
