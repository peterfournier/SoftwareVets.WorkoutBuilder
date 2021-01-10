using System;
using System.Collections.Generic;

namespace SV.Builder.Repository
{
    public interface IRepository<TIdentityDataType>
    {
        bool Create(object obj);

        ICollection<TModel> Get<TModel>() where TModel : new();

        TModel Get<TModel>(TIdentityDataType identity)
            where TModel : IdentityModel<TIdentityDataType>, new();

        TModel Update<TModel>(TModel workoutEntityMock)
            where TModel : IdentityModel<int>, new();

        bool Remove<TModel>(TModel workoutEntityMock)
            where TModel : IdentityModel<int>, new();
    }
}
